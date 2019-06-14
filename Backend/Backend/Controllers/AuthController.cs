using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DataAccess.Abstruct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Backend.Dtos;
using Backend.Entities;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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

        [HttpPost("Login")]
        public async Task<IActionResult> Login ([FromBody] UserLoginDto userLoginDto)
        {
            // check if the user exists
            var user = await _authRepository.Login(userLoginDto.UserName, userLoginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            // User available return JWT Token 
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate token with private key in appsetting.json
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            // User Authorization Mechanism For Controlling
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    //new Claim(ClaimTypes.Role, role),
                    //new Claim("group",user.GroupName),

             }),
                // Set token validity
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            // Creating Token according to tokenDescriptor
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }

    }
}