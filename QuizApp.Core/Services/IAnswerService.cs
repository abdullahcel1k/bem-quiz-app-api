using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public interface IAnswerService : IBaseService<Answer>
    {
        Task<IEnumerable<Answer>> AddMultiple(IEnumerable<Answer> answers);
    }
}

