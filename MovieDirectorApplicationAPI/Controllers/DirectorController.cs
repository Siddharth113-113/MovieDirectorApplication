using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class DirectorController : ControllerBase
    {
        private DirectorServices _directorServices;
        public DirectorController(DirectorServices directorServices)
        {
            _directorServices = directorServices;
        }

        [HttpGet]
        public IActionResult GetAllDirector()
        {
            var allDirectors = _directorServices.GetAllDirectors();
            return Ok(allDirectors);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] DirectorVM director)
        {
            _directorServices.AddDirector(director);
            return Ok();
        }

        [HttpGet("{directorName}")]
        public IActionResult GetDirectorWithMovie(string directorName)
        {
            var response = _directorServices.GetDirectorsWithMovie(directorName);
            return Ok(response);
        }
        [HttpPut("{Name}")]
        public IActionResult UpdateDirectorByName(string Name, [FromBody] DirectorVM director)
        {
            try
            {
                var updateDirector = _directorServices.UpdateDirectorByName(Name, director);
                if (updateDirector==true)
                {
                    return Ok(updateDirector);
                }
                else
                {
                    throw new DirectorPresentException("Director Details Already Exist");
                    
                }
            }
            catch(DirectorPresentException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{Name}")]
        public IActionResult DeleteMovieById(string Name)
        {
            _directorServices.DeleteDirectorByName(Name);
            return Ok();
        }
    }

    public class DirectorPresentException:Exception
    {
        public DirectorPresentException(string Message):base(Message)
        {

        }
    }

}
