using System.Collections.Generic;

namespace CoreDynamic
{
    public class tabla
    {
        public tabla(int id, string nombre, List<Campo> campos)
        {
            Id = id;
            Nombre = nombre;
            this.campos = campos;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Campo> campos { get; set; }
    }
}


