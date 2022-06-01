using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Repositories
{
    public interface IExamSessionRepository : IRepository<ExamSession>
    {
        Task<int> CheckExamAnswers(int userId, int examId);
    }
}

