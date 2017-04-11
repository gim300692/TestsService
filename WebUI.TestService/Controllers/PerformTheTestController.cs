using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestService.Domain.Abstract;
using TestService.Domain.Concrete;
using TestService.Domain.Entities;
using TestService.WebUI.Models;

namespace TestService.WebUI.Controllers
{
    public class PerformTheTestController : Controller
    {
        private ITestsRepository repository;

        public PerformTheTestController(ITestsRepository testsRepository)
        {
            this.repository = testsRepository;
        }


        public ActionResult Index(TestExecutionViewModel testExec)
        {
            if (Request.HttpMethod == "GET")
            {
                if (repository.Tests.FirstOrDefault(t => t.Id == testExec.TestId).IsAnonimous)
                {
                    return RedirectToAction("Briefing", testExec);
                }
                else
                {
                    return View(testExec);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Briefing", testExec);
                }
                else
                {
                    return View(testExec);
                }
            }
        }

        public ActionResult Briefing(TestExecutionViewModel testExec)
        {
            testExec.Test = repository.Tests.First(t => t.Id == testExec.TestId);
            return View(testExec);
        }

        public ActionResult TestExecution(TestExecutionViewModel testExec)
        {
            if (Request.HttpMethod == "GET")
            {
                testExec.CorrectAnswersCount = 0;
                testExec.CurrentQuestionIndex = 1;

                testExec.QuestionQuantity = repository.Tests.First(t => t.Id == testExec.TestId).QuestionQuantity;
                testExec.Test = repository.Tests.FirstOrDefault(t => t.Id == testExec.TestId);
                testExec.Question = repository.Questions.Where(q => q.TestId == testExec.TestId).First(q => q.Index == testExec.CurrentQuestionIndex);
                testExec.Answers = repository.Answers.Where(a => a.QuestionId == testExec.Question.Id).ToList();
                testExec.TestSolveTime = new TimeSpan(testExec.Test.TestSolveTime.Hour, testExec.Test.TestSolveTime.Minute, testExec.Test.TestSolveTime.Second).TotalSeconds;
                testExec.StartExecutionTime = DateTime.Now;

                return View(testExec);
            }
            else
            {
                TestSession testSession = new TestSession();

                testSession.FinishExecutingTime = DateTime.Now;

                testSession.FirstName = testExec.FirstName;
                testSession.LastName = testExec.LastName;
                testSession.Age = testExec.Age;
                testSession.Email = testExec.Email;
                testSession.PhoneNumber = testExec.PhoneNumber;

                testSession.CorrectAnswersCount = testExec.CorrectAnswersCount;
                testSession.StartExecutingTime = testExec.StartExecutionTime;
                testSession.TestId = testExec.TestId;

                repository.SaveTestSession(testSession);

                return View("ThanksForYourParticipation");
            }
        }

        public PartialViewResult AjaxGetNextQuestion(string currentQuestionIndex, string currentAnswerId, string correctAnswersCount, string testId)
        {
            AjaxQuestionViewModel question = new AjaxQuestionViewModel();
            question.CurrentAnswerId = Int32.Parse(currentAnswerId);
            question.CurrentQuestionIndex = Int32.Parse(currentQuestionIndex);
            question.CorrectAnswersCount = Int32.Parse(correctAnswersCount);
            question.TestId = Int32.Parse(testId);
            question.QuestionQuantity = repository.Tests.First(t => t.Id == question.TestId).QuestionQuantity;

            if ((repository.Answers.FirstOrDefault(a => a.Id == question.CurrentAnswerId)).IsCorrect)
            {
                question.CorrectAnswersCount++;
            }

            if (question.CurrentQuestionIndex < question.QuestionQuantity)
            {

                question.CurrentQuestionIndex++;
                question.Question = repository.Questions.Where(q => q.TestId == question.TestId).First(q => q.Index == question.CurrentQuestionIndex);
                question.Answers = repository.Answers.Where(a => a.QuestionId == question.Question.Id).ToList();

                return PartialView(question);
            }
            else
            {
                return PartialView("FinishTestPartial", question);
            }

        }

        public ActionResult VerifyPersonalLink(string hashedLink)
        {
            TestExecutionViewModel testExec = new TestExecutionViewModel();
            PersonalLink personalLink = new PersonalLink();

            foreach (var pl in repository.PersonalLinks)
            {
                if (pl.HashedPersonalLink.Equals(hashedLink))
                {
                    personalLink = pl;
                    if (pl.IsActive)
                    {
                        testExec.TestId = pl.TestId;
                        testExec.PersonalLinkId = pl.Id;
                        pl.IsActive = false;
                        break;
                    }
                }
            }

            if(testExec.PersonalLinkId != 0)
            {
                repository.SavePersonalLink(personalLink);
                return RedirectToAction("Index", "PerformTheTest", testExec);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}
