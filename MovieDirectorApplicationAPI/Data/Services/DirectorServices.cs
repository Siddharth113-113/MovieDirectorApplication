using MovieDirectorApplicationAPI.Data.Model;
using MovieDirectorApplicationAPI.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.Services
{
    public class DirectorServices
    {
        private AppDataContext _context;
        public DirectorServices(AppDataContext context)
        {
            _context = context;
        }
        public void AddDirector(DirectorVM director)
        {
            var _director = new Director()
            {
                directorName = director.directorName,
                Age=director.Age,
                Gender=director.Gender,
                awardCount=director.awardCount
            };
            _context.Director.Add(_director);
            _context.SaveChanges();
        }

        public DirectorWithMovieVM GetDirectorsWithMovie(string directorName)
        {
            var _director = _context.Director.Where(n => n.directorName == directorName).Select(n => new DirectorWithMovieVM()
            {
                directorName = n.directorName,
                Age=n.Age,
                Gender=n.Gender,
                awardCount=n.awardCount,
                movieName = n.MovieDirectors.Select(n => n.Movie.movieName).ToList()
            }).FirstOrDefault();

            return _director;
        }

        public IEnumerable<DirectorWithMovieVM> GetAllDirectors()
        {
            var _directorwithMovie = _context.Director.Select(director => new DirectorWithMovieVM()
            {
                 directorName= director.directorName,
                 Age=director.Age,
                 Gender=director.Gender,
                 awardCount=director.awardCount,
                movieName = director.MovieDirectors.Select(n => n.Movie.movieName).ToList()
            }).DefaultIfEmpty();

            return _directorwithMovie;
        }

        public bool UpdateDirectorByName(string name, DirectorVM director)
        {
            var _director = _context.Director.FirstOrDefault(n => n.directorName == name);
            var _age = _director.Age;
            var _awardCount = _director.awardCount;
            if (_director != null)
            {
                _director.Age = director.Age;
                _director.awardCount = director.awardCount;
                
            }
            if(_director.Age==_age || _director.awardCount== _awardCount)
            {
                return false;
            }
            else
            {
                _context.SaveChanges();
                return true;
            }
            
        }

        public void DeleteDirectorByName(string name)
        {
            var _director = _context.Director.FirstOrDefault(n => n.directorName == name);
            if (_director != null)
            {
                _context.Director.Remove(_director);
                _context.SaveChanges();
            }

        }
    }
}
