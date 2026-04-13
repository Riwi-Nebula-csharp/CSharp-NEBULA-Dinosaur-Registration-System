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
                Console.Clear();
                await dinosaur.RegisterDinosaur();
                menu = Validator.GetInt(@"¿Desea agregar otro dinosuario? 
1. Si
2. No");
                if (menu < 1 || menu > 2)
                {
                    Console.Clear();
                    Console.WriteLine("Opción invalida, debe ser 1 o 2");
                }
            } while (menu == 1);

            Console.Clear();
            break;
        case 2:
            Console.Clear();
            int consulta = ValidarEntrada(10, @"--- CONSULTAS DE DINOSAURIOS ---

1. Listar todos los dinosaurios
2. Ver dinosaurio por ID
3. Ver dinosaurio por código de registro
4. Listar por zona
5. Listar por sector
6. Listar por edad mínima
7. Listar por tipo (Carnívoro/Herbívoro)
8. Mostrar nombres completos + código
9. Volver

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
                    Console.Clear();
                    dinosaur.FullNamesWithEmail();
                    break;
                case 9:
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opción inválida.\n");
                    break;
            }

            break;
        case 3:
            Console.Clear();
            int idUpdate = Validator.GetInt("Ingrese el id del dinosaurio: ");
            dinosaur.UpdateDinosaur(idUpdate);
            break;
        case 4:
            Console.Clear();
            int idDelete = Validator.GetInt("Ingrese el id del dinosaurio a eliminar: ");
            while (true)
            {
                int validarDelete = Validator.GetInt(@"¿Estás seguro de que desea eliminar?
1. Si
2. No");
                if (idDelete < 1 || validarDelete > 2)
                {
                    Console.WriteLine("\nOpción invalida, Elija entre 1 y 2\n");
                }

                if (validarDelete == 1)
                {
                    dinosaur.DeleteDinosaur(idDelete);
                    break;
                }
                else if (validarDelete == 2)
                {
                    Console.Clear();
                    Console.WriteLine("\nEl dinosaur se ha conservado\n");
                    break;
                }
            }

            break;
        case 5:
            Console.Clear();
            int reportes = ValidarEntrada(8, @"--- REPORTES AVANZADOS ---
1. Cantidad de dinosaurios
2. Cantidad de dinosaurios por zona
3. Cantidad de dinosaurios por sector
4. Dinosaurios sin dispositivo de rastreo
5. Dinosaurios sin ubicación registrada
6. Últimos dinosaurios registrados
7. Dinosaurios ordenados por especie (A-Z)
8. Volver

Seleccione una opción:");
            switch (reportes)
            {
                case 1:
                    Console.Clear();
                    dinosaur.TotalDinosaurs();
                    break;
                case 2:
                    Console.Clear();
                    dinosaur.HowManyDinosByZone();
                    break;
                case 3:
                    Console.Clear();
                    dinosaur.HowManyDinosBySection();
                    break;
                case 4:
                    Console.Clear();
                    dinosaur.DinosWithoutPhone();
                    break;
                case 5:
                    Console.Clear();
                    dinosaur.DinosWithoutAddress();
                    break;
                case 6:
                    Console.Clear();
                    dinosaur.LastRecorderdDinos();
                    break;
                case 7:
                    Console.Clear();
                    dinosaur.DinosAlphabetically();
                    break;
                case 8:
                    Console.Clear();
                    break;
            }
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