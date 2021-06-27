using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocks
{
    public class Persona
    {
        public Persona(string name, string lasName)
        {
            Name = name;
            LasName = lasName;
        }

        public string Name { get; set; }
        public string LasName { get; set; }
    }
}
