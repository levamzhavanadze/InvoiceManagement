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
using WebAPIAuth.Identity;

namespace WebAPIAuth.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _user;
        private static User user = new User();
        private static VerifyPasswordHashCommand _verifyPasswordHashCommand = new VerifyPasswordHashCommand();
        private static JWTTokenCommand _jwtTokenCommand;
       
        public AuthenticationController(IConfiguration configuration, IUserRepository user)

        {
//           _configuration = configuration;
            _user = user;
            _jwtTokenCommand = new JWTTokenCommand( configuration);

        }

        [HttpPost("Register")]
        public ActionResult<User> Register(UserDto request)
        {
            CreateHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            if (request.Role != null)
            {
                user.Role = request.Role;
            }
            else
            {
                user.Role = "Consumer";
            }

            _user.AddUser(user);

            return Ok(user);
        }


        [HttpPost("login")]

        public ActionResult<string> Login(UserLoginDto request)
        {
            var logingUser = _user.GetUser(request);

            if (logingUser.Username != request.Username)
                return BadRequest("username is incorrect");
            if (!_verifyPasswordHashCommand.VerifyPasswordHash(request.Password, logingUser.PasswordHash, logingUser.PasswordSalt))
                return BadRequest("Wrong password");

            var token = _jwtTokenCommand.CreateToken(logingUser);

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

    }
}
