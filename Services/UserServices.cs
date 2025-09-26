using Sprint2.Data;
using Sprint2.Models;

namespace Sprint2.Services;

public class UserServices
{
    private readonly VeterinariaDbContext _db;
    public UserServices()
    {
        _db = new VeterinariaDbContext();
    }   
    
    public void AddUser(string name)
    {
        var user = new Models.User { Name = name };
        _db.Users.Add(user);
        _db.SaveChanges();
    }
    public List<Models.User> GetAllUsers()
    {
        return _db.Users.ToList();
    }
    
    public User? GetUserById(int id)
    {
        return _db.Users.Find(id);
    }
    
    public void UpdateUser(User user)
    {
        _db.Users.Update(user);
        _db.SaveChanges();
    }
    
    public void DeleteUser(int id)
    {
        var user = _db.Users.Find(id);
        if (user != null)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}