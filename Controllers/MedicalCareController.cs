using Sprint2.Models;
using Sprint2.Services;

namespace Sprint2.Controllers;

public class MedicalCareController
{
    private readonly  MedicalCareServices _McService;
    
    public MedicalCareController()
    {
        _McService = new MedicalCareServices();
    }
    public void CreateMedicalCare()
    {
        Console.WriteLine("Ingrese el ID de la mascota:");
        string? inputM = Console.ReadLine();
        if (!int.TryParse(inputM, out int petID))
        {
            Console.WriteLine("Entrada invalida. Por favor ingresa un ID valido.");
            return;
        }
        Console.WriteLine("Ingrese el ID del veterinario:");
        string? inputV = Console.ReadLine();
        if (!int.TryParse(inputV, out int vetID))
        {
            Console.WriteLine("Entrada invalida. Por favor ingresa un ID valido.");
            return;
        }
        Console.WriteLine("Ingrese el diagnostico:");
        string? diagnosis = Console.ReadLine();
        if (string.IsNullOrEmpty(diagnosis))
        {
            Console.WriteLine("Entrada invalida. Por favor ingresa un diagnostico valido.");
            return;
        }

        var medicalCareService = new MedialCare
        {
            Date = DateTime.Now,
            Diagnosis = diagnosis,
            PetId = petID,
            VeterinarianId = vetID
        };
        
        _McService.AddMedicalCare(medicalCareService);
        Console.WriteLine("Atencion medica creada exitosamente.");
    }
    
    public void ListMedicalCares()
    {
        var medicalCares = _McService.GetAllMedicalCares();
        if(medicalCares.Count == 0)
        {
            Console.WriteLine("No hay atenciones medicas registradas.");
        }
        else
        {
            Console.WriteLine("Lista de atenciones medicas:");
            foreach (var care in medicalCares)
            {
                Console.WriteLine($"ID: {care.Id}, Fecha: {care.Date}, Diagnostico: {care.Diagnosis}, Mascota: {_McService.GetPetById(care.PetId).Name}, Veterinario: {_McService.GetVeterinarianById(care.VeterinarianId).Name}");
            }
        }
    }
    
    public void UpdateMedicalCare()
    {
        Console.WriteLine("Ingresa el ID de la atencion medica a editar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int careId))
        {
            var care = _McService.GetMedicalCareById(careId);
            if (care != null)
            {
                Console.WriteLine($"Atencion medica encontrada: ID: {care.Id}, Diagnostico: {care.Diagnosis}");
                Console.WriteLine("Ingresa el nuevo diagnostico:");
                string? newDiagnosis = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDiagnosis))
                {
                    care.Diagnosis = newDiagnosis;
                    _McService.UpdateMedicalCare(care);
                    Console.WriteLine("Atencion medica actualizada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Entrada invalida. El diagnostico no puede estar vacio.");
                }
            }
            else
            {
                Console.WriteLine("Atencion medica no encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID invalido. Debe ser un numero entero.");
        }
    }
    
    public void DeleteMedicalCare()
    {
        Console.WriteLine("Ingresa el ID de la atencion medica a eliminar:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int careId))
        {
            var care = _McService.GetMedicalCareById(careId);
            if (care != null)
            {
                _McService.DeleteMedicalCare(careId);
                Console.WriteLine("Atencion medica eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Atencion medica no encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID invalido. Debe ser un numero entero.");
        }
    }
}