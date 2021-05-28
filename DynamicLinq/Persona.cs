using System;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLinq
{
    public class Persona
    {
        public Persona(int id, string nombre, string apellido, int edad)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        public Persona()
        {
        }

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public int Edad { get; private set; }

    }
}
