using System;
using QuizApp.Core.Enums;

namespace QuizApp.Api.Resources
{
	public class LoginResponseResource
	{
        public string Token { get; set; }
        public int Role { get; set; }
    }
}

