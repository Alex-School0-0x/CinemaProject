using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IFullRepository<Movie> _movieRepo;
        public MovieController(IFullRepository<Movie> movieRepository)
        {
            _movieRepo = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var t = await _movieRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Movie>))]
        public async Task<IActionResult> GetMovie(int id)
        {
            var t = await _movieRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] Movie model)
        {
            var t = await _movieRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelIdValidationFilterAttribute<Movie>))]
        public async Task<IActionResult> PutMovie([FromBody] Movie model)
        {
            var t = await _movieRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Movie>))]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var t = await _movieRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
