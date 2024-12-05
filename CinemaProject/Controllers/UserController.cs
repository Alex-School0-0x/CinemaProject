using CinemaProject.Models;
using CinemaProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepo;
        private readonly Type _type = typeof(User);
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
        public async Task<IActionResult> GetUser(int id)
        {
            var t = await _userRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm] User user)
        {
            var t = await _userRepo.PostAsync(user);
            return Ok(t);
        }

        [HttpPut]
        public IActionResult PutUser([FromForm] User user)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task<IActionResult> DeleteUser([FromForm] User user)
        {
            throw new NotImplementedException();
        }
    }
}
