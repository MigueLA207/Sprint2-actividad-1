namespace Sprint2.Models;

public class Veterinarian
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Pet> Pets { get; set; }
}