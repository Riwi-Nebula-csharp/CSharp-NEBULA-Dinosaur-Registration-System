using Dinosaur_Registration_System.Models;
using Dinosaur_Registration_System.Services;
using Dinosaur_Registration_System.Utils;

DinosaurService dinosaur = new DinosaurService();

int ValidarEntrada(int numeroOpciones, string mensaje)
{
    int entrada;
    do
    {
        entrada = Validator.GetInt(mensaje);
        if (entrada < 1 || entrada > numeroOpciones)
        {
            Console.Clear();
            Console.WriteLine("Opción inválida...\n");
        }
    } while (entrada < 1 || entrada > numeroOpciones);

    return entrada;
}


bool salir = false;
while (!salir)
{
    int opcion = ValidarEntrada(6, @"========================================
        NEOGENESIS PARK - SYSTEM
========================================

1. Registrar Dinosaurio
2. Consultar Dinosaurios
3. Actualizar Dinosaurio
4. Eliminar Dinosaurio
5. Reportes Avanzados
6. Salir

Seleccione una opción: ");
    switch (opcion)
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

            int consulta = ValidarEntrada(10, @"--- CONSULTAS DE DINOSAURIOS ---

1. Listar todos los dinosaurios
2. Ver dinosaurio por ID
3. Ver dinosaurio por código de registro
4. Listar por zona
5. Listar por sector
6. Listar por edad mínima
7. Listar por tipo (Carnívoro/Herbívoro)
8. Mostrar nombres completos + código
9. Contar total de dinosaurios
10. Volver

Seleccione una opción: ");

            switch (consulta)
            {
                case 1:
                    Console.Clear();
                    dinosaur.AllDinosaurs();
                    break;
                case 2:
                    Console.Clear();
                    dinosaur.GetDinosaurById();
                    break;
                case 3:
                    Console.Clear();
                    dinosaur.GetDinosaurByEmail();
                    break;
                case 4:
                    Console.Clear();
                    int typeZone = ValidarEntrada(9, @"Buscar por zona

1. ArcticValley
2. FrozenPeak
3. GlacierBay
4. JungleDepths
5. RainforestCanopy
6. SwampLands
7. VolcanicPlains
8. AshDesert
9. LavaFields
");
                    DinosaurZone zone = (DinosaurZone)(typeZone - 1);
                    var dinosZone = await dinosaur.GetByZone(zone);
                    dinosaur.ViewList(dinosZone);
                    break;
                case 5:
                    Console.Clear();
                    int typeSector = ValidarEntrada(3, @"Buscar por sector

1. North
2. Mid
3. South
");
                    DinosaurSector sector = (DinosaurSector)(typeSector - 1);
                    var dinosSector = await dinosaur.GetBySector(sector);
                    dinosaur.ViewList(dinosSector);
                    break;
                case 6:
                    Console.Clear();
                    int edad = Validator.GetInt("Ingrese el edad del dinosaur: ");
                    var dinoEdad = await dinosaur.GetByMinAge(edad);
                    dinosaur.ViewList(dinoEdad);
                    break;
                case 7:
                    Console.Clear();
                    int typeDino = ValidarEntrada(3, @"Buscar por sector

1. Carnivore
2. Herbivore
3. Omnivore
");
                    DinosaurSector type = (DinosaurSector)(typeDino - 1);
                    var typeDinosaurs = await dinosaur.GetBySector(type);
                    dinosaur.ViewList(typeDinosaurs);
                    break;
                case 8:
                    Console.WriteLine("8. Mostrar nombres completos + código");
                    break;
                case 9:
                    Console.WriteLine("9. Contar total de dinosaurios");
                    break;
                case 10:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            break;
        case 3:
            int idUpdate = Validator.GetInt("Ingrese el id del dinosaurio: ");
            dinosaur.UpdateDinosaur(idUpdate);
            break;
        case 4:
            int idDelete = Validator.GetInt("Ingrese el id del dinosaurio a eliminar: ");
            dinosaur.DeleteDinosaur(idDelete);
            break;
        case 6:
            salir = true;
            Console.Clear();
            Console.WriteLine("¡Hasta luego!");
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}