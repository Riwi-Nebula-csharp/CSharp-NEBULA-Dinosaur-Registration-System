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

    public async void updateEmail(int id)
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
    
}