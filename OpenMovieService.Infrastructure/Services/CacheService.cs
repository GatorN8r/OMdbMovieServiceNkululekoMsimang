using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OpenMovieService.Infrastructure.Data;
using OpenMovieService.Infrastructure.DatabaseEntities;
using System;

namespace OpenMovieService.Infrastructure.Services
{
    public class CacheService: ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly DataContext _dbContext;
        public CacheService(IMemoryCache memoryCache, DataContext dbContext)
        {
            _memoryCache = memoryCache;
            _dbContext = dbContext;
        }

        public async Task<CachedEntryEntity> GetOrCreateAsync(string key, Func<Task<string>> fetchFunction)
        {
            if (_memoryCache.TryGetValue(key, out string cachedValue))
            {
                return new CachedEntryEntity(key, cachedValue, DateTime.UtcNow.AddMinutes(10));
            }

            var value = await fetchFunction();

            _memoryCache.Set(key, value, TimeSpan.FromMinutes(10)); // cache it

            var entry = new CachedEntryEntity (key, value, DateTime.UtcNow.AddMinutes(10));
            _dbContext.CachedEntries.Add(entry);
            await _dbContext.SaveChangesAsync();

            return entry;
        }

        public async Task<List<CachedEntryEntity>> GetAllAsync() => await _dbContext.CachedEntries.ToListAsync();

        public async Task<CachedEntryEntity?> GetByIdAsync(int id) => await _dbContext.CachedEntries.FindAsync(id);

        public async Task<CachedEntryEntity> CreateAsync(CachedEntryEntity entry)
        {
            _dbContext.CachedEntries.Add(entry);
            _memoryCache.Set(entry.Key, entry.Value, TimeSpan.FromMinutes(10));
            await _dbContext.SaveChangesAsync();
            return entry;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entry = await _dbContext.CachedEntries.FindAsync(id);
            if (entry == null) return false;
            _dbContext.CachedEntries.Remove(entry);
            _memoryCache.Remove(entry.Key);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(CachedEntryEntity updated)
        {
            var existing = await _dbContext.CachedEntries.FindAsync(updated.Id);
            if (existing == null) return false;

            existing.Key = updated.Key;
            existing.Value = updated.Value;

            _memoryCache.Set(updated.Key, updated.Value, TimeSpan.FromMinutes(10));
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
