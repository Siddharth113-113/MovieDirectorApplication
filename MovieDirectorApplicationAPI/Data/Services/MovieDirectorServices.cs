using MovieDirectorApplicationAPI.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.Services
{
    public class MovieDirectorServices
    {
        private AppDataContext _context;
        public MovieDirectorServices(AppDataContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieDirectorVM> GetDirectorDetailsByMovie(string name)
        {
            var stdList = from a in _context.MovieDirector.Where(n => n.Movie.movieName == name)
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
