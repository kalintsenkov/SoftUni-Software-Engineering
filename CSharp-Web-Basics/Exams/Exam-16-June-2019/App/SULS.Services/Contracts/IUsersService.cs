namespace SULS.Services.Contracts
{
    public interface IUsersService
    {
        string GetId(string username, string password);

        void Create(string username, string email, string password);

        bool IsEmailExists(string email);

        bool IsUsernameExists(string username);
    }
}
