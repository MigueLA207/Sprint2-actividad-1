using Sprint2.Data;
using Sprint2.Models;

namespace Sprint2.Services;

public class AdvancedQuerysServices
{
    private readonly VeterinariaDbContext _db;
    public AdvancedQuerysServices()
    {
        _db = new VeterinariaDbContext();
    }

    public List<MedialCare> GetMedicalCaresByPet(int petId)
    {
        var pet = _db.Pets.Find(petId);
        if (pet == null)
        {
            Console.WriteLine($"No se encontró una mascota con ID {petId}");
            return new List<MedialCare>();
        }

        var cares = _db.MedicalCares.Where(mc => mc.PetId == petId).ToList();

        if (cares.Count() == 0)
        {
            Console.WriteLine($"No hay atenciones médicas registradas para la mascota con ID {petId}");
            return new List<MedialCare>();
        }

        return cares;
    }

    public List<Pet> GetPetsByClient(int clientId)
    {
        var client = _db.Users.Find(clientId);
        if (client == null)
        {
            Console.WriteLine($"No se encontró un cliente con ID {clientId}");
            return new List<Pet>();
        }

        var pets = _db.Pets.Where(p => p.userId == clientId).ToList();

        if (pets.Count() == 0)
        {
            Console.WriteLine($"No hay mascotas registradas para el cliente con ID {clientId}");
            return new List<Pet>();
        }

        return pets;
    }

    public (Veterinarian Vet, int Count)? GetVetWithMostMedicalCares()
    {
        var result =
            (from mc in _db.MedicalCares
             join v in _db.Veterinarians on mc.VeterinarianId equals v.Id
             group mc by v into vetGroup
             orderby vetGroup.Count() descending
             select new
             {
                 Vet = vetGroup.Key,
                 Count = vetGroup.Count()
             })
            .FirstOrDefault();

        if (result == null)
        {
            return null;
        }

        return (result.Vet, result.Count);
    }
    
    public (User Client, int Count)? GetClientWithMostPets()
    {
        var result =
            (from p in _db.Pets
             join u in _db.Users on p.userId equals u.Id
             group p by u into userGroup
             orderby userGroup.Count() descending
             select new
             {
                 Client = userGroup.Key,
                 Count = userGroup.Count()
             })
            .FirstOrDefault();

        if (result == null)
        {
            return null;
        }

        return (result.Client, result.Count);
    }

    
}