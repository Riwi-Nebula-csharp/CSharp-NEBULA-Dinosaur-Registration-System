using Dinosaur_Registration_System.Models;

namespace Dinosaur_Registration_System.Utils;

public class Validator
{
    // TODO: Crear métodos para validar datos de entrada.
    // TODO: Validar campos obligatorios (no vacíos).
    // TODO: Validar formato de email (opcional).
    // TODO: Validar que la edad sea mayor o igual a 0 y menor a 100.

    public static int RequestId()
    {
        int id;
        Console.WriteLine("What's the Id: ?");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.Write("Please use only numbers: ");
        }

        return id;
    }
    
    public static string RequestEmail()
    {
        Console.WriteLine("What's the email?: ");
        string email = Console.ReadLine() ?? "";
        while (email == "")
        {
            Console.Write("Cannot be empty: ");
            email = Console.ReadLine() ?? "";
        }

        return email;
    }

    public static Dictionary<string, object> RequestData()
    {
        var newData = new Dictionary<string, object>();

        Console.WriteLine("\n=== Update Dinosaur ===");
        Console.WriteLine("(Press ENTER to skip any field)\n");

        // FirstName
        while (true)
        {
            Console.Write("New First Name: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (input.Length <= 100) { newData["FirstName"] = input; break; }
            Console.WriteLine("  ⚠ 100 characters max.");
        }

        // LastName
        while (true)
        {
            Console.Write("New Last Name: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (input.Length <= 100) { newData["LastName"] = input; break; }
            Console.WriteLine("  ⚠ 100 characters max.");
        }

        // Username
        while (true)
        {
            Console.Write("New Username: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (input.Length <= 50) { newData["Username"] = input; break; }
            Console.WriteLine("  ⚠ 50 characters max, try again.");
        }

        // Age
        while (true)
        {
            Console.Write("New Age: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (int.TryParse(input, out int age) && age >= 0) { newData["Age"] = age; break; }
            Console.WriteLine("  ⚠ Put a valid number equal or higher than 0.");
        }

        // Type
        while (true)
        {
            Console.Write($"New Type ({string.Join(", ", Enum.GetNames(typeof(DinosaurType)))}): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (Enum.TryParse(typeof(DinosaurType), input, true, out var type)) { newData["Type"] = type; break; }
            Console.WriteLine($"  ⚠ Invalid value, options: {string.Join(", ", Enum.GetNames(typeof(DinosaurType)))}");
        }

        // Zone
        while (true)
        {
            Console.Write($"New Zone ({string.Join(", ", Enum.GetNames(typeof(DinosaurZone)))}): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (Enum.TryParse(typeof(DinosaurZone), input, true, out var zone)) { newData["Zone"] = zone; break; }
            Console.WriteLine($"  ⚠ Invalid Value, options: {string.Join(", ", Enum.GetNames(typeof(DinosaurZone)))}");
        }

        // Sector
        while (true)
        {
            Console.Write($"New Sector ({string.Join(", ", Enum.GetNames(typeof(DinosaurSector)))}): ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (Enum.TryParse(typeof(DinosaurSector), input, true, out var sector)) { newData["Sector"] = sector; break; }
            Console.WriteLine($"  ⚠ Invalid Value, options: {string.Join(", ", Enum.GetNames(typeof(DinosaurSector)))}");
        }

        // Address
        while (true)
        {
            Console.Write("New Address: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (input.Length <= 200) { newData["Address"] = input; break; }
            Console.WriteLine("  ⚠ 200 characters max, try again");
        }

        // Phone
        while (true)
        {
            Console.Write("New Phone: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            if (input.Length <= 20) { newData["Phone"] = input; break; }
            Console.WriteLine("  ⚠ 20 characters max, try again.");
        }

        return newData;
    }
}