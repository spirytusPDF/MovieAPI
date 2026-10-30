using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Contracts;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(MovieService movieService) : ControllerBase
    {
        private readonly MovieService _movieService = movieService;

        [HttpGet("all")]
        public ActionResult<List<MovieResponse>> GetAll()
        {
            return Ok(_movieService.GetMovies().Select(m => new MovieResponse()
            {
                Title = m.Title,
                Description = m.Description,
                Genre = m.Genre,
                Rating = m.Rating,
                ImageUrl = m.ImageUrl??""
            }));
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<MovieResponse> GetOne(int id)
        {
            var movie = _movieService.GetOneMovie(id);
            if (movie == null || movie.Title == string.Empty) return NotFound("Movie not found");
            return Ok(new MovieResponse()
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Rating = movie.Rating,
                ImageUrl = movie.ImageUrl ?? ""
            });
        }

        [HttpGet("/search")]
        public ActionResult<List<MovieResponse>> SearchMovies([FromQuery] string key)
        {
            return Ok(_movieService.SearchMovies(key).Select(m => new MovieResponse()
            {
                Title = m.Title,
                Description = m.Description,
                Genre = m.Genre,
                Rating = m.Rating,
                ImageUrl = m.ImageUrl ?? ""
            }));
        }

        [HttpPost]
        public ActionResult<string> AddMovie([FromBody] CreateMovieRequest movie)
        {
            var result = _movieService.AddMovie(new Models.Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre
            });
            if (result.IsSuccess) return Ok(result.Message);
            else return BadRequest(result.Message);
        }
        [HttpPut("/update/{id:int:min(1)}")]
        public ActionResult<string> UpdateMovie([FromBody] UpdateMovieRequest movie, [FromRoute] int id)
        {
            var result = _movieService.UpdateMovie(new Models.Movie()
            {
                Id = id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Rating = movie.Rating,
                ImageUrl = movie.ImageUrl ?? ""
            });
            if (result.IsSuccess) return Ok(result.Message);
            else return BadRequest(result.Message);
        }

        [HttpDelete("/delete/{id:int:min(1)}")]
        public ActionResult<string> DeleteMovie([FromRoute] int id)
        {
            var result = _movieService.DeleteMovie(id);
            if (result.IsSuccess) return Ok(result.Message);
            else return BadRequest(result.Message);
        }
    }
}
