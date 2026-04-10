using Microsoft.EntityFrameworkCore;
using Dinosaur_Registration_System.Data;
using Dinosaur_Registration_System.Models;
using Dinosaur_Registration_System.Utils;

namespace Dinosaur_Registration_System.Services;

public class DinosaurService
{
    private readonly AppDbContext _context;
    
    public DinosaurService(AppDbContext context)
    {
        _context = context;
    }
    
    // TODO: Implementar los métodos CRUD (Create, Read, Update, Delete).
    // TODO: Centralizar toda la lógica de acceso a datos.
    // TODO: Implementar consultas usando LINQ (filtros, ordenamientos, conteos).
    // 

    public async Task<bool> UserNameExists(string userName)
    {
        return await _context.Dinosaurs.AnyAsync(d => d.Username == userName);
    }

    public async Task<bool> EmailExists(string email)
    {
        return await _context.Dinosaurs.AnyAsync(d => d.Email == email);
    }

    public async Task RegisterDinosaur()
    {
        string firstName = Validator.GetString("FirstName: ");
        string lastName = Validator.GetString("LastName: ");
        string userName;
        while (true)
        {
            userName = Validator.GetString("Username: ");
            if (await UserNameExists(userName))
            {
                Console.WriteLine("Ese username ya existe, intenta otro.");
            }
            else break;
        }

        int age = Validator.GetInt("Age: ");
        DinosaurType type = Validator.GetEnumFromUser<DinosaurType>("Category of dinosaur");
        DinosaurZone zone = Validator.GetEnumFromUser<DinosaurZone>("Zone of dinosaur");
        DinosaurSector sector = Validator.GetEnumFromUser<DinosaurSector>("Sector of dinosaur");
        string address = Validator.GetString("Address: ");
        string phone = Validator.GetString("Phone: ");
        string email;
        while (true)
        {
            email = Validator.RequestEmail();
            if (await EmailExists(email))
            {
                Console.WriteLine("Ese correo ya existe, intenta otro");
            }
            else break;
        }

        await _context.AddAsync(new Dinosaur
        {
            FirstName = firstName,
            LastName = lastName,
            Username = userName,
            Age = age,
            Type = type,
            Zone = zone,
            Sector = sector,
            Address = address,
            Phone = phone,
            Email = email
        });
        await _context.SaveChangesAsync();
        Console.WriteLine("Dinosaurio registrado correctamente");
    }

    public async void DeleteDinosaur(int id)
    {
        Dinosaur? data = await _context.Dinosaurs.FirstOrDefaultAsync(x => x.Id == id);
        
        if (data == null)
        {
            Console.WriteLine("\nId not found, check the Id and try again");
            return;
        }

        _context.Dinosaurs.Remove(data);
        await _context.SaveChangesAsync();

        Console.WriteLine("Dinosaur deleted successfully!");
        
    }
    
    public async void DeleteDinosaur(string email)
    {
        Dinosaur? data = await _context.Dinosaurs.FirstOrDefaultAsync(x => x.Email == email);
        
        if (data == null)
        {
            Console.WriteLine("\nEmail not found, check the Email and try again");
            return;
        }

        _context.Dinosaurs.Remove(data);
        await _context.SaveChangesAsync();

        Console.WriteLine("Dinosaur deleted successfully!");
    }

    public async void UpdateDinosaur(int id)
    {
        Dinosaur? dinosaur = await _context.Dinosaurs.FirstOrDefaultAsync(x => x.Id == id);
        if (dinosaur == null)
        {
            Console.WriteLine("\nId not found, try again");
            return;
        }
        
        Dictionary<string, object> data = Validator.RequestData();
        
        if (data.TryGetValue("FirstName", out var firstName)) dinosaur.FirstName = (string)firstName;
        if (data.TryGetValue("LastName",  out var lastName))  dinosaur.LastName  = (string)lastName;
        if (data.TryGetValue("Username",  out var username))  dinosaur.Username  = (string)username;
        if (data.TryGetValue("Age",       out var age))       dinosaur.Age       = (int)age;
        if (data.TryGetValue("Type",      out var type))      dinosaur.Type      = (DinosaurType)type;
        if (data.TryGetValue("Zone",      out var zone))      dinosaur.Zone      = (DinosaurZone)zone;
        if (data.TryGetValue("Sector",    out var sector))    dinosaur.Sector    = (DinosaurSector)sector;
        if (data.TryGetValue("Address",   out var address))   dinosaur.Address   = (string)address;
        if (data.TryGetValue("Phone",     out var phone))     dinosaur.Phone     = (string)phone;

        await _context.SaveChangesAsync();
        Console.WriteLine($"Dinosaur with id: {id} updated successfully");
    }

