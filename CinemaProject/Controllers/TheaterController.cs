using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly IFullRepository<Theater> _theaterRepo;
        public TheaterController(IFullRepository<Theater> theaterRepository)
        {
            _theaterRepo = theaterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTheaters()
        {
            var t = await _theaterRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Theater>))]
        public async Task<IActionResult> GetTheater(int id)
        {
            var t = await _theaterRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> PostTheater([FromBody] Theater model)
        {
            var t = await _theaterRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelIdValidationFilterAttribute<Theater>))]
        public async Task<IActionResult> PutTheater([FromBody] Theater model)
        {
            var t = await _theaterRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Theater>))]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            var t = await _theaterRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
