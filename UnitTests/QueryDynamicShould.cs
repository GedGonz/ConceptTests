using DynamicLinq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{

    public class QueryDynamicShould
    {
        IQueryable<Persona> personas;
        public QueryDynamicShould()
        {
            var persona1 = new Persona(1, "Nombre1", "Apellido1", 5);
            var persona2 = new Persona(1, "Nombre2", "Apellido2", 8);
            var persona3 = new Persona(1, "Nombre3", "Apellido3", 11);
            var persona4 = new Persona(1, "Nombre4", "Apellido4", 25);
            var persona5 = new Persona(1, "Nombre5", "Apellido5", 45);
            personas = new List<Persona>() { persona1, persona2, persona3, persona4, persona5 }.AsQueryable();
        }

        [Theory(DisplayName = "Verifica que el numero de personas mayores a 10 años sean las enviadas con filtro dinamico")]
        [InlineData(3)]
        public void Get_Persons_Older_than_10_year_FilterDynamic(int countPerson)
        {
            //Arange

            var queryDynamic = new QueryDynamic(personas);
            var filter = "Edad>";
            //Act
            var Personas = queryDynamic.GetPersonasFiltroDinamico(filter, "10");

            //Assert
            Personas.Should().HaveCount(countPerson);
        }

        [Theory(DisplayName = "Verifica que se filtre el nombre de la persona dinamicamente")]
        [InlineData("Nombre1")]
        public void Get_Persons_for_FilterName_Dynamic(string nombre)
        {
            //Arange
            var queryDynamic = new QueryDynamic(personas);
            var filter = "Nombre==";
            //Act
            var Personas = queryDynamic.GetPersonasFiltroDinamico(filter, nombre);

            //Assert
            Personas.Should().HaveCount(1);
        }


        [Theory(DisplayName = "Verifica que se filtre el nombre de la persona dinamicamente")]
        [InlineData("Nombre1", "Apellido1")]
        public void Get_Persons_for_FilterName_LastNam_Dynamic(string nombre, string apellido)
        {
            //Arange
            var queryDynamic = new QueryDynamic(personas);
            var filter = $"Nombre==@0 and Apellido==@1";
            //Act
            var Personas = queryDynamic.GetPersonasFiltroDinamico(filter,nombre,apellido);

            //Assert
            Personas.Should().HaveCount(1);
        }


        [Theory(DisplayName = "Verifica que se seleccione solo el Nombre")]
        [InlineData("Nombre")]
        public void Get_Persons_with_Column_Name(string columnas)
        {
            //Arange

            var persona6 = new Persona(0, "Nombre1", null ,0);
            var persona7 = new Persona(0, "Nombre2", null, 0);
            var persona8 = new Persona(0, "Nombre3", null, 0);
            var persona9 = new Persona(0, "Nombre4", null, 0);
            var persona10 = new Persona(0, "Nombre5", null, 0);

            var queryDynamic = new QueryDynamic(personas);
            //Act
            var Personas = queryDynamic.GetPersonasSelectDinamico(columnas);

            //Assert
            Personas.Should().BeEquivalentTo(new List<Persona>() { persona6, persona7, persona8, persona9, persona10 });
        }

        [Theory(DisplayName = "Verifica que se seleccione solo el Nombre y Apellido")]
        [InlineData("Nombre,Apellido")]
        public void Get_Persons_with_Column_Name_And_Lastname(string columnas)
        {
            //Arange

            var persona6 = new Persona(0, "Nombre1", "Aplleido1", 0);
            var persona7 = new Persona(0, "Nombre2", "Aplleido2", 0);
            var persona8 = new Persona(0, "Nombre3", "Aplleido3", 0);
            var persona9 = new Persona(0, "Nombre4", "Aplleido4", 0);
            var persona10 = new Persona(0, "Nombre5", "Aplleido5", 0);

            var queryDynamic = new QueryDynamic(personas);
            //Act
            var Personas = queryDynamic.GetPersonasSelectDinamico(columnas);

            //Assert
            Personas.Should().BeEquivalentTo(new List<Persona>() { persona6, persona7, persona8, persona9, persona10 });
        }
    }
}
