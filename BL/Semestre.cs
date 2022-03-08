using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Semestre
    {
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
        //        {
        //            var query = context.SemestreGetAll().ToList();

        //            result.Objects = new List<object>();

        //            foreach ( row in )
        //            {
        //                ML.Materia materia = new ML.Materia();

        //                materia.IdMateria = int.Parse(row[0].ToString());
        //                materia.Nombre = row[1].ToString();
        //                materia.Costo = decimal.Parse(row[2].ToString());
        //                materia.Creditos = byte.Parse(row[3].ToString());
        //                materia.Descripcion = row[4].ToString();
        //                materia.Semestre = new ML.Semestre();
        //                materia.Semestre.IdSemestre = byte.Parse(row[5].ToString());

        //                result.Objects.Add(materia);
        //            }


        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return result;
        //}

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //query
                    string query = "SemestreGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;//utilizar Stored Procedure

                        DataTable semestreTable = new DataTable();//instnacia de mi DataTable

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(semestreTable);

                        if (semestreTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in semestreTable.Rows)
                            {
                                ML.Semestre semestre= new ML.Semestre();

                                semestre.IdSemestre = byte.Parse(row[0].ToString());
                                semestre.Nombre = row[1].ToString();

                                result.Objects.Add(semestre);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
