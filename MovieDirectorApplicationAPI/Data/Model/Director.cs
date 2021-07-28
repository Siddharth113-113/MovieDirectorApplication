using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPI.Data.Model
{
    public class Director
    {
        [Key]
        public string directorName { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public byte awardCount { get; set; }
        //Nav
        public List<MovieDirector> MovieDirectors { get; set; }
    }
}
