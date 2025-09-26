namespace Sprint2.Controllers;
using Sprint2.Services;

public class UserController
{
    private readonly UserServices _userService;
    
    public UserController()
    {
        _userService = new UserServices();
    }
    
    public void CreateUser()
    {
        string? name;
        do
        {
            Console.WriteLine("Ingresa el nombre del nuevo usuario:");
            name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                _userService.AddUser(name);
                Console.WriteLine("Usuario creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Entrada invalida. Por favor ingresa un nombre valido.");
            }
        }while(string.IsNullOrEmpty(name));
        
    }
}