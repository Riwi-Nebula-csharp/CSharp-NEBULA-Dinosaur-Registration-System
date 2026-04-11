using Dinosaur_Registration_System.Services;
using Dinosaur_Registration_System.Utils;

DinosaurService dinosaur = new DinosaurService();

bool salir = false;
while (!salir)
{
    Console.WriteLine(@"========================================
   🦖 NEOGENESIS PARK - SYSTEM
========================================

1. Registrar Dinosaurio
2. Consultar Dinosaurios
3. Actualizar Dinosaurio
4. Eliminar Dinosaurio
5. Reportes Avanzados
0. Salir

Seleccione una opción:");

    Console.Write("\nIngrese una opción (1-4): ");
    string entrada = Console.ReadLine();

    if (int.TryParse(entrada, out int opc))
    {
        if (opc < 0 || opc > 5)
        {
            Console.WriteLine("Opción inválida, debe elegir una opción entre 1 - 5");
        }
        else
        {
            switch (opc)
            {
                case 1:
                    int menu;
                    do
                    {
                        await dinosaur.RegisterDinosaur();
                        menu = Validator.GetInt(@"¿Desea agregar otro dinosuario? 
1. Si
2. No");
                        if (menu < 1 || menu > 2)
                        {
                            Console.WriteLine("Opción invalida, debe ser 1 o 2");
                        }
                    } while (menu == 1);
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine(@"--- CONSULTAS DE DINOSAURIOS ---

1. Listar todos los dinosaurios
2. Ver dinosaurio por ID
3. Ver dinosaurio por código de registro
4. Listar por zona
5. Listar por sector
6. Listar por edad mínima
7. Listar por tipo (Carnívoro/Herbívoro)
8. Mostrar nombres completos + código
9. Contar total de dinosaurios
0. Volver

Seleccione una opción:");
                    break;
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    salir = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
    else
    {
        Console.WriteLine("Error: Debe ingresar un número entero.");
    }
}

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