using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
	public interface IExamSessionService : IBaseService<ExamSession>
	{
		Task<int> CheckExamAnswers(int userId, int examId);
	}
}

