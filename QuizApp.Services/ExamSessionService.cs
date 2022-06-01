using System;
using QuizApp.Core;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Services
{
    public class ExamSessionService : IExamSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExamSessionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<int> CheckExamAnswers(int userId, int examId)
        {
            return _unitOfWork.ExamSessions.CheckExamAnswers(userId, examId);
        }

        public async Task<ExamSession> Create(ExamSession entity)
        {
            await _unitOfWork.ExamSessions.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public Task<ExamSession> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExamSession>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ExamSession> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

