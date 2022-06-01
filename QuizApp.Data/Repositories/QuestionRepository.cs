using Microsoft.EntityFrameworkCore;
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
            try
            {
                var lastQuestion = await Context.Questions
                            .Where(q => q.ExamId == question.ExamId)
                            .OrderByDescending(q => q.Order)
                            .Take(1)
                            .SingleOrDefaultAsync();
                question.Order = lastQuestion != null ? lastQuestion.Order + 1 : 1;

                await Context.AddAsync(question);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return question;
        }
    }
}

