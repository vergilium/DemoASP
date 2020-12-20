using DomainAbstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainRepositories
{
    public class DbRepository<T> : IDbRepository<T> where T : class, IDbEntity
    {
        DbContext _context;

        public DbRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> AllItems => _context.Set<T>();
        public DbContext Context => _context;

        public async Task<List<T>> ToListAsync()
        {
            return await AllItems.ToListAsync();
        }
        public async Task<int> AddItemAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await SaveChangesAsync();
        }
        public async Task<int> AddItemsAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
            return await SaveChangesAsync();
        }
        public async Task<T> GetItemAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<bool> ChangeItemAsync(T item)
        {
            T changed = await GetItemAsync(item.Id);
            if (changed == null) return false;
            changed = item;
            return await SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItem(T item)
        {
            _context.Set<T>().Update(item);
            return await SaveChangesAsync() > 0;
        }

        async public Task<bool> DeleteItemAsync(int id)
        {
            T item = await _context.Set<T>().FindAsync(id);
            if (item == null)
                return false;
            _context.Set<T>().Remove(item);
            return await SaveChangesAsync() > 0;
        }

        async public Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
#pragma warning disable 0168
            catch (Exception e)
#pragma warning restore 0168
            {
                return -1;
            }
        }


    }
}
