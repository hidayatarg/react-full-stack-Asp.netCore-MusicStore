using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DataAccess.Abstruct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Backend.Dtos;
using Backend.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        // Dependency Injection
        private IAuthRepository _authRepository;

        // Private key from appsetting.json
        private IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            // check if the user exists
            if (await _authRepository.UserExits(userRegisterDto.UserName))
            {
                ModelState.AddModelError(userRegisterDto.UserName, "Username already exits");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new User
            {
                UserName = userRegisterDto.UserName,
                UserRole = userRegisterDto.UserRole
                // Other Information Regarding to User
            };

            // Create user
            var createdUser = await _authRepository.Register(userToCreate, userRegisterDto.Password);
            return StatusCode(201);
        }

    }
}