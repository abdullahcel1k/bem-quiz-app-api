using System;
using System.Collections.ObjectModel;

namespace QuizApp.Core.Models
{
	public class Question : BaseEntity
	{
        public Question()
        {
            Answers = new Collection<Answer>();
        }
        public string Text { get; set; }
        public Exam Exam { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}

