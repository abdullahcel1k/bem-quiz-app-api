using System;
using QuizApp.Core.Repositories;

namespace QuizApp.Core
{
	public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        IExamSessionRepository ExamSessions { get; }
        Task<int> CommitAsync();
    }
}

