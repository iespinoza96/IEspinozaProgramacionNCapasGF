using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        public static void Add()
        {
            ML.Materia materia = new ML.Materia();// instancia

            Console.WriteLine("Ingresa el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la creditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion de la materia");
            materia.Descripcion = Console.ReadLine();

            ML.Result result = BL.Materia.Add(materia); //query

            if (result.Correct)
            {
                Console.WriteLine("Materia ingresada correctamente");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Materia " + result.ErrorMessage);
                Console.ReadLine();
            }


        }

        public static void Update()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingresa el Id de la materia a actualizar");
            materia.IdMateria = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre de la materia a actualizar");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo nombre de la materia a actualizar");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre de la materia a actualizar");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre de la materia a actualizar");
            materia.Descripcion = Console.ReadLine();

            ML.Result result = BL.Materia.Update(materia);

            if (result.Correct)//true
            {
                Console.WriteLine("Se actualizó correctamente la materia");
            }
            else
            {
                Console.WriteLine("No se actualizó correctamente la materia, ocurrió este error: " + result.ErrorMessage);
            }




        }
    }
}
