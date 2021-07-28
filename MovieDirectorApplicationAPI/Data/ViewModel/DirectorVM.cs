using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.ViewModel
{
    public class DirectorVM
    {
        public string directorName { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public byte awardCount { get; set; }
        //Nav
      
    }

    public class DirectorWithMovieVM
    {
       
        public string directorName { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public byte awardCount { get; set; }
        public List<string> movieName { get; set; }
    }
}
