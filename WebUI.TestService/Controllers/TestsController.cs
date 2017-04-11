using Microsoft.AspNet.Identity;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestService.Domain.Abstract;
using TestService.Domain.Concrete;
using TestService.Domain.Entities;
using WebUI.TestService.Models;

namespace WebUI.TestService.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private ITestsRepository repository;
        public TestsController(ITestsRepository testsRepository)
        {
            this.repository = testsRepository;
        }
        
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(TestCreationViewModel data)
        {
            if (ModelState.IsValid)
            {
                Test test = new Test();

                test.Theme = data.Theme;

                test.Description = data.Description;

                test.IsAnonimous = data.IsAnonimous;

                test.UserId = User.Identity.GetUserId();

                test.TestSolveTime = data.TestSolveTime;

                test.TestAvalibleTill = data.TestAvalibleTill;

                if (data.Questions.Count != 0)
                {
                    foreach (Question question in data.Questions)
                    {
                        if (question.QuestionContent != null)
                        {
                            foreach (Answer answer in data.Answers)
                            {
                                if (answer.QuestionId == question.Id)
                                {
                                    question.Answers.Add(answer);
                                }
                            }
                        }
                        test.Questions.Add(question);
                        test.QuestionQuantity++;
                    }
                }

                repository.SaveTest(test);

                return RedirectToAction("Index", "PersonalArea");

            }
            else
            {
                return View(data);
            }
        }



        public ActionResult EditTest(int Id)
        {
            TestEditionViewModel model = new TestEditionViewModel();

            model.Test = repository.Tests.FirstOrDefault(t => t.Id == Id);
            model.Questions = repository.Questions.Where(q => q.TestId == Id).ToList();
            model.Answers = new List<Answer>();

            foreach (var q in model.Questions)
            {
                foreach (var a in repository.Answers.Where(a => a.QuestionId == q.Id))
                {
                        model.Answers.Add(a);
                }
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult EditTest(TestEditionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Test test = new Test();

                test.Id = model.Test.Id;

                test.Theme = model.Test.Theme;

                test.Description = model.Test.Description;

                test.IsAnonimous = model.Test.IsAnonimous;

                test.UserId = User.Identity.GetUserId();

                test.TestSolveTime = model.Test.TestSolveTime;

                test.TestAvalibleTill = model.Test.TestAvalibleTill;

                if (model.Questions.Count != 0)
                {
                    foreach (Question question in model.Questions)
                    {
                        if (question.QuestionContent != null)
                        {
                            foreach (Answer answer in model.Answers)
                            {
                                if (answer.QuestionId == question.Id)
                                {
                                    question.Answers.Add(answer);
                                }
                            }
                        }
                        test.Questions.Add(question);
                        test.QuestionQuantity++;
                    }
                }

                repository.SaveTest(test);

                TempData["message"] = string.Format("Ваш тест на тему '{0}' был успешно изменён и сохранён", test.Theme);

                return RedirectToAction("Index", "PersonalArea");
            }
            else
            {
                return View(model);
            }
        }
        

        [HttpPost]
        public ActionResult DeleteTest(int testId)
        {
            Test deletedTEst = repository.DeleteTest(testId);
            if(deletedTEst != null)
            {
                TempData["message"] = string.Format("Тест на тему '{0}' успешно удалён", deletedTEst.Theme);
            }
            return RedirectToAction("Index","PersonalArea");
        }

        
        public PartialViewResult PersonalLinkCreator(Test test)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                ViewBag.Host = Request.Url.Host;

                PersonalLink pl = new PersonalLink();

                pl.HashedPersonalLink = PersonalLink.GetMd5Hash(md5Hash, test.Theme + DateTime.Now.Ticks.ToString());

                pl.TestId = test.Id;

                pl.UserId = User.Identity.GetUserId();

                pl.IsActive = true;

                repository.SavePersonalLink(pl);

                return PartialView(pl);
            }
        }

    }
}
