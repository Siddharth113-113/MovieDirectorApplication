using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.ViewModel
{
    public class MovieVM
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public int boxOfficeCollection { get; set; }
        public byte Ratings { get; set; }
       
    }

   public class MovieWithDirectorVM
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public int boxOfficeCollection { get; set; }
        public byte Ratings { get; set; }
        public List<string> directorName { get; set; }
    }
}
