using BLL.Interface;
using BLL.Models;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movieService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_movieService.GetById(id));
            }
          
            catch(Exception e)
            {
                return BadRequest("Exception non gérée : " + e.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Create(MovieForm m)
        {
            if (!ModelState.IsValid) return BadRequest();
            _movieService.Create(new Movie
            {
                Title = m.Title,
                Synopsis = m.Synopsis,
                ReleaseYear = m.ReleaseYear,
                PEGI = m.PEGI
            }) ;
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Movie m)
        {
            _movieService.Update(m);
            return Ok();
        }
    }
}
