using WebApi.DB;

namespace Backend
{
    public interface IUserService
    {
        User GetUserByLogin(string username, string password);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);

    }
}
