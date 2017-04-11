using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestService.Domain.Entities;

namespace TestService.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestSession> TestSessions { get; set; }
        public DbSet<PersonalLink> PersonalLinks { get; set; }
    }
}
