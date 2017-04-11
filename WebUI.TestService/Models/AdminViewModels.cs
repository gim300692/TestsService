using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestService.Domain.Entities;
using WebUI.TestService.Models;

namespace TestService.WebUI.Models
{
    public class AdminViewModel
    {
        public ICollection<Test> Tests { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<TestSession> TestSessions { get; set; }
        public ICollection<PersonalLink> PersonalLinks { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<IdentityRole> Roles { get; set; }
    }
}