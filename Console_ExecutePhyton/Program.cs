using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Console_ExecutePhyton
{

    class Program
    {
        static void Main(string[] args)
        {
            var listapersonas = new List<persona>() { new persona(1,"pedro","garcia",20),
                                                    new persona(1, "carlos", "lopez",20),
                                                    new persona(1, "eduardo", "mora",10)
            };


            //dynamic pyrpogram = CreateEngynePython("hola.py");
            //Console.WriteLine("*****Saludo******");
            //pyrpogram.Saludo("Gerald Gonzalez");

            //Console.WriteLine("*****Lista enviada e iterada en python******");
            //pyrpogram.Lista(listapersonas);

           FilterFieldDynamics(listapersonas);
        }

        private static void FilterFieldDynamics(List<persona> listapersonas)
        {
            var file = File.ReadAllText("hola.py");
            Console.WriteLine("cree el filtro con los campos: age, name y lastname");
            var field = Console.ReadLine();
            Console.WriteLine($"digite el valor del campo {field} = ");
            var value = Console.ReadLine();
            file = file.Replace("*field*", field);
            file = file.Replace("*value*", value);
            File.Delete("hola.py");
            File.WriteAllText("hola.py", file);

            dynamic pyrpogram = CreateEngynePython("hola.py");

            Console.WriteLine("*****Lista enviada y filtrada en python******");
            var _listfiler = pyrpogram.ListaFiltrada(listapersonas);

            showElements(_listfiler);

        }

        private static void showElements(dynamic _listfiler)
        {
            foreach (var element in _listfiler)
            {
                Console.WriteLine(element.name);
                Console.WriteLine(element.lastname);
                Console.WriteLine(element.age);
            }
        }

        private static dynamic CreateEngynePython(string filepath)
        {
            var py = Python.CreateRuntime();

            dynamic pyrpogram = py.UseFile(filepath);
            return pyrpogram;
        }
    }


    public class persona
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }

        public persona(int id, string name, string lastname, int age)
        {
            this.id = id;
            this.name = name;
            this.lastname = lastname;
            this.age = age;
        }

    }
}