    public async void UpdateEmail(int id)
    {
        Dinosaur? dinosaur = await _context.Dinosaurs.FirstOrDefaultAsync(x => x.Id == id);
        if (dinosaur == null)
        {
            Console.WriteLine("\nId not found, try again");
            return;
        }

        Console.WriteLine("For security reasons, type the curren email of the Dinosaur");
        string email = Validator.RequestEmail();

        if (dinosaur.Email != email)
        {
            Console.WriteLine("Incorrect, access to updated denied");
            return;
        }

        dinosaur.Email = email;
        await _context.SaveChangesAsync();
        Console.WriteLine("\nEmail updated successfully!");
    }

    // Listar todos los dinosaurios registrados (reporte general).
    public async void AllDinosaurs()
    {
        var dinosaurs = await _context.Dinosaurs.ToListAsync();
        Console.WriteLine(
            "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-10} | {9,-10} | {10,-10}, Id, FirstName, LastName, Username, Email, Age, Type,Zone, Sector, Address, Phone");
        Console.WriteLine(new string('-', 200));
        foreach (var dino in dinosaurs)
        {
            Console.WriteLine(
                $"{dino.Id,-10} | {dino.FirstName,-10} | {dino.LastName,-10} | {dino.Username,-10} | {dino.Email,-10} | {dino.Type,-10} | {dino.Zone,-10} | {dino.Sector,-10} | {dino.Address,-10} | {dino.Phone,-10}");
        }
    }

    // Ver el detalle de un dinosaurio por su Id (consulta individual)
    public async void GetDinosaurById(int id)
    {
        id = Validator.GetInt("Ingrese el id del dinosario a buscar: ");
        var dino = await _context.Dinosaurs.FirstOrDefaultAsync(d => d.Id == id);
        Console.WriteLine($"El dinosaurio identidicado con el id: {dino.Id} es: ");
        Console.WriteLine(
            "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-10} | {9,-10} | {10,-10}, Id, FirstName, LastName, Username, Email, Age, Type,Zone, Sector, Address, Phone");
        Console.WriteLine(new string('-', 200));
        Console.WriteLine(
            $"{dino.Id,-10} | {dino.FirstName,-10} | {dino.LastName,-10} | {dino.Username,-10} | {dino.Email,-10} | {dino.Type,-10} | {dino.Zone,-10} | {dino.Sector,-10} | {dino.Address,-10} | {dino.Phone,-10}");
    }

    // Ver el detalle de un dinosaurio por su código de registro (email).
    public async void GetDinosaurByEmail(string email)
    {
        email = Validator.GetString("Ingrese el id del dinosario a buscar: ");
        var dino = await _context.Dinosaurs.FirstOrDefaultAsync(d => d.Email == email);
        Console.WriteLine($"El dinosaurio identidicado con el id: {dino.Id} es: ");
        Console.WriteLine(
            "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-10} | {9,-10} | {10,-10}, Id, FirstName, LastName, Username, Email, Age, Type,Zone, Sector, Address, Phone");
        Console.WriteLine(new string('-', 200));
        Console.WriteLine(
            $"{dino.Id,-10} | {dino.FirstName,-10} | {dino.LastName,-10} | {dino.Username,-10} | {dino.Email,-10} | {dino.Type,-10} | {dino.Zone,-10} | {dino.Sector,-10} | {dino.Address,-10} | {dino.Phone,-10}");
    }

    public Task<List<Dinosaur>> ListDinosuars(string busqueda = null)
    {
        var query = _context.Dinosaurs.AsQueryable();

        // Si la búsqueda es nula o "todos", devolvemos todo Jajaja
        if (string.IsNullOrWhiteSpace(busqueda) || busqueda?.ToLower() == "todos")
        {
            return _context.Dinosaurs.ToListAsync();
        }

        bool enumType = Enum.TryParse(busqueda, true, out DinosaurType typeEnum);
        bool enumZone = Enum.TryParse(busqueda, true, out DinosaurZone zoneEnum);
        bool enumSector = Enum.TryParse(busqueda, true, out DinosaurSector sectorEnum);
        bool isNumber = int.TryParse(busqueda, out int number);
        string term = busqueda.ToLower();
        query = query.Where(d =>
            (isNumber && (d.Id == number || d.Age == number)) ||
            d.FirstName.ToLower().Contains(term) ||
            d.LastName.ToLower().Contains(term) ||
            d.Username.ToLower().Contains(term) ||
            d.Email.ToLower().Contains(term) ||
            (enumType && d.Type == typeEnum) ||
            (enumZone && d.Zone == zoneEnum) ||
            (enumSector && d.Sector == sectorEnum)
        );
        return query.ToListAsync();
    }

