using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Direccion direccion = new ML.Direccion();
            direccion.Alumno = new ML.Alumno(); 
            direccion.Colonia = new ML.Colonia();

            Console.WriteLine("Ingrese el nombre:");
            direccion.Alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno:");
            direccion.Alumno.ApellidoPaterno=Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno:");
            direccion.Alumno.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento:");
            direccion.Alumno.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("********************************");
            Console.WriteLine("Dirección");
            Console.WriteLine("********************************");

            Console.WriteLine("Ingrese la calle: ");
            direccion.Calle =Console.ReadLine();
            Console.WriteLine("Ingrese el número exterior:");
            direccion.NumeroExterior = Console.ReadLine();
            Console.WriteLine("Ingrese el número interior:");
            direccion.NumeroInterior = Console.ReadLine();
            Console.WriteLine("Ingrese el Id de la colonia:");
            direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Alumno.Add(direccion.Alumno); //SQLClient
            ML.Result result = BL.Alumno.AddEF(direccion.Alumno); //EF
            //LINQ

            if (result.Correct)
            {
                direccion.Alumno.IdAlumno = ((int)result.Object);  //unboxing GUARDAR ID DIRECCION
                ML.Result resultDireccion = BL.Direccion.Add(direccion);
                if (resultDireccion.Correct)
                {
                    Console.WriteLine("Alumno ingresado correctamente");
                    Console.WriteLine("Direccion ingresada correctamente");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ocurrió un error al insertar el registro en la tabla direccion " + result.ErrorMessage);
                    Console.ReadLine();
                }

            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla alumno " + result.ErrorMessage);
                Console.ReadLine();
            }
        }
    }
}
