using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDirectorApplicationAPI.Data;
using MovieDirectorApplicationAPI.Data.Model;
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
    public class MovieDirectorController : ControllerBase
    {
        public AppDataContext _context;
        public MovieDirectorController(AppDataContext context)
        {
            _context = context;
        }
        /* public MovieDirectorServices _movieDirectorServices;
         public MovieDirectorController(MovieDirectorServices movieDirectorServices)
         {
             _movieDirectorServices = movieDirectorServices;
         }*/
        [HttpGet("movieName/{name}")]
         public IEnumerable<MovieDirectorVM> GetDirectorDetailsByMovie(string name)
         {
             var stdList = from a in _context.MovieDirector.Where(n=>n.Movie.movieName==name)
                           join b in _context.Director
                           on a.directorName equals b.directorName
                           into dep
                           from b in dep.DefaultIfEmpty()

                           select new MovieDirectorVM
                           {
                               directorName = b.directorName,
                               Age = b.Age,
                               Gender = b.Gender,
                               awardCount = b.awardCount
                           };
             return stdList;
         }

        /*  [HttpGet("movieName/{name}")]
          public IActionResult GetDirectorDetailsByMovie(string name)
          {
              var result = _movieDirectorServices.GetDirectorDetailsByMovie(name);
              return Ok(result);
          }

          [HttpGet("directorName/{name}")]
          public IActionResult GetMovieByDirector(string name)
          {
              var result = _movieDirectorServices.GetMovieByDirector(name);
              return Ok(result);
          }*/

         [HttpGet("directorName/{name}")]
          public IEnumerable<MovieDirectorVM> GetMovieByDirector(string name)
          {
             var stdList = from a in _context.MovieDirector.Where(n => n.Director.directorName == name)
                           join b in _context.Movie
                           on a.Movie.movieName equals b.movieName
                           into dep
                           from b in dep.DefaultIfEmpty()

                           select new MovieDirectorVM
                           {
                               movieName = b.movieName,
                               boxOfficeCollection = b.boxOfficeCollection,
                               Ratings = b.Ratings,
                               awardCount = a.Director.awardCount
                           };
             return stdList;
          }
     
    }
    
}