using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = alumno.FechaNacimiento;

                        collection[4] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[4].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        result.Object = Convert.ToInt32(cmd.Parameters["IdAlumno"].Value);//boxing

                        if (RowsAffected > 0) //1
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }

            return result;
        }

        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {
                    ObjectParameter IdAlumno = new ObjectParameter("IdAlumno", typeof(int));
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.FechaNacimiento, IdAlumno);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Object = Convert.ToInt32(IdAlumno.Value);
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }
            return result;
        }

        public static ML.Result GetAllLinq()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {

                    var alumnosList = (from alumnoTable in context.Alumnoes
                                       select
                                       new
                                       {
                                           IdAlumno = alumnoTable.IdAlumno,
                                           NombreAlumno = alumnoTable.Nombre,
                                           ApellidoPaterno = alumnoTable.ApellidoPaterno
                                       }
                                       ).ToList();


                    if (alumnosList.Count > 0)
                    {
                        foreach (var alumnoItem in alumnosList)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = alumnoItem.IdAlumno;
                            alumno.Nombre = alumnoItem.NombreAlumno;
                            alumno.ApellidoPaterno = alumnoItem.ApellidoPaterno;
                            alumno.ApellidoMaterno = alumnoItem.ApellidoPaterno;
                        }
                    }
                    //{
                    //    result.Correct = true;
                    //    result.Object = Convert.ToInt32(IdAlumno.Value);
                    //}
                    //else
                    //{
                    //    result.Correct = false;
                    //}
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }
            return result;
        }


        public static ML.Result GetByIdLinq(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {

                    var alumnoObj = (from alumnoTable in context.Alumnoes
                                     where alumnoTable.IdAlumno == IdAlumno
                                     select
                                     new
                                     {
                                         IdAlumno = alumnoTable.IdAlumno,
                                         NombreAlumno = alumnoTable.Nombre,
                                         ApellidoPaterno = alumnoTable.ApellidoPaterno
                                     }
                                       ).FirstOrDefault();


                    if (alumnoObj != null)
                    {
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = alumnoObj.IdAlumno;
                        alumno.Nombre = alumnoObj.NombreAlumno;
                        alumno.ApellidoPaterno = alumnoObj.ApellidoPaterno;
                        alumno.ApellidoMaterno = alumnoObj.ApellidoPaterno;

                        result.Object = alumno;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }
            return result;
        }


        public static ML.Result AddLinq(ML.Alumno alumnoML) //ML
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {

                    DL_EF.Alumno alumnoDL = new DL_EF.Alumno();

                    alumnoDL.Nombre = alumnoML.Nombre;
                    alumnoDL.ApellidoPaterno = alumnoML.ApellidoPaterno;
                    alumnoDL.ApellidoMaterno = alumnoML.ApellidoMaterno;


                    context.Alumnoes.Add(alumnoDL);
                    int RowsAffected= context.SaveChanges();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                        
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al insertar el alumno";
                    }

                
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }
            return result;
        }
        //LINQ
        //Utilizar código SQL dentro de C#

        //SELECT
        //WHERE

        public static ML.Result Delete(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                       
                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        result.Object = Convert.ToInt32(cmd.Parameters["IdAlumno"].Value);//boxing

                        if (RowsAffected > 0) //1
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }

            return result;
        }

    }
}
