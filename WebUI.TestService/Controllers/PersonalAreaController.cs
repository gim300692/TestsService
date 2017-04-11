using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestService.Domain.Abstract;
using TestService.Domain.Concrete;
using TestService.Domain.Entities;
using TestService.WebUI.Models;

namespace WebUI.TestService.Controllers
{
    [Authorize]
    public class PersonalAreaController : Controller
    {
        private ITestsRepository repository;

        public PersonalAreaController(ITestsRepository testsRepository)
        {
            this.repository = testsRepository;
        }

        public ActionResult Index(PersonalAreaIndexViewModel model)
        {
            ViewBag.Host = Request.Url.Host;

            if (User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var userId = User.Identity.GetUserId();
                model.UserName = User.Identity.GetUserName();
                model.Tests = repository.Tests.Where(m => m.UserId == userId).ToList();
                model.PersonalLinks = repository.PersonalLinks.Where(m => m.UserId == userId).ToList();
                model.TestSessions = new List<TestSession>();
                foreach (var test in model.Tests)
                {
                    foreach (var ts in repository.TestSessions)
                    {
                        if (ts.TestId == test.Id)
                        {
                            model.TestSessions.Add(ts);
                        }
                    }
                }

                return View(model);
            }

        }
           
    }
}

