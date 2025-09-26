using Sprint2.Data;

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
}