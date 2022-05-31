using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
	public interface IQuestionService : IBaseService<Question>
	{
		Task<IEnumerable<Question>> GetExamQuestions(int id);
		Task<Question> AddQuestionAsync(Question entity);
	}
}

