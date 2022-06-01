using System;
using QuizApp.Core.Models;
using QuizApp.Core.ViewModels;

namespace QuizApp.Core.Services
{
    public interface IExamService : IBaseService<Exam>
    {
        Task<ExamPageViewModel> GetExamBySlug(string slug, int order);
    }
}

