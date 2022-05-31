using QuizApp.Core.Models;
using QuizApp.Core.Repositories;

namespace QuizApp.Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuizDbContext context) : base(context)
        {
        }

        public async Task<Question> AddQuestion(Question question)
        {
            var lastQuestion = Context.Questions
                            .Where(q => q.ExamId == question.ExamId)
                            .OrderByDescending(q => q.Order).SingleOrDefault();
            question.Order = lastQuestion != null ? lastQuestion.Order + 1 : 1;

            await Context.AddAsync(question);

            return question;
        }
    }
}

