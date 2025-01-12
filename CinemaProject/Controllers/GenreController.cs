using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IFullRepository<Genre> _genreRepo;
        public GenreController(IFullRepository<Genre> genreRepository)
        {
            _genreRepo = genreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var t = await _genreRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Genre>))]
        public async Task<IActionResult> GetGenre(int id)
        {
            var t = await _genreRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> PostGenre([FromBody] Genre model)
        {
            var t = await _genreRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelIdValidationFilterAttribute<Genre>))]
        public async Task<IActionResult> PutGenre([FromBody] Genre model)
        {
            var t = await _genreRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Genre>))]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var t = await _genreRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
