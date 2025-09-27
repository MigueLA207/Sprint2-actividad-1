using Sprint2.SubMenus;

class Program
{
    static void Main(string[] args)
    {
        MainMenu mainMenu = new();
        mainMenu.Show();
    }
}

public class MainMenu
{
    public void Show()
    {
        int option = -1;

        while (option != 0)
        {
            Console.Clear();
            Console.WriteLine(" Veterinaria");
            Console.WriteLine("1. Gestion de clientes.");
            Console.WriteLine("2. Gestion de mascotas.");
            Console.WriteLine("3. Gestion de veterinarios.");
            Console.WriteLine("4. Gestion de atenciones medicas.");
            Console.WriteLine("5. Historial medico.");
            Console.WriteLine("0. Exit");

            Console.Write("\nEnter an option: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                option = -1;
            }
            else if (option < 0 || option > 5)
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
            else
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        UsersMenu userC = new();
                        userC.show();
                        break;  
                    case 2:
                        PetsMenu petC = new();
                        petC.show();
                        break;
                    
                    case 3:
                        VeterinarianMenu vetC = new();
                        vetC.show();
                        break;
                    
                    case 4:
                        MedicalCareMenu mcC = new();
                        mcC.show();
                        break;
                    
                    case 5:
                        break;
                    
                    case 0:
                        Console.WriteLine("Saliendo del programa.");
                        break;
                }
            }

            if (option != 0)
            {
                Console.WriteLine("\nPresiona una letra para volver al menu..");
                Console.ReadKey();
            }
        }
    }
}

