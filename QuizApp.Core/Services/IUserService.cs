using System;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
	public interface IUserService
	{
		Task<IEnumerable<User>> GetAll();
		Task<User> GetUserByEmail(string email);
		Task<User> GetById(int id);
		Task<User> CreateUser(User newUser);
	}
}

