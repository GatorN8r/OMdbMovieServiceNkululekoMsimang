using OpenMovieService.Infrastructure.DatabaseEntities;

namespace OpenMovieService.Infrastructure.Services
{
    public interface ICacheService
    {
        Task<CachedEntryEntity> GetOrCreateAsync(string key, Func<Task<string>> fetchFunction);
        Task<List<CachedEntryEntity>> GetAllAsync();
        Task<CachedEntryEntity?> GetByIdAsync(int id);
        Task<CachedEntryEntity> CreateAsync(CachedEntryEntity entry);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(CachedEntryEntity updated);

    }
}
