using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sistema_de_Estudiantes
{
     class Estudiante: Persona
     {
        public string Carrera { get; set; }
        public string Matricula { get; set; }
        public double Promedio { get; set; }
        public Estudiante(string nombre, string apellido, int edad, string ciudad, string carrera, string matricula, double promedio)
            : base(nombre, apellido, edad, ciudad)
        {
            Carrera = carrera;
            Matricula = matricula;
            Promedio = promedio;
        }

        public string PresentacionEstudiante()
        {
            return $"{Presentarse()} Estoy estudiando {Carrera}, mi matrícula es {Matricula} y mi promedio es {Promedio}.";
        }

     }

    class EstudianteService
    {
        private List<Estudiante> estudiantes;
        public EstudianteService()
        {
            estudiantes = new List<Estudiante>();
        }
        public void AgregarEstudiante(Estudiante estudiante)
        {
            if (BuscarPorMatricula(estudiante.Matricula) != null)
            {
                Console.WriteLine("Ya existe un estudiante con esa matrícula.");
                return;
            }
            if (estudiante.Promedio < 0 || estudiante.Promedio > 100)
            {
                Console.WriteLine("El promedio debe estar entre 0 y 100.");
                return;
            }
            if (estudiante.Edad < 0)
            {
                Console.WriteLine("La edad no puede ser negativa.");
                return;
            }
            if (string.IsNullOrWhiteSpace(estudiante.Nombre) || string.IsNullOrWhiteSpace(estudiante.Apellido) ||
                string.IsNullOrWhiteSpace(estudiante.Ciudad) || string.IsNullOrWhiteSpace(estudiante.Carrera) ||
                string.IsNullOrWhiteSpace(estudiante.Matricula))
            {
                Console.WriteLine("Todos los campos deben ser completados.");
                return;
            }
            else estudiantes.Add(estudiante);

        }
        public List<Estudiante> Listar()
        {
            return estudiantes;
        }



        public Estudiante BuscarPorMatricula(string matricula)
        {
            foreach (var e in estudiantes)
            {
                if (e.Matricula == matricula)
                {
                    return e;
                }
            }

            return null;
        }

        public Estudiante Editar(string matricula, string nuevoNombre, string nuevoApellido, int nuevaEdad, string nuevaCiudad, string nuevaCarrera, double nuevoPromedio)
        {
            Estudiante estudiante = BuscarPorMatricula(matricula);

            if (estudiante == null)
            {
                Console.WriteLine("No se encontró un estudiante con esa matrícula.");
                return null;
            }

            if (string.IsNullOrWhiteSpace(nuevoNombre) ||
                string.IsNullOrWhiteSpace(nuevoApellido) ||
                string.IsNullOrWhiteSpace(nuevaCiudad) ||
                string.IsNullOrWhiteSpace(nuevaCarrera))
            {
                Console.WriteLine("Todos los campos deben ser completados.");
                return null;
            }

            if (nuevaEdad < 0)
            {
                Console.WriteLine("La edad no puede ser negativa.");
                return null;
            }

            if (nuevoPromedio < 0 || nuevoPromedio > 100)
            {
                Console.WriteLine("El promedio debe estar entre 0 y 100.");
                return null;
            }

            estudiante.Nombre = nuevoNombre;
            estudiante.Apellido = nuevoApellido;
            estudiante.Edad = nuevaEdad;
            estudiante.Ciudad = nuevaCiudad;
            estudiante.Carrera = nuevaCarrera;
            estudiante.Promedio = nuevoPromedio;

            return estudiante;
        }


        public bool Eliminar(string matricula)
        {
            Estudiante estudiante = BuscarPorMatricula(matricula);
            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
                return true;
            }
            else
            {

                Console.WriteLine("Matricula no encontrada");
                return false;
            }

        }
        public void GuardarEnArchivo()
        {
         string json = JsonSerializer.Serialize(estudiantes, new JsonSerializerOptions { WriteIndented = true });
         File.WriteAllText("estudiantes.json", json);
        }

        public void CargarDesdeArchivo()
        {
            if (File.Exists("estudiantes.json"))
            {
                string json = File.ReadAllText("estudiantes.json");
                estudiantes = JsonSerializer.Deserialize<List<Estudiante>>(json) ?? new List<Estudiante>();
            }
        }


    }
}

