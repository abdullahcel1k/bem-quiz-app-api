using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetAll();
        Task<Exam> CreateExam(Exam exam);
        Task<Exam> GetExamBySlug(string slug);
    }
}

