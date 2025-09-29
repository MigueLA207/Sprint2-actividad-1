using Sprint2.Services;

namespace Sprint2.Controllers;

public class VeterinarianController
{
    private readonly VeterinarianServices _vetService;

    public VeterinarianController()
    {
        _vetService = new VeterinarianServices();
    }
    public void CreateVeterinarian()
    {
        string? name;
        do
        {
            Console.WriteLine("Ingresa el nombre del nuevo veterinario:");
            name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                _vetService.AddVeterinarian(name);
                Console.WriteLine("Veterinario creado exitosamente.");
            }
            else
            {
                Console.WriteLine("Entrada invalida. Por favor ingresa un nombre valido.");
            }
        } while (string.IsNullOrEmpty(name));

    }
    
    public void ListVeterinarians()
    {
        var vets = _vetService.GetAllVeterinarians();
        if(vets.Count == 0)
        {
            Console.WriteLine("No hay veterinarios registrados.");
        }
        else
        {
            Console.WriteLine("Lista de veterinarios:");
            foreach (var vet in vets)
            {
                Console.WriteLine($"ID: {vet.Id}, Nombre: {vet.Name}");
            }
        }
    }

    public void UpdateVeterinarian()
    {
        Console.WriteLine("Ingresa el ID del veterinario a editar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int vetId))
        {
            var vet = _vetService.GetVeterinarianById(vetId);
            if (vet != null)
            {
                Console.WriteLine($"Veterinario encontrado: ID {vet.Id}, Nombre: {vet.Name}");
                Console.WriteLine("Ingresa el nuevo nombre del veterinario:");
                string? newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    _vetService.updateVeterinarian(vetId, newName);
                    Console.WriteLine("Veterinario actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Entrada invalida. El nombre no puede estar vacio.");
                }
            }
        }
    }
    public void DeleteVeterinarian()
    {
        Console.WriteLine("Ingresa el ID del veterinario a eliminar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int vetId))
        {
            var vet = _vetService.GetVeterinarianById(vetId);
            if (vet != null)
            {
                Console.WriteLine($"Veterinario encontrado: ID: {vet.Id}, Nombre: {vet.Name}");
                Console.WriteLine("¿Estas seguro que deseas eliminar este veterinario? (s/n)");
                string? confirmation = Console.ReadLine();
                if (confirmation?.ToLower() == "s")
                {
                    _vetService.DeleteVeterinarian(vetId);
                    Console.WriteLine("Veterinario eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Eliminacion cancelada.");
                    return;
                }
                
            }
            else
            {
                Console.WriteLine("No se encontro un veterinario con ese ID.");
            }
        }
        else
        {
            Console.WriteLine("ID invalido. Debe ser un numero entero.");
        }
    }
}