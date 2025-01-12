using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IFullRepository<Hall> _hallRepo;
        public HallController(IFullRepository<Hall> hallRepository)
        {
            _hallRepo = hallRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHalls()
        {
            var t = await _hallRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Hall>))]
        public async Task<IActionResult> GetHall(int id)
        {
            var t = await _hallRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> PostHall([FromBody] Hall model)
        {
            var t = await _hallRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelIdValidationFilterAttribute<Hall>))]
        public async Task<IActionResult> PutHall([FromBody] Hall model)
        {
            var t = await _hallRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Hall>))]
        public async Task<IActionResult> DeleteHall(int id)
        {
            var t = await _hallRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