    public void ViewList(List<Dinosaur> list)
    {
        if (list.Count > 0)
        {
            Console.WriteLine(
                "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-15} | {5,-10} | {6,-10} | {7,-10} | {8,-10} | {9,-20} | {10,-15}", "Id", "FirstName", "LastName", "Username", "Email", "Age", "Type", "Zone", "Sector", "Address", "Phone");
            Console.WriteLine(new string('-', 120));
            foreach (var dino in list)
            {
                Console.WriteLine(
                    $"{dino.Id,-10} | {dino.FirstName,-10} | {dino.LastName,-10} | {dino.Username,-10} | {dino.Email,-15} | {dino.Type,-10} | {dino.Zone,-10} | {dino.Sector,-10} | {dino.Address,-20} | {dino.Phone,-15}");
            }
        }
        else
        {
            Console.WriteLine("No se encontró nada");
        }
    }

    public async void FullNamesWithEmail()
    {
        var dinosaurs = await _context.Dinosaurs.Select(x => new
        {
            x.FirstName,
            x.LastName,
            x.Email
        }).ToListAsync();

        Console.WriteLine("Display a list of full names and registration codes(email), for scientific reports.");
        foreach (var dino in dinosaurs)
        {
            Console.WriteLine($@"
            ----------DINO----------
            First Name: {dino.FirstName}
            Last Name: {dino.LastName}
            Email: {dino.Email}");
        }
    }

    public async void TotalDinosaurs()
    {
        var count = await _context.Dinosaurs.CountAsync();
        Console.WriteLine($"There's {count} Dinosaurs registered");
    }

    public async void HowManyDinosByZone()
    {
        var dinosByZone = await _context.Dinosaurs
            .GroupBy(x => x.Zone)
            .Select(u => new
            {
                value = u.Key,
                count = u.Count()
            }).ToListAsync();

        Console.WriteLine("Count how many dinosaurs there are in each area.");
        foreach (var zone in dinosByZone)
        {
            Console.WriteLine($"Area: {zone.value}");
            Console.WriteLine($"There are {zone.count} Dinos there");
        }
    }

    public async void HowManyDinosBySection()
    {
        var dinosBySection = await _context.Dinosaurs
            .GroupBy(x => x.Sector)
            .Select(u => new
            {
                value = u.Key,
                count = u.Count()
            }).ToListAsync();

        Console.WriteLine("Count how many dinosaurs there are in each section.");
        foreach (var section in dinosBySection)
        {
            Console.WriteLine($"Section: {section.value}");
            Console.WriteLine($"There are {section.count} Dinos there");
        }
    }

    public async void DinosWithoutPhone()
    {
        var noPhoneDinos = await _context.Dinosaurs
            .Where(x => x.Phone == null || x.Phone == "")
            .ToListAsync();

        Console.WriteLine("All Dinos with no phone numbers listed");
        foreach (var dino in noPhoneDinos)
        {
            Console.WriteLine($@"
            ----------DINO----------
            ID: {dino.Id}
            First Name: {dino.FirstName}
            Last Name: {dino.LastName}
            Email: {dino.Email}
            Zone: {dino.Zone}
            Sector: {dino.Sector}");
        }
    }

    public async void DinosWithoutAddress()
    {
        var noAddressDinos = await _context.Dinosaurs
            .Where(x => x.Address == null || x.Address == "")
            .ToListAsync();
        
        Console.WriteLine("All Dinos with no address listed");
        foreach (var dino in noAddressDinos)
        {
            Console.WriteLine($@"
            ----------DINO----------
            ID: {dino.Id}
            First Name: {dino.FirstName}
            Last Name: {dino.LastName}
            Email: {dino.Email}
            Zone: {dino.Zone}
            Sector: {dino.Sector}");
        }
    }

    public async void LastRecorderdDinos()
    {
        var lastDinos = await _context.Dinosaurs
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
        
        Console.WriteLine("All Dinos with no address listed");
        foreach (var dino in lastDinos)
        {
            Console.WriteLine($@"
            ----------DINO----------
            ID: {dino.Id}
            First Name: {dino.FirstName}
            Last Name: {dino.LastName}
            Email: {dino.Email}
            Zone: {dino.Zone}
            Sector: {dino.Sector}
            Registered at: {dino.CreatedAt}");
        }
    }

    public async void DinosAlphabetically()
    {
        var dinosAlph = await _context.Dinosaurs.OrderBy(x => x.Type).ToListAsync();
        
        Console.WriteLine("All Dinos with no address listed");
        foreach (var dino in dinosAlph)
        {
            Console.WriteLine($@"
            ----------DINO----------
            ID: {dino.Id}
            First Name: {dino.FirstName}
            Last Name: {dino.LastName}
            Email: {dino.Email}
            Zone: {dino.Zone}
            Sector: {dino.Sector}");
        }
    }
}