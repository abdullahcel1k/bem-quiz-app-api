using System;
using QuizApp.Core;
using QuizApp.Core.Helpers;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Question> Create(Question entity)
        {
            await _unitOfWork.Questions.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<Question> AddQuestionAsync(Question entity)
        {
            await _unitOfWork.Questions.AddQuestion(entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public Task<Question> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetExamQuestions(int id)
        {
            _unitOfWork.Questions.Find(x => x.ExamId == id);

            return null;
        }
    }
}

