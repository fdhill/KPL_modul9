using Microsoft.AspNetCore.Mvc;
using modul9_103082400012.Models;

namespace modul9_103082400012.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movieList = new List<Movie>
        {
            new Movie(
                "The Shawshank Redemption",
                "Frank Darabont",
                new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton" },
                "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
            ),
            new Movie(
                "The Godfather",
                "Francis Ford Coppola",
                new List<string> { "Marlon Brando", "Al Pacino", "James Caan" },
                "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant youngest son."
            ),
            new Movie(
                "The Dark Knight",
                "Christopher Nolan",
                new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eckhart" },
                "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
            )
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return _movieList;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            if (id < 0 || id >= _movieList.Count)
            {
                return NotFound("Movie not found at specified index.");
            }
            return _movieList[id];
        }

        [HttpPost]
        public ActionResult Post([FromBody] Movie newMovie)
        {
            _movieList.Add(newMovie);
            return Ok("Movie added successfully.");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _movieList.Count)
            {
                return NotFound("Index not found.");
            }
            _movieList.RemoveAt(id);
            return Ok("Movie deleted successfully.");
        }
    }
}
