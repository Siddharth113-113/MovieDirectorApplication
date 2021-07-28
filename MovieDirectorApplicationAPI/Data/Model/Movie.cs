using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.Model
{
    public class Movie
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public int boxOfficeCollection { get; set; }
        public byte Ratings { get; set; }

        //Nav

        public List<MovieDirector> MovieDirectors { get; set; }
    }
}
