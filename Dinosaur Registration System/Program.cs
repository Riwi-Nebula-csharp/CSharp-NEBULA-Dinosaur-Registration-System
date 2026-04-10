using Dinosaur_Registration_System.Services;

DinosaurService dinosaur = new DinosaurService();

bool salir = false;
while (!salir)
{
    Console.WriteLine(@"
SISTEMA DE INVENTARIO
1. New Dinosaur
");

    Console.Write("\nIngrese una opción (1-4): ");
    string entrada = Console.ReadLine();

    if (int.TryParse(entrada, out int opc))
    {
        switch (opc)
        {
            case 1:
                await dinosaur.RegisterDinosaur();
                break;
            case 5:
                Console.WriteLine("¡Hasta luego!");
                salir = true;
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Error: Debe ingresar un número entero.");
    }
}

Console.WriteLine("holi");
//
// AppDbContext _context = new AppDbContext();
// DinosaurService dino = new DinosaurService(_context);
//
// Console.WriteLine("Ingrese búsqueda:");
// string busqueda = Console.ReadLine();
//
// var lista = await dino.ListDinosuars(busqueda);
// dino.ViewList(lista);

// bool menu = false;
// while (!menu)
// {
//     await dino.RegisterDinosaur();
//     Console.WriteLine(@"¿Desea ingresar otro Dinosaurio?
// 1. Si
// 2. No");
//     string input = Console.ReadLine();
//     if (int.TryParse(input, out int result))
//     {
//         if (result == 2)
//         {
//             menu = true;
//         }
//     }
//     else
//     {
//         Console.WriteLine("Debe ser una entrada válida 1 o 2");
//     }
// }