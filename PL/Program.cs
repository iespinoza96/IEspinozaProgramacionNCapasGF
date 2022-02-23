using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Procedimientos materia
            int materia = 0;
            Console.WriteLine("Bienvenido a Materia");
            Console.WriteLine("Elija el procedimiento a realizar");
            Console.WriteLine("1.-Agregar Materia");
            Console.WriteLine("2.-Actualizar Materia");
            Console.WriteLine("3.-Eliminar Materia");
            Console.WriteLine("4.-Seleccionar Materias");
            Console.WriteLine("5.-Seleccionar solo una Materia");
            materia = int.Parse(Console.ReadLine());
            switch (materia)
            {
                case 1:
                    Materia.Add();//agregar materia
                    Console.ReadKey();
                    break;

                case 2:
                    Materia.Update();//actualizar materia
                    Console.ReadKey();
                    break;

                case 3:
                    Materia.Delete();//borrar 
                    Console.ReadKey();

                    break;

                case 4:
                    Materia.GetAll(); //seleccionar
                    Console.ReadKey();
                    break;

                case 5:
                    Materia.GetById();//traer solo uno
                    Console.ReadKey();
                    break;


            }
        }
    }
}
