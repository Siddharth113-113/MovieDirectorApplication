using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.Model
{
    public class MovieDirector
    {
        public int Id { get; set; }

        public int movieId { get; set; }
        public Movie Movie { get; set; }


        public string directorName { get; set; }
        public Director Director { get; set; }
    }
}
