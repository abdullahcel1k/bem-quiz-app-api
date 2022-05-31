using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace QuizApp.Core.Models
{
	public class Question : BaseEntity
	{
        public Question()
        {
            Answers = new Collection<Answer>();
        }
        public string Label { get; set; }
        public int Order { get; set; }
        public int ExamId { get; set; }
        [JsonIgnore]
        public Exam Exam { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}

