using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Repositories;
using QuizApp.Core.ViewModels;

namespace QuizApp.Data.Repositories
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(QuizDbContext context) : base(context)
        {
        }

        public async ValueTask<Exam> GetExamWithQuestions(int id)
        {
            return await Context.Exams
                    .Where(e => e.Id == id)
                    .Include(e => e.Questions)
                    .ThenInclude(q => q.Answers)
                    .SingleOrDefaultAsync();
        }

        public async ValueTask<ExamPageViewModel> GetBySlugAsync(string slug, int order)
        {
            var examPageVM = new ExamPageViewModel();
            examPageVM.Exam = await Context.Exams.Where(e => e.Slug == slug)
                .Include(e => e.Questions)
                .FirstAsync();
            //await Context.Exams
            //        .Where(e => e.Slug == slug)
            //        .Include(e => e.Questions.Where(q => q.Order == order))
            //        .ThenInclude(q => q.Answers)
            //        .SingleOrDefaultAsync();

            examPageVM.Question = await Context.Questions
                    .Where(q => q.ExamId == examPageVM.Exam.Id && q.Order == order)
                    .Include(q => q.Answers)
                    .FirstAsync();

            return examPageVM;
        }

        public async Task<IEnumerable<Exam>> GetExamsWithQuestions()
        {
            return await Context.Exams
                .Include(x => x.Questions)
                .ToListAsync();
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

