using Backend;
using WebApi.DB;

public class UserService : IUserService
{
    private readonly PostgresContext _context;

    public UserService(PostgresContext context)
    {
        _context = context;
    }

    public User GetUserByLogin(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}