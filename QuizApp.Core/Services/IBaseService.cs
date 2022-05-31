using System;
namespace QuizApp.Core.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Delete(int id);
        Task<T> Create(T entity);
    }
}

