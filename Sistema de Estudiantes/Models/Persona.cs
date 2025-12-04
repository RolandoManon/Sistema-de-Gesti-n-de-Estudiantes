using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Estudiantes
{
     class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Ciudad { get; set; }


        public Persona(string nombre, string apellido, int edad, string ciudad)
        { 
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Ciudad = ciudad;
        }


        public string Presentarse()
        {
            return $"Hola, mi nombre es {Nombre} {Apellido}, tengo {Edad} años y vivo en {Ciudad}.";
        }
    }
}
