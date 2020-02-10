namespace SULS.Services
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
        private readonly SULSContext db;

        public UsersService(SULSContext db)
        {
            this.db = db;
        }

        public string GetId(string username, string password)
        {
            var hashedPassword = this.HashPassword(password);

            var id = this.db.Users
                .Where(u => u.Username == username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return id;
        }

        public void Create(string username, string email, string password)
        {
            var hashedPassword = this.HashPassword(password);

            var user = new User
            {
                Username = username,
                Email = email,
                Password = hashedPassword,
                Role = IdentityRole.User
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool IsEmailExists(string email)
            => this.db.Users.Any(u => u.Email == email);

        public bool IsUsernameExists(string username)
            => this.db.Users.Any(u => u.Username == username);

        private string HashPassword(string password)
        {
            var hash = new StringBuilder();
            var crypt = new SHA256Managed();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString().TrimEnd();
        }
    }
}
