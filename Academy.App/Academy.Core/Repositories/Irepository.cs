﻿
using Academy.Core.Models.BaseModels;
namespace Academy.Core.Repositories
{

    public interface Irepository<T> where T : BaseModel
    {
        public Task AddAsync(T  entity);
        public Task RemoveAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetAllAsync(Func<T,bool>func);
        public Task<T> GetAsync(Func<T, bool> func);

    }
}
