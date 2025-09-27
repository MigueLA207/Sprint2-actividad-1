namespace Sprint2.Controllers;

public class MedicalCareController
{
    public void CreateMedicalCare()
    {
        Console.WriteLine("Ingrese el ID de la mascota:");
        string? inputM = Console.ReadLine();
        if (int.TryParse(inputM, out int petID))
        {
            
        }
    }
}