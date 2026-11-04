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

        //Post api/<SongsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Song>Post([FromBody] Song song)
        {
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }
            Song addedSong = _songsRepo.AddSong(song);
            return StatusCode(StatusCodes.Status201Created, addedSong);
        }  

        // POST api/<SongsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("search")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Song> Delete(int id)
        {
            Song? removedSong = _songsRepo.DeleteSong(id);
            if (removedSong == null)
            {
                return NotFound("Song not found with ID: " + id);
            }
            return Ok(removedSong);
        }
    }
}
