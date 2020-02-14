namespace IRunes.Services.Contracts
{
    public interface IUsersService
    {
        void Create(string username, string password, string email);

        string GetId(string username, string password);

        string GetUsername(string id);

        bool IsUsernameUsed(string username);

        bool IsEmailUsed(string email);
    }
}