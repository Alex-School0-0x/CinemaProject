using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly GenericFullRepository<Seat> _seatRepo;
        public SeatController(GenericFullRepository<Seat> seatRepository)
        {
            _seatRepo = seatRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeats()
        {
            var t = await _seatRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Seat>))]
        public async Task<IActionResult> GetSeat(int id)
        {
            var t = await _seatRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Seat>))]
        public async Task<IActionResult> PostSeat([FromBody] Seat model)
        {
            var t = await _seatRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Seat>))]
        public async Task<IActionResult> PutSeat([FromBody] Seat model)
        {
            var t = await _seatRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Seat>))]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var t = await _seatRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
