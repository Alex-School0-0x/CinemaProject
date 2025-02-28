﻿using CinemaProject.Models;
using CinemaProject.Filters;
using CinemaProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IFullRepository<Address> _addressRepo;
        public AddressController(IFullRepository<Address> addressRepository)
        {
            _addressRepo = addressRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresss()
        {
            var t = await _addressRepo.GetAllAsync();
            return Ok(t);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Address>))]
        public async Task<IActionResult> GetAddress(int id)
        {
            var t = await _addressRepo.GetByIdAsync(id);
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress([FromBody] Address model)
        {
            var t = await _addressRepo.PostAsync(model);
            return Ok(t);
        }

        [HttpPut]
        [ServiceFilter(typeof(ModelIdValidationFilterAttribute<Address>))]
        public async Task<IActionResult> PutAddress([FromBody] Address model)
        {
            var t = await _addressRepo.PutAsync(model);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(IdValidateFilterAttribute<Address>))]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var t = await _addressRepo.DeleteAsync(id);
            return Ok(t);
        }
    }
}
