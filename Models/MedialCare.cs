namespace Sprint2.Models;

public class MedialCare
{
    public int Id { get; set; }

    public DateTime Date { get; set; }
    public string Diagnosis { get; set; }

    
    public int PetId { get; set; }
    public Pet Pet { get; set; }

    
    public int VeterinarianId { get; set; }
    public Veterinarian Veterinarian { get; set; }
}