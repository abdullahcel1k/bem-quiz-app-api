using System;
using QuizApp.Core.Models;

namespace QuizApp.Api.Resources
{
    public class SaveQuestionResource
    {
        public string Label { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

