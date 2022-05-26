using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Repositories;

namespace QuizApp.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(QuizDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

