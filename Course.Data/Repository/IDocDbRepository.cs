using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Course.Data.Repository
{
    public interface IDocDbRepository<T> where T : class
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task CreateItemAsync(T item);
        Task<T> UpdateItemAsync(string id, T item);
        Task DeleteItemAsync(string id);
        void Initialize();
    }
}
