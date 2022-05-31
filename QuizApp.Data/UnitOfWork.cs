using System;
using QuizApp.Core;
using QuizApp.Core.Repositories;
using QuizApp.Data.Repositories;

namespace QuizApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizDbContext _context;
        private UserRepository _userRepository;
        private ExamRepository _examRepository;
        private QuestionRepository _questionRepository;
        private AnswerRepository _answerRepository;

        public UnitOfWork(QuizDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

        public IExamRepository Exams => _examRepository ?? new ExamRepository(_context);

        public IQuestionRepository Questions => _questionRepository ?? new QuestionRepository(_context);

        public IAnswerRepository Answers => _answerRepository ?? new AnswerRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

