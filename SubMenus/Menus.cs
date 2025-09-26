namespace Sprint2.SubMenus;
using Sprint2.Controllers;
using Sprint2.Models;

public class UsersMenu
{
    private readonly UserController userController = new();

    public void show()
    {
        int option = -1;
        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine("1. Registrar cliente.");
            Console.WriteLine("2. Listar cliente.");
            Console.WriteLine("3. Editar cliente.");
            Console.WriteLine("4. Eliminar cliente.");
            Console.WriteLine("0. Salir");
            
            Console.Write("\nIngresa una opcion: ");
            string? input = Console.ReadLine();
            
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Entrada invalida. Por favor ingresa un numero.");
                option = -1;
            }
            else if (option < 0 || option > 2)
            {
                Console.WriteLine("Entrada invalida. Por favor intenta de nuevo.");
            }
            else
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        userController.CreateUser();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del menu de usuarios...");
                        break;
                }
            }
            if (option != 0)
            {
                Console.WriteLine("\nPresiona cualquier letra para volver al menu...");
                Console.ReadKey();
            }
        }
    }
}

public class PetsMenu
{
    
}

public class MedicalHistoryMenu
{
    
}

public class VeterinarianMenu
{
    
}