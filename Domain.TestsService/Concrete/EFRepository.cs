using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestService.Domain.Abstract;
using TestService.Domain.Concrete;
using TestService.Domain.Entities;

namespace Domain.TestsService.Concrete
{
    public class EFRepository:ITestsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Test> Tests
        {
            get { return context.Tests; }
        }

        public IQueryable<Question> Questions
        {
            get { return context.Questions; }
        }

        public IQueryable<Answer> Answers
        {
            get { return context.Answers; }
        }

        public IQueryable<TestSession> TestSession
        {
            get { return context.TestSessions; }
        }

        public IQueryable<PersonalLink> PersonalLinks
        {
            get { return context.PersonalLinks; }
        }

        public IQueryable<TestSession> TestSessions
        {
            get { return context.TestSessions; }
        }

        public void SaveTest(Test test)
        {
            if(test.Id == 0)
            {
                context.Tests.Add(test);
            }
            else
            {
                Test dbEntry = context.Tests.Find(test.Id);


                if (dbEntry != null)
                {
                    dbEntry.Theme = test.Theme;
                    dbEntry.Description = test.Description;
                    dbEntry.QuestionQuantity = test.QuestionQuantity;
                    dbEntry.TestSolveTime = test.TestSolveTime;
                    dbEntry.IsAnonimous = test.IsAnonimous;
                    dbEntry.TestAvalibleTill = test.TestAvalibleTill;
                    dbEntry.UserId = test.UserId;
                    dbEntry.Questions = test.Questions;
                    dbEntry.TestSessions = test.TestSessions;
                }
                foreach (var question in test.Questions)
                {
                    context.Entry(question).State = EntityState.Modified;
                    foreach (var answer in question.Answers)
                    {
                        context.Entry(answer).State = EntityState.Modified;
                    }
                }
                foreach (var testSession in test.TestSessions)
                {
                    context.Entry(testSession).State = EntityState.Modified;
                }
                context.Entry(dbEntry).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void SaveTestSession(TestSession testSession)
        {
            if (testSession.Id == 0)
            {
                context.TestSessions.Add(testSession);
            }
            else
            {
                TestSession dbEntry = context.TestSessions.Find(testSession.Id);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = testSession.FirstName;
                    dbEntry.LastName = testSession.LastName;
                    dbEntry.Age = testSession.Age;
                    dbEntry.Email = testSession.Email;
                    dbEntry.PhoneNumber = testSession.PhoneNumber;
                    dbEntry.CorrectAnswersCount = testSession.CorrectAnswersCount;
                    dbEntry.StartExecutingTime = testSession.StartExecutingTime;
                    dbEntry.FinishExecutingTime = testSession.FinishExecutingTime;
                    dbEntry.TestId = testSession.TestId;
                }
                context.Entry(dbEntry).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void SavePersonalLink(PersonalLink personalLink)
        {
            if (personalLink.Id == 0)
            {
                context.PersonalLinks.Add(personalLink);
            }
            else
            {
                PersonalLink dbEntry = context.PersonalLinks.Find(personalLink.Id);
                if (dbEntry != null)
                {
                    dbEntry.HashedPersonalLink = personalLink.HashedPersonalLink;
                    dbEntry.UserId = personalLink.UserId;
                    dbEntry.IsActive = personalLink.IsActive;
                    dbEntry.TestId = personalLink.TestId;
                    dbEntry.TestSessionId = personalLink.TestSessionId;
                }
                context.Entry(dbEntry).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void SaveAnswer(Answer answer)
        {
            if (answer.Id == 0)
            {
                context.Answers.Add(answer);
            }
            else
            {
                Answer dbEntry = context.Answers.Find(answer.Id);


                if (dbEntry != null)
                {
                    dbEntry.AnswerContent = answer.AnswerContent;
                    dbEntry.IsCorrect = answer.IsCorrect;
                    dbEntry.QuestionId = answer.QuestionId;
                }
                context.Entry(dbEntry).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void SaveQuestion(Question question)
        {
            if (question.Id == 0)
            {
                context.Questions.Add(question);
            }
            else
            {
                Question dbEntry = context.Questions.Find(question.Id);


                if (dbEntry != null)
                {
                    dbEntry.Index = question.Index;
                    dbEntry.QuestionContent = question.QuestionContent;
                    dbEntry.TestId = question.TestId;
                }
                context.Entry(dbEntry).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Test DeleteTest(int testId)
        {
            Test dbEntry = context.Tests.Find(testId);
            if(dbEntry != null)
            {
                foreach(var question in dbEntry.Questions)
                {
                    if(question != null)
                    {
                        context.Questions.Remove(question);
                    }

                    foreach(var answer in question.Answers)
                    {
                        if(answer != null)
                        {
                            context.Answers.Remove(answer);
                        }
                    }
                }
                context.Tests.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Question DeleteQuestion(int questionId)
        {
            Question dbEntry = context.Questions.Find(questionId);
            if (dbEntry != null)
            {
                context.Questions.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Answer DeleteAnswer(int answerId)
        {
            Answer dbEntry = context.Answers.Find(answerId);
            if (dbEntry != null)
            {
                context.Answers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
