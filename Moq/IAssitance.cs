using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocks
{
    public interface IAssitance
    {
        public DateTime date { get; set; }
        public List<Persona> personas { get; set; }
        bool dateIsNow(DateTime _date);
        bool isValid();
        Persona addPersona(Persona persona);
    }
}
