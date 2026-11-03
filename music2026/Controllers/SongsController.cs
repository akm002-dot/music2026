using Microsoft.AspNetCore.Mvc;
using music2026.Interfaces;
using music2026.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace music2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ISongsRepo _songsRepo;

        public SongsController(ISongsRepo songsRepo)
        {
            _songsRepo = songsRepo;
        }

        // GET: api/<SongsController>
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Song>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, _songsRepo.GetAllSongs());
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<SongsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<IEnumerable<Song>> SearchSongs(string property, string text)
        {
            if (string.IsNullOrEmpty(property) || string.IsNullOrEmpty(text))
            {
                return BadRequest("Property and text parameters are required.");
            }
            var searchedSongs = _songsRepo.SearchSongs(property, text);
            return StatusCode(StatusCodes.Status200OK, searchedSongs);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
