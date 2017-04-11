using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestService.Domain.Entities;

namespace TestService.WebUI.Models
{
    public class AjaxQuestionViewModel
    {
        public int CurrentQuestionIndex { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int TestId { get; set; }
        public int QuestionQuantity { get; set; }
        public int CurrentAnswerId { get; set; }

        public Question Question { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}