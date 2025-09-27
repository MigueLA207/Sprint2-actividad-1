namespace Sprint2.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get ; set; }
    
    public MedicalHistory History { get; set; }
    public int userId { get; set; }
    public User User { get; set; }
    public ICollection<Veterinarian> Veterinarians { get; set; }
    public ICollection<MedialCare> MedicalCares { get; set; }
}