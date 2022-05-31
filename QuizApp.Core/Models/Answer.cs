using System;
using System.Text.Json.Serialization;

namespace QuizApp.Core.Models
{
    public class Answer : BaseEntity
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
    }
}

