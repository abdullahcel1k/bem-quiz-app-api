using System;
using QuizApp.Core.Models;
using QuizApp.Core.ViewModels;

namespace QuizApp.Core.Repositories
{
    public interface IExamRepository : IRepository<Exam>
    {
        Task<IEnumerable<Exam>> GetQuizAllQuestionWithAnswers(int id);
        Task<IEnumerable<Exam>> GetExamsWithQuestions();
        ValueTask<ExamPageViewModel> GetBySlugAsync(string slug, int order);
        ValueTask<Exam> GetExamWithQuestions(int id);
    }
}

