namespace CoreDynamic
{
    public class Persona
    {
        public Persona(int id, string nombre, string apellido, string cargo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Cargo = cargo;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
    }
}
