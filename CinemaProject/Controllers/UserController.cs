using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GenericFullRepository<User> _userRepo;
        public UserController(GenericFullRepository<User> userRepository)
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
        [ServiceFilter(typeof(ModelValidateFilterAttribute<User>))]
        public async Task<IActionResult> GetUser(int id)
        {
            var t = await _userRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<User>))]
        public async Task<IActionResult> PostUser([FromBody] User model)
        {
            var t = await _userRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<User>))]
        public async Task<IActionResult> PutUser([FromBody] User model)
        {
            var t = await _userRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<User>))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var t = await _userRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
