namespace CoreDynamic
{
    public class Antiguedad
    {
        public Antiguedad(int id, string descripcion, int años, Persona persona)
        {
            Id = id;
            Descripcion = descripcion;
            this.años = años;
            this.persona = persona;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int años { get; set; }
        public Persona persona { get; set; }
    }
}
