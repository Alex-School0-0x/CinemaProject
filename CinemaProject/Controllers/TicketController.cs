using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly GenericFullRepository<Ticket> _ticketRepo;
        public TicketController(GenericFullRepository<Ticket> ticketRepository)
        {
            _ticketRepo = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var t = await _ticketRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Ticket>))]
        public async Task<IActionResult> GetTicket(int id)
        {
            var t = await _ticketRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Ticket>))]
        public async Task<IActionResult> PostTicket([FromBody] Ticket model)
        {
            var t = await _ticketRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Ticket>))]
        public async Task<IActionResult> PutTicket([FromBody] Ticket model)
        {
            var t = await _ticketRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Ticket>))]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var t = await _ticketRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
