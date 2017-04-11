using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService.Domain.Entities
{
    public class TestSession
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int CorrectAnswersCount { get; set; }
        public DateTime? StartExecutingTime { get; set; }
        public DateTime? FinishExecutingTime { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

    }
}
