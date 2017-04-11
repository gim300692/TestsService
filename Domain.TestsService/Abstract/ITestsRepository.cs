using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestService.Domain.Entities;

namespace TestService.Domain.Abstract
{
    public interface ITestsRepository
    {
        IQueryable<Test> Tests { get; }

        IQueryable<Question> Questions { get; }

        IQueryable<Answer> Answers { get; }

        IQueryable<TestSession> TestSessions { get; }

        IQueryable<PersonalLink> PersonalLinks { get; }

        void SaveTest(Test test);
        void SaveTestSession(TestSession testSession);
        void SavePersonalLink(PersonalLink personalLink);
        void SaveAnswer(Answer answer);
        void SaveQuestion(Question question);


        Test DeleteTest(int testId);
        Question DeleteQuestion(int questionId);
        Answer DeleteAnswer(int answerId);
    }
}
