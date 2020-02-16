namespace SharedTrip.Services
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        string GetId(string username, string password);

        bool IsUsernameExists(string username);

        bool IsEmailExists(string email);
    }
}
