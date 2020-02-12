namespace Musaca.Services.Contracts
{
    public interface IUsersService
    {
        void Create(string username, string email, string password);

        string GetId(string username, string password);

        string GetUsername(string id);

        bool IsEmailUsed(string email);

        bool IsUsernameUsed(string username);
    }
}
