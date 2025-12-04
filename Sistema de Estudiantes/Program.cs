using System;
using System.IO;
using System.Text.Json;

namespace Sistema_de_Estudiantes
{

    class Program
    {
        static void Main(string[] args)
        {
            EstudianteService service = new EstudianteService();
            service.CargarDesdeArchivo();
            {
                service.AgregarEstudiante(new Estudiante("Rolando", "Henriquez", 21, "Santo Domingo", "Desarrollo de Software", "20231022", 93.8));
                service.AgregarEstudiante(new Estudiante("Ana", "Gonzalez", 22, "Santiago", "Ingenieria Civil", "20231023", 83.5));
                service.AgregarEstudiante(new Estudiante("Luis", "Martinez", 20, "La Vega", "Medicina", "20231024", 73.9));

            }

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Sistema de Estudiantes\n");
                Console.WriteLine("1. Agregar Estudiante");
                Console.WriteLine("2. Mostrar Estudiantes");
                Console.WriteLine("3. Buscar estudiante por matrícula");
                Console.WriteLine("4. Editar estudiante");
                Console.WriteLine("5. Eliminar estudiante");
                Console.WriteLine("6. Salir ");
                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {

                    case 1:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Apellido: ");
                        string apellido = Console.ReadLine();

                        Console.Write("Edad: ");
                        int edad = int.Parse(Console.ReadLine());

                        Console.Write("Ciudad: ");
                        string ciudad = Console.ReadLine();

                        Console.Write("Carrera: ");
                        string carrera = Console.ReadLine();

                        Console.Write("Matrícula: ");
                        string matricula = Console.ReadLine();

                        Console.Write("Promedio (0–100): ");
                        double promedio = double.Parse(Console.ReadLine());

                        Estudiante nuevo = new Estudiante(nombre, apellido, edad, ciudad, carrera, matricula, promedio);

                        service.AgregarEstudiante(nuevo);
                        service.GuardarEnArchivo();
                        Console.WriteLine("Estudiante agregado exitosamente.");
                        Console.ReadKey();
                        break;


                    case 2:
                        foreach (var estudiante in service.Listar())
                        {
                            Console.WriteLine(estudiante.PresentacionEstudiante());
                        }
                        Console.ReadKey();
                        break;


                    case 3:
                        Console.Write("Ingrese la matrícula: ");
                        string matriculaBuscar = Console.ReadLine();
                        Estudiante encontrado = service.BuscarPorMatricula(matriculaBuscar);
                        if (encontrado != null)
                        {
                            Console.WriteLine("Estudiante encontrado:");
                            Console.WriteLine(encontrado.PresentacionEstudiante());
                            service.GuardarEnArchivo();
                        }
                        else
                        {
                            Console.WriteLine("Estudiante no encontrado.");
                        }
                        Console.ReadKey();
                        break;

                        case 4:
                        Console.Write("Ingrese la matrícula del estudiante a editar: ");
                        string matriculaEditar = Console.ReadLine();

                        Console.Write("Nuevo nombre: ");
                        string newNombre = Console.ReadLine();

                        Console.Write("Nuevo apellido: ");
                        string newApellido = Console.ReadLine();

                        Console.Write("Nueva edad: ");
                        int newEdad = int.Parse(Console.ReadLine());

                        Console.Write("Nueva ciudad: ");
                        string newCiudad = Console.ReadLine();

                        Console.Write("Nueva carrera: ");
                        string newCarrera = Console.ReadLine();

                        Console.Write("Nuevo promedio (0–100): ");
                        double newPromedio = double.Parse(Console.ReadLine());

                        service.Editar(matriculaEditar, newNombre, newApellido, newEdad, newCiudad, newCarrera, newPromedio);
                        service.GuardarEnArchivo();
                        Console.WriteLine("Estudiante actualizado correctamente.");
                        Console.ReadKey();
                        break;


                    case 5:
                        Console.Write("Ingrese la matrícula del estudiante a eliminar: ");
                        string matriculaEliminar = Console.ReadLine();

                        service.Eliminar(matriculaEliminar);
                        service.GuardarEnArchivo();
                        Console.WriteLine("Estudiante eliminado.");
                        Console.ReadKey();
                        break;

                    case 6:
                            Console.WriteLine("Saliendo del sistema...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 6);

        }
    }
}