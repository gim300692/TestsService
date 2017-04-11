using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestService.Domain.Entities;

namespace TestService.WebUI.Models
{
    public class PersonalAreaIndexViewModel
    {
        [Display(Name = "Name")]
        public string UserName { get; set; }

        public ICollection<Test> Tests { get; set; } 

        public ICollection<PersonalLink> PersonalLinks { get; set; }

        public ICollection<TestSession> TestSessions { get; set; }

        public DateTime ActualTime = DateTime.Now;

    }
}