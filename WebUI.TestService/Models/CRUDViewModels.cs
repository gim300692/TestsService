using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestService.Domain.Entities;

namespace WebUI.TestService.Models
{
    public class TestCreationViewModel
    {
        [Required(ErrorMessage = "Введите тему теста!")]
        public string Theme { get; set; }

        [Required(ErrorMessage = "Введите описание теста")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите время на выполнение теста в формате чч/мм")]
        public DateTime TestSolveTime { get; set; }

        [Required(ErrorMessage = "Укажите степень конфиденциальности теста")]
        public bool IsAnonimous { get; set; }

        [Required(ErrorMessage = "Укажите дату, до которой данный тест действителен в формате гггг/мм/дд чч:мм")]
        [DataType(DataType.DateTime, ErrorMessage = "Введите дату и время в формате гггг/мм/дд чч:мм")]
        public DateTime? TestAvalibleTill { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; } 
    }

    public class TestEditionViewModel
    {

        public Test Test { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}