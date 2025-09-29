namespace Sprint2.Services;
using Sprint2.Data;
using Sprint2.Models;

public class PetServices
{
    private readonly VeterinariaDbContext _db;
    public PetServices()
    {
        _db = new VeterinariaDbContext();
    }
    
    public List<Pet> GetAllPets()
    {
        return _db.Pets.ToList();
    }
    
    public Pet GetPetById(int petId)
    {
        var pet = _db.Pets.Find(petId);
        if (pet == null)
        {
            Console.WriteLine($"No se encontró una mascota con ID {petId}");
        }

        return pet;
    }
    
    public User GetOwner(int userId)
    {
        
        var user = _db.Users.Find(userId);
        if (user == null)
        {
            Console.WriteLine($"No se encontró un usuario con ID {userId}");
        }

        return user;
    }

    
    public void AddPet(string name, int userId)
    {
        // Validar que el usuario exista
        var user = _db.Users.Find(userId);
        if (user == null)
        {
            Console.WriteLine($"No se encontró un usuario con ID {userId}");
            return;
        }

        var pet = new Pet
        {
            Name = name,
            userId = userId
            // History = new MedicalHistory(), 
            // Veterinarians = new List<Veterinarian>() 
        };

        _db.Pets.Add(pet);
        _db.SaveChanges();
    }
    
    public void UpdatePet(int petId, string newName)
    {
        var pet = _db.Pets.Find(petId);
        if (pet == null)
        {
            Console.WriteLine($"No se encontró una mascota con ID {petId}");
            return;
        }

        pet.Name = newName;
        _db.SaveChanges();
    }
    
    public void DeletePet(int petId)
    {
        var pet = _db.Pets.Find(petId);
        if (pet == null)
        {
            Console.WriteLine($"No se encontró una mascota con ID {petId}");
            return;
        }

        _db.Pets.Remove(pet);
        _db.SaveChanges();
    }
    
    
    
    
}