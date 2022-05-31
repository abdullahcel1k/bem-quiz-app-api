using System;
using QuizApp.Core;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Answer>> AddMultiple(IEnumerable<Answer> answers)
        {
            await _unitOfWork.Answers.AddRangeAsync(answers);
            await _unitOfWork.CommitAsync();

            return answers;
        }

        public Task<Answer> Create(Answer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Answer> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Answer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Answer> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

