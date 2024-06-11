using System.Security.Claims;
using WebAPIAuth.Data;
using WebAPIAuth.Interfaces;
using WebAPIAuth.Models.Users;

namespace WebAPIAuth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        public UserRepository(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public string GetName()
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            return user;
        }


        public void AddUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }


        public void CreateUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }


        public User GetUser(UserLoginDto user)
        {
            var u = _context.users.Where(i => i.Username == user.Username).FirstOrDefault();

            return u;
        }


        public List<User> GetAllUsers() 
        {
            var users = _context.users.ToList();

            return users;
        }
    }
}
