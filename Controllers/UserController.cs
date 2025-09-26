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
    public void ListUsers()
    {
        var users = _userService.GetAllUsers();
        Console.WriteLine("Lista de usuarios:");
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Nombre: {user.Name}");
        }
    }
    
    public void UpdateUser()
    {
        Console.WriteLine("Ingresa el ID del usuario a editar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int userId))
        {
            var user = _userService.GetUserById(userId);
            if (user != null)
            {
                Console.WriteLine($"Usuario encontrado: ID: {user.Id}, Nombre: {user.Name}");
                Console.WriteLine("Ingresa el nuevo nombre del usuario:");
                string? newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    user.Name = newName;
                    _userService.UpdateUser(user);
                    Console.WriteLine("Usuario actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Entrada invalida. El nombre no puede estar vacio.");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
    }

    public void DeleteUser()
    {
        Console.WriteLine("Ingresa el ID del usuario a eliminar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int userId))
        {
            var user = _userService.GetUserById(userId);
            if (user != null)
            {
                
                Console.WriteLine($"Usuario encontrado: ID: {user.Id}, Nombre: {user.Name}");
                Console.WriteLine("¿Estas seguro que deseas eliminar este usuario? (s/n)");
                string? confirmation = Console.ReadLine();
                if (confirmation?.ToLower() == "s")
                {
                    _userService.DeleteUser(userId);
                    Console.WriteLine("Usuario eliminado exitosamente.");
                    
                }
                else
                {
                    Console.WriteLine("Eliminacion cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }
    }
}