using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IFullRepository<User> _userRepo;
        public UserController(IFullRepository<User> userRepository)
        {
            _userRepo = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var t = await _userRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<User>))]
        public async Task<IActionResult> GetUser(int id)
        {
            var t = await _userRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User model)
        {
            var t = await _userRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelIdValidationFilterAttribute<User>))]
        public async Task<IActionResult> PutUser([FromBody] User model)
        {
            var t = await _userRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<User>))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var t = await _userRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
