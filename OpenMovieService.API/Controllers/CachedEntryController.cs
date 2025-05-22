using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OpenMovieService.Infrastructure.DatabaseEntities;
using OpenMovieService.Infrastructure.Services;

namespace OpenMovieService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CachedEntryController : ODataController
    {
        private readonly ICacheService _cacheService;

        public CachedEntryController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [EnableQuery]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var entries = await _cacheService.GetAllAsync();
            return Ok(entries);
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entry = await _cacheService.GetByIdAsync(id);
            if (entry == null) return NotFound();
            return Ok(entry);
        }

        [EnableQuery]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CachedEntryEntity entry)
        {
            if (entry == null) return BadRequest("Entry cannot be null.");
            var createdEntry = await _cacheService.CreateAsync(entry);
            return CreatedAtAction(nameof(GetById), new { id = createdEntry.Id }, createdEntry);
        }

        [EnableQuery]
        [HttpPost]
        [Route("bulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<CachedEntryEntity> entries)
        {
            if (entries == null || !entries.Any()) return BadRequest("Entries cannot be null or empty.");
            var createdEntries = new List<CachedEntryEntity>();
            foreach (var entry in entries)
            {
                var createdEntry = await _cacheService.CreateAsync(entry);
                createdEntries.Add(createdEntry);
            }
            return CreatedAtAction(nameof(GetAll), createdEntries);
        }


        [EnableQuery]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CachedEntryEntity updatedEntry)
        {
            if (updatedEntry == null) return BadRequest("Updated entry cannot be null.");
            var existingEntry = await _cacheService.GetByIdAsync(id);
            if (existingEntry == null) return NotFound();
            updatedEntry.Id = id;
            var result = await _cacheService.UpdateAsync(updatedEntry);
            return Ok(result);
        }

        [EnableQuery]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cacheService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
