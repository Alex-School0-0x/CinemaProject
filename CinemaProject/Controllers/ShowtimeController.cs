using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowtimeController : ControllerBase
    {
        private readonly GenericFullRepository<Showtime> _showtimeRepo;
        public ShowtimeController(GenericFullRepository<Showtime> showtimeRepository)
        {
            _showtimeRepo = showtimeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetShowtimes()
        {
            var t = await _showtimeRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Showtime>))]
        public async Task<IActionResult> GetShowtime(int id)
        {
            var t = await _showtimeRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Showtime>))]
        public async Task<IActionResult> PostShowtime([FromBody] Showtime model)
        {
            var t = await _showtimeRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Showtime>))]
        public async Task<IActionResult> PutShowtime([FromBody] Showtime model)
        {
            var t = await _showtimeRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Showtime>))]
        public async Task<IActionResult> DeleteShowtime(int id)
        {
            var t = await _showtimeRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
