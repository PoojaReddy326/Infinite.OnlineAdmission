using Infinite.OnlineAdmission.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Infinite.OnlineAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;
        public AccountsController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            var logu = _dbContext.admins.FirstOrDefault(a => a.Email == login.Email);
            if (logu == null)
            {
                return BadRequest("Invalid Username");
            }
            var logp = _dbContext.admins.FirstOrDefault(b => b.Password == login.Password);
            if (logp == null)
            {
                return BadRequest("Invalid Password");
            }
            var token = GenerateToken(logu);
            if (token == null)
            {
                return NotFound("Invalid Credentials");
            }

            return Ok(token);
        }
        [NonAction]
        public string GenerateToken(Admin admin)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha512);
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,admin.Email),
                new Claim(ClaimTypes.Name,admin.Password)

            };
            var token = new JwtSecurityToken(issuer: _configuration["JWT:issuer"], audience: _configuration["JWT:audience"], claims: claim, signingCredentials: credentials);
            JwtSecurityTokenHandler obj = new JwtSecurityTokenHandler();
            obj.WriteToken(token);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        [HttpGet("GetName"), Authorize]
        public IActionResult GetName()
        {
            var UserName = User.FindFirstValue(ClaimTypes.Name);
            return Ok(UserName);
        }
    }
}

