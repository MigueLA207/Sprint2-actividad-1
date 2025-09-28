namespace Sprint2.Controllers;
using Sprint2.Services;

public class PetController
{
    private readonly  PetServices _petService;
    
    public PetController()
    {
        _petService = new PetServices();
    }
    
    public void CreatePet()
    {
        string? name;
        int userId;
        do
        {
            Console.WriteLine("Ingresa el nombre de la nueva mascota:");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un nombre válido.");
                continue;
            }

            Console.WriteLine("Ingresa el ID del usuario dueño de la mascota:");
            var userIdInput = Console.ReadLine();

            if (!int.TryParse(userIdInput, out userId))
            {
                Console.WriteLine("ID inválido. Debe ser un número entero.");
                name = null; 
                continue;
            }

            _petService.AddPet(name, userId);
            Console.WriteLine("Mascota creada exitosamente.");

        } while (string.IsNullOrWhiteSpace(name));
        
    }
    public void ListPets()
    {
        var pets = _petService.GetAllPets();
        if(pets.Count == 0)
        {
            Console.WriteLine("No hay usuarios registrados.");
        }
        else
        {
            Console.WriteLine("Lista de mascotas:");
            foreach (var pet in pets)
            {
                Console.WriteLine($"ID: {pet.Id}, Nombre: {pet.Name}, Dueño: {_petService.GetOwner(pet.userId).Name}");
            }
        }
        
    }
    
    public void UpdatePet()
    {
        Console.WriteLine("Ingresa el ID de la mascota a editar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int petId))
        {
            var pet = _petService.GetPetById(petId);
            if (pet != null)
            {
                Console.WriteLine($"Mascota encontrada: ID: {pet.Id}, Nombre: {pet.Name}");
                Console.WriteLine("Ingresa el nuevo nombre de la mascota:");
                string? newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    pet.Name = newName;
                    _petService.UpdatePet(pet.Id, newName);
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

    public void DeletePet()
    {
        Console.WriteLine("Ingresa el ID de la mascota a eliminar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int petId))
        {
            var pet = _petService.GetPetById(petId);
            if (pet != null)
            {
                
                Console.WriteLine($"Mascota encontrada: ID: {pet.Id}, Nombre: {pet.Name}");
                Console.WriteLine("¿Estas seguro que deseas eliminar esta mascota? (s/n)");
                string? confirmation = Console.ReadLine();
                if (confirmation?.ToLower() == "s")
                {
                    _petService.DeletePet(pet.Id);
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