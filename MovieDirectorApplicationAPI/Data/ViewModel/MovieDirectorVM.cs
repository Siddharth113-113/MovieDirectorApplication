using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.ViewModel
{
    public class MovieDirectorVM
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public int boxOfficeCollection { get; set; }
        public byte Ratings { get; set; }
        public string directorName { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public byte awardCount { get; set; }
    }
}
