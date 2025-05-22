using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMovieService.Infrastructure.DatabaseEntities
{
    public class CachedEntryEntity
    {
        public CachedEntryEntity(string key, string value, DateTime expirationDate)
        {
            Key = key;
            Value = value;
            ExpirationDate = expirationDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
       
    }
}
