using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Repositories
{
    public interface IExamRepository : IRepository<Exam>
    {
        Task<IEnumerable<Exam>> GetQuizAllQuestionWithAnswers(int id);
        Task<IEnumerable<Exam>> GetExamsWithQuestions();
        ValueTask<Exam> GetBySlugAsync(string slug, int order);
        ValueTask<Exam> GetExamWithQuestions(int id);
    }
}

