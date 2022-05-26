using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Repositories
{
	public interface IExamRepository : IRepository<Exam>
	{
		Task<IEnumerable<Exam>> GetQuizAllQuestionWithAnswers(int id);
	}
}

