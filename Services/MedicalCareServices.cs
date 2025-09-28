using Sprint2.Data;
using Sprint2.Models;
namespace Sprint2.Services;

public class MedicalCareServices
{
    private readonly VeterinariaDbContext _db;
    public MedicalCareServices()
    {
        _db = new VeterinariaDbContext();
    }
    
    public void AddMedicalCare(MedialCare care)
    {
       
    
        var pet = _db.Pets.Find(care.PetId);
        if (pet == null)
        {
            Console.WriteLine($"No se encontró una mascota con ID {care.PetId}");
            return;
        }

        var vet = _db.Veterinarians.Find(care.VeterinarianId);
        if (vet == null)
        {
            Console.WriteLine($"No se encontró un veterinario con ID {care.VeterinarianId}");
            return;
        }
        
        _db.MedicalCares.Add(care);
        _db.SaveChanges();
    }
    
    public List<MedialCare> GetAllMedicalCares()
    {
        return _db.MedicalCares.ToList();
    }
    
    public MedialCare? GetMedicalCareById(int careId)
    {
        var care = _db.MedicalCares.Find(careId);
        if (care == null)
        {
            Console.WriteLine($"No se encontró una atención médica con ID {careId}");
        }

        return care;
    }
    
    public Pet? GetPetById(int petId)
    {
        var pet = _db.Pets.Find(petId);
        if (pet == null)
        {
            Console.WriteLine($"No se encontró una mascota con ID {petId}");
        }

        return pet;
    }
    
    public Veterinarian? GetVeterinarianById(int vetId)
    {
        var vet = _db.Veterinarians.Find(vetId);
        if (vet == null)
        {
            Console.WriteLine($"No se encontró un veterinario con ID {vetId}");
        }

        return vet;
    }
    
    public void UpdateMedicalCare(MedialCare care)
    {
        _db.MedicalCares.Update(care);
        _db.SaveChanges();
    }

    public void DeleteMedicalCare(int idCare)
    {
        var care = _db.MedicalCares.Find(idCare);
        if (care != null)
        {
            _db.MedicalCares.Remove(care);
            _db.SaveChanges();
        }
    }
}