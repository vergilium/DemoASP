using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainAbstractions
{
    public interface IDbRepository<T>
          where T : class, IDbEntity
    {
        IQueryable<T> AllItems { get; }
        DbContext Context { get; }
        Task<List<T>> ToListAsync();
        Task<int> AddItemAsync(T item);
        Task<int> AddItemsAsync(IEnumerable<T> items);
        Task<T> GetItemAsync(int id);
        Task<bool> ChangeItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<int> SaveChangesAsync();
        Task<bool> UpdateItem(T item);
    }
}
