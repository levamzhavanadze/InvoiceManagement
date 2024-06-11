using Microsoft.AspNetCore.Mvc;
using WebAPIAuth.Interfaces;
using WebAPIAuth.Users;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace WebAPIAuth.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _user;
        private static User user = new User();
        public AuthenticationController(IConfiguration configuration, IUserRepository user)

        {
            _configuration = configuration;
            _user = user;

        }

        [HttpPost("Register")]
        public ActionResult<User> Register(UserDto request)
        {
            CreateHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = request.Role;

            _user.AddUser(user);

            return Ok(user);
        }


        //[HttpPost("CreateUser")]
        //public ActionResult<User> CreateUser(UserDto request)
        //{
        //    CreateHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
        //    user.Username = request.Username;
        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;


        //    _user.AddUser(user);

        //    return Ok(user);
        //}



        [HttpPost("login")]

        public ActionResult<string> Login(UserDto request)
        {
            var logingUser = _user.GetUser(request);

            if (logingUser.Username != request.Username)
                return BadRequest("username is incorrect");
            if (!VerifyPasswordHash(request.Password, logingUser.PasswordHash, logingUser.PasswordSalt))
                return BadRequest("Wrong password");

            var token = CreateToken(logingUser);

            return Ok(token);

        }

        [HttpGet("Users"), Authorize(Roles = "Admin")]
        public ActionResult<User> GetUsers()
        {
            var u = _user.GetAllUsers();

            return Ok(u);

        }



        private void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }



        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.Username),

            new Claim(ClaimTypes.Role,user.Role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)

        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }


    }
}
