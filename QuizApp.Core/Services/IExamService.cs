using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public interface IExamService : IBaseService<Exam>
    {
        Task<Exam> GetExamBySlug(string slug, int order);
    }
}

