using Sprint2.Models;
using Sprint2.Services;

namespace Sprint2.Controllers;

public class AdvancedQuerysController
{
    private readonly AdvancedQuerysServices _AqService;

    public AdvancedQuerysController()
    {
        _AqService = new AdvancedQuerysServices();
    }

    public void MedicalCaresByPet()
    {
        Console.WriteLine("Ingrese el ID de la mascota:");
        string? inputM = Console.ReadLine();
        if (!int.TryParse(inputM, out int petID))
        {
            Console.WriteLine("Entrada invalida. Por favor ingresa un ID valido.");
            return;
        }

        var cares = _AqService.GetMedicalCaresByPet(petID);

        if (cares.Count == 0)
        {
            Console.WriteLine("No hay atenciones medicas registradas para esta mascota.");
        }
        else
        {
            Console.WriteLine($"Lista de atenciones medicas para la mascota con ID {petID}:");
            foreach (var care in cares)
            {
                Console.WriteLine($"ID: {care.Id}, Fecha: {care.Date}, Diagnostico: {care.Diagnosis}, Veterinario ID: {care.VeterinarianId}");
            }
        }

    }

    public void ListPetsByClient()
    {
        Console.WriteLine("Ingresae el ID del cliente:");
        string? inputC = Console.ReadLine();
        if (!int.TryParse(inputC, out int clientID))
        {
            Console.WriteLine("Entrada invalida. Por favor ingresa un ID valido.");
            return;
        }

        var pets = _AqService.GetPetsByClient(clientID);

        if (pets.Count == 0)
        {
            Console.WriteLine("No hay mascotas registradas para este cliente.");
        }
        else
        {
            Console.WriteLine($"Lista de mascotas para el cliente con ID {clientID}:");
            foreach (var pet in pets)
            {
                Console.WriteLine($"ID: {pet.Id}, Nombre: {pet.Name}");
            }
        }
    }

    public void VetWithMostMedicalCares()
    {
        var moreMC = _AqService.GetVetWithMostMedicalCares();
        if (moreMC == null)
        {
            Console.WriteLine("No hay veterinarios registrados o no hay atenciones medicas.");
        }
        else
        {
            Console.WriteLine($"El veterinario con mas atenciones medicas es {moreMC.Value.Vet.Name} con un total de {moreMC.Value.Count} atenciones.");
        }
    }
    
    public void ClientWithMostPets()
    {
        var morePets = _AqService.GetClientWithMostPets();
        if (morePets == null)
        {
            Console.WriteLine("No hay clientes registrados o no hay mascotas.");
        }
        else
        {
            Console.WriteLine($"El cliente con mas mascotas es {morePets.Value.Client.Name} con un total de {morePets.Value.Count} mascotas.");
        }
    }
    
}