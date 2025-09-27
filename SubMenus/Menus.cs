namespace Sprint2.SubMenus;
using Sprint2.Controllers;
using Sprint2.Models;

public class UsersMenu
{
    private readonly UserController UserController = new();

    public void show()
    {
        int option = -1;
        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine("1. Registrar cliente.");
            Console.WriteLine("2. Listar clientes.");
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
            else if (option < 0 || option > 4)
            {
                Console.WriteLine("Entrada invalida. Por favor intenta de nuevo.");
            }
            else
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        UserController.CreateUser();
                        break;
                    case 2:
                        UserController.ListUsers();
                        break;
                    case 3:
                        UserController.UpdateUser();
                        break;
                    case 4:
                        UserController.DeleteUser();
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
    private readonly PetController petController = new();

    public void show()
    {
        int option = -1;
        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine("1. Registrar mascota.");
            Console.WriteLine("2. Listar mascota.");
            Console.WriteLine("3. Editar mascota.");
            Console.WriteLine("4. Eliminar mascota.");
            Console.WriteLine("0. Salir");
            
            Console.Write("\nIngresa una opcion: ");
            string? input = Console.ReadLine();
            
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Entrada invalida. Por favor ingresa un numero.");
                option = -1;
            }
            else if (option < 0 || option > 4)
            {
                Console.WriteLine("Entrada invalida. Por favor intenta de nuevo.");
            }
            else
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        petController.CreatePet();
                        break;
                    case 2:
                        petController.ListPets();
                        break;
                    case 3:
                        petController.UpdatePet();
                        break;
                    case 4:
                        petController.DeletePet();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del menu de mascotas...");
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

public class VeterinarianMenu
{
    private readonly VeterinarianController vetController = new();

    public void show()
    {
        int option = -1;
        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine("1. Registrar veterinario.");
            Console.WriteLine("2. Listar veterinarios.");
            Console.WriteLine("3. Editar veterinario.");
            Console.WriteLine("4. Eliminar veterinario.");
            Console.WriteLine("0. Salir");
            
            Console.Write("\nIngresa una opcion: ");
            string? input = Console.ReadLine();
            
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Entrada invalida. Por favor ingresa un numero.");
                option = -1;
            }
            else if (option < 0 || option > 4)
            {
                Console.WriteLine("Entrada invalida. Por favor intenta de nuevo.");
            }
            else
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        vetController.CreateVeterinarian();
                        break;
                    case 2:
                        vetController.ListVeterinarians();
                        break;
                    case 3:
                        vetController.UpdateVeterinarian();
                        break;
                    case 4:
                        vetController.DeleteVeterinarian();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del menu de mascotas...");
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

public class MedicalHistoryMenu
{
    
}

public class MedicalCareMenu
{
    private readonly MedicalCareController mcController = new();

    public void show()
    {
        int option = -1;
        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine("1. Registrar atencion medica.");
            Console.WriteLine("2. Listar atenciones medicas.");
            Console.WriteLine("3. Editar atencion medica.");
            Console.WriteLine("4. Eliminar atencion medica.");
            Console.WriteLine("0. Salir");
            
            Console.Write("\nIngresa una opcion: ");
            string? input = Console.ReadLine();
            
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Entrada invalida. Por favor ingresa un numero.");
                option = -1;
            }
            else if (option < 0 || option > 4)
            {
                Console.WriteLine("Entrada invalida. Por favor intenta de nuevo.");
            }
            else
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        mcController.CreateMedicalCare();
                        // vetController.CreateVeterinarian();
                        break;
                    case 2:
                        mcController.ListMedicalCares();
                        break;
                    case 3:
                        // vetController.UpdateVeterinarian();
                        break;
                    case 4:
                        // vetController.DeleteVeterinarian();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del menu de mascotas...");
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

