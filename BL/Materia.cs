using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        //Querys 
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO [Materia]([Nombre],[Costo],Creditos,[Descripcion])VALUES(@Nombre, @Costo,@Creditos, @Descripcion)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[1].Value = materia.Costo;

                        collection[2] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[2].Value = materia.Creditos;

                        collection[3] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[3].Value = materia.Descripcion;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

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
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
           
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //query
                    string query = "UPDATE [Materia] SET [Nombre] = @Nombre ,[Costo] = @Costo ,[Creditos] = @Creditos,[Descripcion]=@Descripcion WHERE IdMateria=@IdMateria";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.Connection.Open();
                        //parámetros

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[0].Value = materia.IdMateria;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = materia.Nombre;

                        collection[2] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[2].Value = materia.Creditos;

                        collection[3] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[3].Value = materia.Costo;

                        collection[4] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[4].Value = materia.Descripcion;

                        cmd.Parameters.AddRange(collection);

                        int RowsAffected = cmd.ExecuteNonQuery();
                      
                        if(RowsAffected>0) //1
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }

                } 
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        // Stored Procedure
        public static ML.Result AddSP(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[1].Value = materia.Costo;

                        collection[2] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[2].Value = materia.Creditos;

                        collection[3] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[3].Value = materia.Descripcion;

                        collection[4] = new SqlParameter("IdSemestre", SqlDbType.TinyInt);
                        collection[4].Value = materia.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

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
        public static ML.Result UpdateSP(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[0].Value = materia.IdMateria;

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = materia.Nombre;

                        collection[1] = new SqlParameter("Costo", SqlDbType.Decimal);
                        collection[1].Value = materia.Costo;

                        collection[2] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        collection[2].Value = materia.Creditos;

                        collection[3] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[3].Value = materia.Descripcion;

                        collection[3] = new SqlParameter("IdSemestre", SqlDbType.TinyInt);
                        collection[3].Value = materia.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

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
        public static ML.Result DeleteSP(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[0].Value = materia.IdMateria;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

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
        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "MateriaGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open(); //se abre la conexion a la base

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdMateria", SqlDbType.VarChar);
                        collection[0].Value = IdMateria;

                        cmd.Parameters.AddRange(collection);

                        DataTable materiaTable = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(materiaTable);

                        if (materiaTable.Rows.Count > 0)
                        {
                            DataRow row = materiaTable.Rows[0];

                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = int.Parse(row[0].ToString());
                            materia.Nombre = row[1].ToString();
                            materia.Costo = decimal.Parse(row[2].ToString());
                            materia.Creditos = byte.Parse(row[3].ToString());
                            materia.Descripcion = row[4].ToString();
                            materia.Semestre.IdSemestre = byte.Parse(row[5].ToString());

                            result.Object = materia; //Boxing  --n variable -> object

                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //query
                    string query = "MateriaGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;//utilizar Stored Procedure

                        DataTable materiaTable = new DataTable();//instnacia de mi DataTable

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(materiaTable);

                        if (materiaTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in materiaTable.Rows)
                            {
                                ML.Materia materia = new ML.Materia();

                                materia.IdMateria = int.Parse(row[0].ToString());
                                materia.Nombre = row[1].ToString();
                                materia.Costo = decimal.Parse(row[2].ToString());
                                materia.Creditos = byte.Parse(row[3].ToString());
                                materia.Descripcion = row[4].ToString();
                                materia.Semestre = new ML.Semestre();
                                materia.Semestre.IdSemestre = byte.Parse(row[5].ToString());
                                materia.Semestre.Nombre = row[6].ToString();

                                result.Objects.Add(materia);
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

        // Entity Framework
        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo, materia.Creditos, materia.Descripcion, materia.Semestre.IdSemestre);
                    if(query > 0)
                    {
                        result.Correct = true;
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
    }
}
