using System.Security.Cryptography;
using System.Text;

namespace WebAPIAuth.Identity
{
    public class VerifyPasswordHashCommand
    {
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)

        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }

    }
}
