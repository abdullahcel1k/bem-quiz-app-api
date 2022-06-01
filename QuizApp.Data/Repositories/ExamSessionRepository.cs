using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Repositories;

namespace QuizApp.Data.Repositories
{
    public class ExamSessionRepository : Repository<ExamSession>, IExamSessionRepository
    {
        public ExamSessionRepository(QuizDbContext context) : base(context)
        {
        }

        public async Task<int> CheckExamAnswers(int userId, int examId)
        {
            return Context.ExamSessions
                .Where(es => es.UserId == userId)
                .Include(es => es.Answer)
                .ThenInclude(a => a.Question)
                .ThenInclude(q => q.Exam)
                .Where(exs => exs.Answer.Question.ExamId == examId).Count();
        }
    }
}

