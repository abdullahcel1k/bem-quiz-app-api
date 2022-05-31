using System;
namespace QuizApp.Api.Resources
{
	public class AnswerResource
	{
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}

