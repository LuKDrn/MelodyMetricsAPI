using MelodyMetrics.Domain.Entities.Artists;
using MelodyMetrics.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MelodyMetrics.Api.Controllers.Artists
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController(MelodyMetricsDbContext dbContext) : ControllerBase
    {
        // GET: api/<ArtistController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = await dbContext.Artists.Find(Builders<Artist>.Filter.Empty).ToListAsync();
            return Ok(artists);
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var artists = await dbContext.Artists.Find(Builders<Artist>.Filter.Empty).ToListAsync();
            var artist = artists[id];
            return Ok(artist);
        }

        // POST api/<ArtistController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Artist artist)
        {
            artist.Id = Guid.NewGuid();
            artist.ArtistId = Guid.NewGuid().ToString();
            await dbContext.Artists.InsertOneAsync(artist);
            return CreatedAtAction(nameof(Artist), artist);
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dbContext.Artists.DeleteOneAsync(id);
            return NoContent();
        }
    }
}
