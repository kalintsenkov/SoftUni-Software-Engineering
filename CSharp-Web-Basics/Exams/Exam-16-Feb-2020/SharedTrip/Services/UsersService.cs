namespace SharedTrip.Services
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using SIS.MvcFramework;

    using Data;
    using Models;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext data;

        public UsersService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
                Role = IdentityRole.User
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public string GetId(string username, string password)
        {
            var hashPassword = this.Hash(password);

            var id = this.data.Users
                .Where(u => (u.Username == username || u.Email == username)
                        && u.Password == hashPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            return id;
        }

        public bool IsEmailExists(string email)
            => this.data.Users.Any(u => u.Email == email);

        public bool IsUsernameExists(string username)
            => this.data.Users.Any(u => u.Username == username);

        private string Hash(string password)
        {
            var hash = new StringBuilder();
            var crypt = new SHA256Managed();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
