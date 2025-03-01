using System;
using System.IO;

//Creacion de archivos en mi carpeta de programacion 1
string labPath = "C:/p1/LaboratorioAvengers";
string invFile = Path.Combine(labPath, "inventos.txt");
string backupPath = Path.Combine(labPath, "Backup");
string classifiedPath = Path.Combine(labPath, "ArchivosClasificados");


CrearDir(labPath);
CrearDir(backupPath);
CrearDir(classifiedPath);

//Menu de opciones
bool continuar = true;
while (continuar)
{
    Console.WriteLine("\nLaboratorio de Tony Stark");
    Console.WriteLine("1. Crear archivo 'inventos.txt'");
    Console.WriteLine("2. Agregar invento");
    Console.WriteLine("3. Leer inventos línea por línea");
    Console.WriteLine("4. Leer todo el archivo");
    Console.WriteLine("5. Copiar archivo a Backup");
    Console.WriteLine("6. Mover archivo a ArchivosClasificados");
    Console.WriteLine("7. Listar archivos en LaboratorioAvengers");
    Console.WriteLine("8. Eliminar archivo inventos.txt");
    Console.WriteLine("9. Salir");
    Console.Write("Elige una opción: ");
    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            CrearFile(invFile);
            break;
        case "2":
            Console.Write("Ingresa un invento: ");
            string inv = Console.ReadLine();
            AgregarInv(invFile, inv);
            break;
        case "3":
            LeerLinea(invFile);
            break;
        case "4":
            LeerTodo(invFile);
            break;
        case "5":
            CopiarFile(invFile, Path.Combine(backupPath, "inventos.txt"));
            break;
        case "6":
            MoverFile(invFile, Path.Combine(classifiedPath, "inventos.txt"));
            break;
        case "7":
            ListarFiles(labPath);
            break;
        case "8":
            EliminarFile(invFile);
            break;
        case "9":
            continuar = false;
            Console.WriteLine("¡Gracias por ayudar a Tony Stark!");
            break;
        default:
            Console.WriteLine("Opción no válida. Intenta de nuevo.");
            break;
    }
}

//Funcio para crear directorios
void CrearDir(string path)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
        Console.WriteLine($"Carpeta creada: {path}");
    }
}

//Funciones para crear archivo txt
void CrearFile(string path)
{
    try
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            Console.WriteLine("Archivo inventos.txt creado.");
        }
        else
        {
            Console.WriteLine("El archivo ya existe.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear el archivo: {ex.Message}");
    }
}

//Funcion para agregar inventos
void AgregarInv(string path, string inv)
{
    try
    {
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(inv);
        }
        Console.WriteLine("Invento agregado.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al agregar el invento: {ex.Message}");
    }
}

//Funcion para leer linea por linea
void LeerLinea(string path)
{
    try
    {
        if (File.Exists(path))
        {
            foreach (var linea in File.ReadLines(path))
            {
                Console.WriteLine(linea);
            }
        }
        else
        {
            Console.WriteLine("Error: El archivo no existe, ultron lo debio haber borrado");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al leer el archivo línea por línea: {ex.Message}");
    }
}

//Funcion para leer todo el archivo
void LeerTodo(string path)
{
    try
    {
        if (File.Exists(path))
        {
            string contenido = File.ReadAllText(path);
            Console.WriteLine($"\nContenido del archivo:\n{contenido}");
        }
        else
        {
            Console.WriteLine("Error: El archivo no existe, ultron lo debio haber borrado");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al leer todo el archivo: {ex.Message}");
    }
}

//Funcion para copiar archivos
void CopiarFile(string src, string dest)
{
    try
    {
        CrearDir(Path.GetDirectoryName(dest));
        if (File.Exists(src))
        {
            File.Copy(src, dest, true);
            Console.WriteLine("Archivo copiado a Backup.");
        }
        else
        {
            Console.WriteLine("Error: Ultron borro el archivo, por lo que se puede copiar.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al copiar el archivo: {ex.Message}");
    }
}

//Funcion para mover archivos
void MoverFile(string src, string dest)
{
    try
    {
        CrearDir(Path.GetDirectoryName(dest));
        if (File.Exists(src))
        {
            File.Move(src, dest);
            Console.WriteLine("Archivo movido a ArchivosClasificados.");
        }
        else
        {
            Console.WriteLine("Error: Ultron borro el archivo, por lo que no se puede mover.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al mover el archivo: {ex.Message}");
    }
}

//Funcion para listar archivos
void ListarFiles(string path)
{
    try
    {
        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path);

            if (files.Length > 0)
            {
                Console.WriteLine("\nArchivos en LaboratorioAvengers:");
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
            }
            else
            {
                Console.WriteLine("\nLa carpeta LaboratorioAvengers está vacía, ultron debio haber borrado su contenido");
            }
        }
        else
        {
            Console.WriteLine("Error: La carpeta no existe, ultron la debio haber eliminado");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al listar archivos: {ex.Message}");
    }
}

//Funcion para eliminar archivos
void EliminarFile(string path)
{
    try
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine("Archivo inventos.txt eliminado.");
        }
        else
        {
            Console.WriteLine("Error: El archivo no existe, ultron lo debio haber borrado por lo que no se puede eliminar.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al eliminar el archivo: {ex.Message}");
    }
}
