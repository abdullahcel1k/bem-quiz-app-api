using QuizApp.Core.Models;

namespace QuizApp.Core.Repositories
{
	public interface IUserRepository: IRepository<User>
	{
		Task<User> GetUserByEmail(string email);
	}
}

