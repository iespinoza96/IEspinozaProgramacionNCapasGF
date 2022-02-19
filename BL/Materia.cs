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
    }
}
