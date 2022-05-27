using System;
using QuizApp.Core.Enums;

namespace QuizApp.Core.Models
{
	public class User : BaseEntity
	{
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public UserRole Role { get; set; }
    }
}

