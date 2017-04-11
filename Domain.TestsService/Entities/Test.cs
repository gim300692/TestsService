using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestService.Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите тему теста!")]
        public string Theme { get; set; }

        [Required(ErrorMessage ="Введите описание теста")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int QuestionQuantity { get; set; }

        [Required(ErrorMessage = "Введите время на выполнение теста в формате чч/мм")]
        public DateTime TestSolveTime { get; set; }

        [Required(ErrorMessage ="Укажите степень конфиденциальности теста")]
        public bool IsAnonimous { get; set; }

        [Required(ErrorMessage = "Укажите дату, до которой данный тест действителен в формате гггг/мм/дд чч:мм")]
        [DataType(DataType.DateTime, ErrorMessage = "Введите дату и время в формате гггг/мм/дд чч:мм")]
        public DateTime? TestAvalibleTill { get; set; }

        public string UserId { get; set; } 

        public ICollection<Question> Questions { get; set; }
        public ICollection<TestSession> TestSessions { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            TestSessions = new List<TestSession>();
        }
    }
}
