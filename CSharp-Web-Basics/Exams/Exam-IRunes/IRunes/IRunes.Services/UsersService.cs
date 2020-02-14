namespace IRunes.Services
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using SIS.MvcFramework;
    using Contracts;
    using Data;
    using Models;

    public class UsersService : IUsersService
    {
        private readonly RunesDbContext data;

        public UsersService(RunesDbContext data)
        {
            this.data = data;
        }

        public void Create(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = this.Hash(password),
                Email = email,
                Role = IdentityRole.User
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public string GetId(string username, string password)
        {
            var hashedPassword = this.Hash(password);

            var id = this.data.Users
                .Where(u => (u.Username == username || u.Email == username)
                            && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return id;
        }

        public string GetUsername(string id)
            => this.data.Users
                .Where(u => u.Id == id)
                .Select(u => u.Username)
                .FirstOrDefault();

        public bool IsUsernameUsed(string username)
            => this.data.Users.Any(u => u.Username == username);

        public bool IsEmailUsed(string email)
            => this.data.Users.Any(u => u.Email == email);

        private string Hash(string password)
        {
            var hashedPassword = new StringBuilder();
            var crypt = new SHA256Managed();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hashedPassword.Append(theByte.ToString("x2"));
            }

            return hashedPassword.ToString();
        }
    }
}