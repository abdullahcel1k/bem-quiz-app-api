using System;
using QuizApp.Core.Enums;

namespace QuizApp.Api.Resources
{
	public class SaveUserResource
	{
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}

