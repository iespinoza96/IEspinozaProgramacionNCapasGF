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
            ML.Result result = BL.Alumno.AddLinq(direccion.Alumno); //EF
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

        public static void Delete()
        {
            ML.Direccion direccion = new ML.Direccion();

            Console.WriteLine("Ingrese el IdAlumno:");
            direccion.Alumno = new ML.Alumno();
            direccion.Alumno.IdAlumno = int.Parse(Console.ReadLine());
            ML.Result resultDireccion= BL.Direccion.GetByIdAlumno(direccion.Alumno.IdAlumno);

            //result->Object->Direccion->IdDireccion

            ML.Direccion direccionItem = (ML.Direccion)resultDireccion.Object;
            //id, calle, num int 

            ML.Result resultDeleteDireccion= BL.Direccion.Delete(direccionItem.IdDireccion);

            if(resultDeleteDireccion.Correct)
            {
                ML.Result resultDeleteAlumno = BL.Alumno.Delete(direccion.Alumno.IdAlumno);

                if (resultDeleteAlumno.Correct)
                {
                    Console.WriteLine("Alumno eliminado correctamente");
                }
                else
                {

                }
            }
            else
            {
                //no se pudo eliminar al alumno ya que ocurrió un error al eliminar la dirección
            }
            


            //ML.Result result = BL.Alumno.AddLinq(direccion.Alumno); //EF

            //if (result.Correct)
            //{
            //    direccion.Alumno.IdAlumno = ((int)result.Object);  //unboxing GUARDAR ID DIRECCION
            //    ML.Result resultDireccion = BL.Direccion.Add(direccion);
            //    if (resultDireccion.Correct)
            //    {
            //        Console.WriteLine("Alumno ingresado correctamente");
            //        Console.WriteLine("Direccion ingresada correctamente");
            //        Console.ReadLine();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Ocurrió un error al insertar el registro en la tabla direccion " + result.ErrorMessage);
            //        Console.ReadLine();
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Ocurrió un error al insertar el registro en la tabla alumno " + result.ErrorMessage);
            //    Console.ReadLine();
            //}
        }
    }
}
