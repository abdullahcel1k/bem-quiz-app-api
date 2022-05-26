using System;
namespace QuizApp.Core.Models
{
	public class BaseEntity
	{
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime UpdatedTim { get; set; } = DateTime.Now;
    }
}

