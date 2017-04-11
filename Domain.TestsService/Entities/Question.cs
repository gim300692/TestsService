using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int Index { get; set; }

        [Required(ErrorMessage = "Введите содержание вопроса")]
        [DataType(DataType.MultilineText)]
        public string QuestionContent { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
