namespace WebAPIAuth.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string? RefreshToken { get; set; }

        public string Role { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expires { get; set; }

    }
}
