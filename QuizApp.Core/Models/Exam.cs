using System;
using System.Collections.ObjectModel;
using QuizApp.Core.Helpers;

namespace QuizApp.Core.Models
{
	public class Exam : BaseEntity
	{
        public Exam()
        {
            Questions = new Collection<Question>();
        }

        public string Name { get; set; }
        public string? Slug { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}

