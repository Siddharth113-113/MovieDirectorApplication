using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDirectorApplicationAPI.Data.Services;
using MovieDirectorApplicationAPI.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public MovieServices _movieServices;
        public MovieController(MovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = _movieServices.GetAllMovies();
            return Ok(allMovies);
        }

        [HttpGet("{Id}")]
        public IActionResult GetMovieById(int Id)
        {
            var movie = _movieServices.GetMovieById(Id);
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieWithDirectorVM movie)
        {
            _movieServices.AddMovieWithDirectors(movie);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateMovieById(int Id, [FromBody] MovieVM movie)
        {
            var updateMovie = _movieServices.UpdateMovieById(Id, movie);
            return Ok(updateMovie);
        }

        [HttpDelete("{Name}")]
        public IActionResult DeleteMovieByName(string Name)
        {
            try
            {
                if(_movieServices.DeleteMovieByName(Name))
                {
                    return Ok("Movie Details Are Deleted");
                }
                else
                {
                    throw new MovieNotPresentException("Movie Is Not Present");
                }
            }
            catch(MovieNotPresentException ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }
    }

    public class MovieNotPresentException:Exception
    {
        public MovieNotPresentException(string Message):base(Message)
        {

        }
    }
}
