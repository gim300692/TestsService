﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestService.Domain.Entities;

namespace TestService.WebUI.Models
{
    public class TestExecutionViewModel
    {
        public int TestId { get; set; }
        public Test Test { get; set; }
        public Question Question { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public int CurrentQuestionIndex { get; set; }
        public int QuestionQuantity { get; set; }
        public int CorrectAnswersCount { get; set; }

        public DateTime StartExecutionTime { get; set; }
        public DateTime FinishExecutingTime { get; set; }
        public double TestSolveTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int PersonalLinkId { get; set; }

    }
}