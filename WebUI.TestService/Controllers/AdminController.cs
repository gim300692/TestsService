using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestService.Domain.Abstract;
using TestService.Domain.Entities;
using TestService.WebUI.Models;
using WebUI.TestService.Models;

namespace TestService.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ITestsRepository repository;

        public AdminController(ITestsRepository testsRepository)
        {
            this.repository = testsRepository;
        }

        public ActionResult Index()
        {
            List<Test> tests = new List<Test>();
            tests = repository.Tests.ToList();

            return View(tests);
        }


        public PartialViewResult AjaxAdminGetQuestions(int testId)
        {
            List<Question> questions = new List<Question>();

            questions = repository.Questions.Where(q => q.TestId == testId).ToList();

            return PartialView(questions);
        }


        public PartialViewResult AjaxAdminGetAnswers(int questionId)
        {
            List<Answer> answers = new List<Answer>();

            answers = repository.Answers.Where(q => q.QuestionId == questionId).ToList();

            return PartialView(answers);
        }


        public ActionResult EditEntity(int? editTestId, int? editQuestionId, int? editAnswerId)
        {
            if(editTestId != null)
            {
                Test test = repository.Tests.First(t => t.Id == editTestId);
                return View("EditTest", test);
            }
            else
            {
                if (editQuestionId != null)
                {
                    Question question = repository.Questions.First(q => q.Id == editQuestionId);
                    return View("EditQuestion", question);
                }
                else
                {
                    if (editAnswerId != null)
                    {
                        Answer answer = repository.Answers.First(a => a.Id == editAnswerId);
                        return View("EditAnswer", answer);
                    }

                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult EditTestEntity(Test test)
        {

            if (ModelState.IsValid)
            {
                repository.SaveTest(test);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditTest", test);
            }
        }


        [HttpPost]
        public ActionResult EditAnswerEntity(Answer answer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveAnswer(answer);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditAnswer", answer);
            }
        }


        [HttpPost]
        public ActionResult EditQuestionEntity(Question question)
        {
            if (ModelState.IsValid)
            {
                repository.SaveQuestion(question);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditQuestion", question);
            }
        }


        [HttpPost]
        public ActionResult DeleteEntity(int? deleteTestId, int? deleteQuestionId, int? deleteAnswerId)
        {
            if (deleteTestId != null)
            {
                Test deletedTest = repository.DeleteTest((int)deleteTestId);
                if(deletedTest != null)
                {
                    return RedirectToAction("Index");
                }
            }

            if (deleteQuestionId != null)
            {
                Question deletedQuestion = repository.DeleteQuestion((int)deleteQuestionId);
                if(deletedQuestion != null)
                {
                    return RedirectToAction("Index");
                }
            }

            if (deleteAnswerId != null)
            {
                Answer deletedAnswer = repository.DeleteAnswer((int)deleteAnswerId);
                if (deletedAnswer != null)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }
}