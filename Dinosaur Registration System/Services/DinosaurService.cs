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
        
        
        

    }
}