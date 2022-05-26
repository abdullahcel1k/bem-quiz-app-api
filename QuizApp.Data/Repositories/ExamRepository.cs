using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Repositories;

namespace QuizApp.Data.Repositories
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(QuizDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Exam>> GetQuizAllQuestionWithAnswers(int id)
        {
            return await Context.Exams
                .Where(e => e.Id == id)
                .Include(e => e.Questions)
                .ThenInclude(q => q.Answers)
                .ToListAsync();
        }
    }
}

