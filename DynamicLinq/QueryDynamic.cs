using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace DynamicLinq
{
    public class QueryDynamic : SelectStatement<Persona>
    {
        public QueryDynamic(IQueryable<Persona> personas)
        {
            this.personas = personas;
        }

        private IQueryable<Persona> personas { get; set; }

        public List<Persona> GetPersonasMayores10() {

            var listado = personas.Where(x=>x.Edad>10).ToList();

            return listado;
        }

        public List<Persona> GetPersonasFiltroDinamico(string filedFilter,params object[] Params)
        {
            var listado = personas.Where(filedFilter, Params).ToList();

            return listado;
        }

        public List<Persona> GetPersonasSelectDinamico(string valueColumns)
        {
            var listado = personas.Select(SelectColumn(valueColumns)).ToList();

            return listado;
        }
    }


}
