using MovieDirectorApplicationAPI.Data.Model;
using MovieDirectorApplicationAPI.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.Services
{
    public class MovieServices
    {
        private AppDataContext _context;
        public MovieServices(AppDataContext context)
        {
            _context = context;
        }

        public void AddMovieWithDirectors(MovieWithDirectorVM movie)
        {
            var _movie = new Movie()
            {
               
                movieName = movie.movieName,
                boxOfficeCollection = movie.boxOfficeCollection,
                Ratings = movie.Ratings,
               
            };
            _context.Movie.Add(_movie);
            _context.SaveChanges();

            foreach (var name in movie.directorName)
            {
                var _movie_director = new MovieDirector()
                {
                    movieId = _movie.movieId,
                    directorName = name
                };
                _context.MovieDirector.Add(_movie_director);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MovieWithDirectorVM> GetAllMovies()
        {
            var _moviewithDirector = _context.Movie.Select(movie => new MovieWithDirectorVM()
            {
                movieId = movie.movieId,
                movieName = movie.movieName,
                boxOfficeCollection = movie.boxOfficeCollection,
                Ratings = movie.Ratings,
                directorName = movie.MovieDirectors.Select(n => n.Director.directorName).ToList()
            }).DefaultIfEmpty();

            return _moviewithDirector;
        }
        public MovieWithDirectorVM GetMovieById(int movieId)
        {
            var _moviewithdirector = _context.Movie.Where(n => n.movieId == movieId).Select(movie => new MovieWithDirectorVM()
            {
                movieId = movie.movieId,
                movieName = movie.movieName,
                boxOfficeCollection = movie.boxOfficeCollection,
                Ratings = movie.Ratings,
                directorName = movie.MovieDirectors.Select(n => n.Director.directorName).ToList()
            }).FirstOrDefault();
            return _moviewithdirector;

        }

        public Movie UpdateMovieById(int Id, MovieVM movie)
        {
            var _movie = _context.Movie.FirstOrDefault(n => n.movieId == Id);
            if (_movie != null)
            {
               
                _movie.movieName = movie.movieName;
                _movie.boxOfficeCollection = movie.boxOfficeCollection;
                _movie.Ratings = movie.Ratings;


                _context.SaveChanges();
            }
            return _movie;
        }

        public bool DeleteMovieByName(string movieName)
        {

            var _movie = _context.Movie.FirstOrDefault(n => n.movieName == movieName);
            if (_movie != null)
            {
                _context.Movie.Remove(_movie);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
