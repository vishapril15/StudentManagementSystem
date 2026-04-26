using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentManagementSystem.Common;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            Log.Information("Login attempt for user {Username}", dto.Username);

            if (dto.Username == "admin" && dto.Password == "123")
            {
                var token = JwtHelper.GenerateToken(
                    _config["Jwt:Key"],
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"]
                );

                return Ok(new ApiResponse<object>(
                    true,
                    "Login successful",
                    new { token }
                ));
            }

            Log.Warning("Invalid login attempt for user {Username}", dto.Username);

            return Unauthorized(new ApiResponse<object>(
                false,
                "Invalid credentials",
                null
            ));
        }
    }
}
