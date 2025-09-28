using Sprint2.Data;

namespace Sprint2.Services;

public class VeterinarianServices
{
    private readonly VeterinariaDbContext _db;
    public VeterinarianServices()
    {
        _db = new VeterinariaDbContext();
    }
    public void AddVeterinarian(string name)
    {
        var vet = new Models.Veterinarian { Name = name };
        _db.Veterinarians.Add(vet);
        _db.SaveChanges();
    }
    
    public List<Models.Veterinarian> GetAllVeterinarians()
    {
        return _db.Veterinarians.ToList();
    }
    
    public Models.Veterinarian? GetVeterinarianById(int id)
    {
        return _db.Veterinarians.Find(id);
    }

    public void DeleteVeterinarian(int id)
    {
        var vet = _db.Veterinarians.Find(id);
        if (vet != null)
        {
            _db.Veterinarians.Remove(vet);
            _db.SaveChanges();
        }
    }
    
    public void updateVeterinarian(int vetId, string newName)
    {
        var vet = _db.Veterinarians.Find(vetId);
        if (vet == null)
        {
            Console.WriteLine($"No se encontró un veterinario con ID {vetId}");
            return;
        }
        vet.Name = newName;
         _db.Veterinarians.Update(vet);
         _db.SaveChanges();
    }
    
}