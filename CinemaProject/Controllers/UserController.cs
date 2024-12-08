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
        private readonly UserRepository _userRepo;
        public UserController(UserRepository userRepository)
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
        public async Task<IActionResult> PostUser([FromForm] User model)
        {
            var t = await _userRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<User>))]
        public async Task<IActionResult> PutUser([FromForm] User model)
        {
            var t = await _userRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete]
        [ServiceFilter(typeof(ModelValidateFilterAttribute<User>))]
        public Task<IActionResult> DeleteUser([FromForm] User model)
        {
            throw new NotImplementedException();
        }
    }
}
