using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalcodeController : ControllerBase
    {
        private readonly GenericGetRepository<Postalcode> _postalcodeRepo;
        public PostalcodeController(GenericGetRepository<Postalcode> postalcodeRepository)
        {
            _postalcodeRepo = postalcodeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostalcodes()
        {
            var t = await _postalcodeRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<Postalcode>))]
        public async Task<IActionResult> GetPostalcode(int id)
        {
            var t = await _postalcodeRepo.GetByIdAsync(id);
            return Ok(t);
        }
    }
}
