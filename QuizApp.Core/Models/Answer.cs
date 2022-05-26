using System;
namespace QuizApp.Core.Models
{
	public class Answer : BaseEntity
	{
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}

