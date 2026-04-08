using Microsoft.EntityFrameworkCore;
using Dinosaur_Registration_System.Data;
using Dinosaur_Registration_System.Models;

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
}