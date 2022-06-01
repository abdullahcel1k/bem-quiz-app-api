using System;
namespace QuizApp.Core.Models
{
	public class ExamSession : BaseEntity
	{
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

