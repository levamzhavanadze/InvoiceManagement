namespace WebAPIAuth.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string? RefreshToken { get; set; }
        public string Role { get; set; } = "Consumer";

        public DateTime Created { get; set; }

        public DateTime Expires { get; set; }

    }
}
