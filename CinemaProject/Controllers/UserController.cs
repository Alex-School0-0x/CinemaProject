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
        public UserController(UserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userRepo.GetAll());
        }

        [HttpGet]
        public IActionResult GetUser(int id)
        {
            return Ok(_userRepo.GetById(id));
        }

        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _userRepo.Post(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult PutUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
