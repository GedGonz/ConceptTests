using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocks
{
    public class Assistance: IAssitance
    {
        public DateTime date { get; set; } = DateTime.Now;
        public List<Persona> personas { get; set; }

        public bool dateIsNow(DateTime _date) 
        {
            return _date.Year==date.Year;
        }
        public Persona addPersona(Persona persona)
        {
            personas.Add(persona);

            return persona;
        }
        public bool isValid()
        {
            return true;
        }
    }
}
