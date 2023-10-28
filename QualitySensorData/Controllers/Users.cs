using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QualitySensorData.Data;
using QualitySensorData.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QualitySensorData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly QualitySensorDbContext _dbContext;
        public Users(QualitySensorDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("/[controller]/Login")]
        public IActionResult Login([FromBody] User obj)
        {
            try 
            {
                var currentUser = _dbContext.Users.FirstOrDefault(u => u.empId == obj.empId && u.password == obj.password);
                if (currentUser == null)
                {
                    return NotFound();
                }
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(ClaimTypes.Email , currentUser.email)
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(jwt);
            }
            catch (Exception ex) 
            {
                return StatusCode(404);
            }

        }
        [HttpPost]
        [Route("/[controller]/Register")]
        public IActionResult Register([FromBody] User user)
        {
            var userExists = _dbContext.Users.FirstOrDefault(u => u.empId == user.empId);
            if (userExists != null)
            {
                return BadRequest("User with same email already exists");
            }
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<User> GetUser(int empId, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.empId == empId && u.password == password);
        }
    }
}
