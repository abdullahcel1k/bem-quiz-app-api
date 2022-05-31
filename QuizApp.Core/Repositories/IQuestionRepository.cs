using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> AddQuestion(Question question);
    }
}

