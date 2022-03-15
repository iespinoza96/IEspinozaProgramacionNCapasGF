using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result Add(ML.Direccion direccion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DireccionAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Calle", SqlDbType.VarChar);
                        collection[0].Value = direccion.Calle;

                        collection[1] = new SqlParameter("NumeroExterior", SqlDbType.VarChar);
                        collection[1].Value = direccion.NumeroExterior;

                        collection[2] = new SqlParameter("NumeroInterior", SqlDbType.VarChar);
                        collection[2].Value = direccion.NumeroInterior;

                        collection[3] = new SqlParameter("IdColonia", SqlDbType.Int);
                        collection[3].Value = direccion.Colonia.IdColonia;

                        collection[4] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[4].Value = direccion.Alumno.IdAlumno;

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

        public static ML.Result GetByIdAlumno(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DireccionGetByIdAlumno";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open(); //se abre la conexion a la base

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);

                        DataTable direccionTable = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(direccionTable);

                        if (direccionTable.Rows.Count > 0)
                        {
                            DataRow row = direccionTable.Rows[0];//1

                            ML.Direccion direccion = new ML.Direccion();

                            direccion.IdDireccion = int.Parse(row[0].ToString());
                            direccion.Calle = row[1].ToString();
                            direccion.NumeroExterior = row[2].ToString();
                            direccion.NumeroInterior = row[3].ToString();

                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = int.Parse(row[4].ToString());
                            direccion.Colonia.Nombre = row[5].ToString();
                            direccion.Colonia.CP = row[6].ToString();

                            direccion.Colonia.Municipio = new ML.Municipio();
                            direccion.Colonia.Municipio.IdMunicipio = int.Parse(row[7].ToString());
                            direccion.Colonia.Municipio.Nombre = row[8].ToString();

                            direccion.Colonia.Municipio.Estado = new ML.Estado();
                            direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(row[9].ToString());
                            direccion.Colonia.Municipio.Estado.Nombre = row[10].ToString();

                            direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            direccion.Colonia.Municipio.Estado.Pais.IdPais = byte.Parse(row[11].ToString());
                            direccion.Colonia.Municipio.Estado.Pais.Nombre = row[12].ToString();

                            direccion.Alumno = new ML.Alumno();
                            direccion.Alumno.IdAlumno = int.Parse(row[13].ToString());
                            direccion.Alumno.Nombre = row[14].ToString();
                            direccion.Alumno.ApellidoPaterno = row[15].ToString();
                            direccion.Alumno.ApellidoMaterno = row[16].ToString();
                            direccion.Alumno.FechaNacimiento = row[17].ToString();
                           

                            result.Object = direccion; //boxing
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

        public static ML.Result Delete(int IdDireccion)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DireccionDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context; //cadena de conexion
                        cmd.CommandText = query; //query
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDireccion", SqlDbType.Int);
                        collection[0].Value = IdDireccion;

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

        public static ML.Result DireccionGetByIdColonia(int IdColonia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {
                    var query = context.DireccionGetByIdColonia(IdColonia).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Direccion direccion = new ML.Direccion();
                            direccion.IdDireccion = obj.IdDireccion;
                            direccion.Calle = obj.Calle;
                            direccion.NumeroExterior = obj.NumeroExterior;
                            direccion.NumeroInterior = obj.NumeroInterior;
                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = obj.IdColonia.Value;

                            result.Objects.Add(direccion);

                        }
                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = " No existen registros en la tabla Pais";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    //query
                    string query = "DireccionGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;//utilizar Stored Procedure

                        DataTable direccionTable = new DataTable();//instnacia de mi DataTable

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(direccionTable);

                        if (direccionTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in direccionTable.Rows)
                            {
                                ML.Direccion direccion = new ML.Direccion();

                                direccion.IdDireccion = int.Parse(row[0].ToString());
                                direccion.Calle = row[1].ToString();
                                direccion.NumeroExterior = row[2].ToString();
                                direccion.NumeroInterior = row[3].ToString();

                                direccion.Colonia = new ML.Colonia();
                                direccion.Colonia.IdColonia = int.Parse(row[4].ToString());
                                direccion.Colonia.Nombre = row[5].ToString();
                                direccion.Colonia.CP = row[6].ToString();

                                direccion.Colonia.Municipio = new ML.Municipio();
                                direccion.Colonia.Municipio.IdMunicipio = int.Parse(row[7].ToString());
                                direccion.Colonia.Municipio.Nombre = row[8].ToString();

                                direccion.Colonia.Municipio.Estado = new ML.Estado();
                                direccion.Colonia.Municipio.Estado.IdEstado = int.Parse(row[9].ToString());
                                direccion.Colonia.Municipio.Estado.Nombre = row[10].ToString();

                                direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                                direccion.Colonia.Municipio.Estado.Pais.IdPais = byte.Parse(row[11].ToString());
                                direccion.Colonia.Municipio.Estado.Pais.Nombre = row[12].ToString();

                                direccion.Alumno = new ML.Alumno();
                                direccion.Alumno.IdAlumno = int.Parse(row[13].ToString());
                                direccion.Alumno.Nombre = row[14].ToString();
                                direccion.Alumno.ApellidoPaterno = row[15].ToString();
                                direccion.Alumno.ApellidoMaterno = row[16].ToString();
                                direccion.Alumno.FechaNacimiento = row[17].ToString();

                                result.Objects.Add(direccion);
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

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {
                    var query = context.DireccionGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {

                            ML.Direccion direccion = new ML.Direccion();

                            direccion.IdDireccion = obj.IdDireccion;
                            direccion.Calle = obj.Calle;
                            direccion.NumeroExterior = obj.NumeroExterior;
                            direccion.NumeroInterior = obj.NumeroInterior;

                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = obj.IdColonia.Value;
                            direccion.Colonia.Nombre = obj.Colonia;
                            direccion.Colonia.CP = obj.CodigoPostal;

                            direccion.Colonia.Municipio = new ML.Municipio();
                            direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                            direccion.Colonia.Municipio.Nombre = obj.Municipio;

                            direccion.Colonia.Municipio.Estado = new ML.Estado();
                            direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                            direccion.Colonia.Municipio.Estado.Nombre = obj.Estado;

                            direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais.Value;
                            direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.Pais;

                            direccion.Alumno = new ML.Alumno();
                            direccion.Alumno.IdAlumno = obj.IdAlumno.Value;
                            direccion.Alumno.Nombre = obj.Alumno;
                            direccion.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            direccion.Alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            direccion.Alumno.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            direccion.Alumno.Imagen = obj.Imagen;

                            result.Objects.Add(direccion);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }

            }
            catch (Exception ex )
            {

                //throw;
            }
            return result;
        }

        public static ML.Result DireccionGetByIdAlumno(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {
                    var query = context.DireccionGetByIdAlumno(IdAlumno).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        ML.Direccion direccion = new ML.Direccion();

                        direccion.IdDireccion = query.IdDireccion;
                        direccion.Calle = query.Calle;
                        direccion.NumeroExterior = query.NumeroExterior;
                        direccion.NumeroInterior = query.NumeroInterior;

                        direccion.Colonia = new ML.Colonia();
                        direccion.Colonia.IdColonia = query.IdColonia.Value;
                        direccion.Colonia.Nombre = query.Colonia;
                        direccion.Colonia.CP = query.CodigoPostal;

                        direccion.Colonia.Municipio = new ML.Municipio();
                        direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio.Value;
                        direccion.Colonia.Municipio.Nombre = query.Municipio;

                        direccion.Colonia.Municipio.Estado = new ML.Estado();
                        direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado.Value;
                        direccion.Colonia.Municipio.Estado.Nombre = query.Estado;

                        direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais.Value;
                        direccion.Colonia.Municipio.Estado.Pais.Nombre = query.Pais;

                        direccion.Alumno = new ML.Alumno();
                        direccion.Alumno.IdAlumno = query.IdAlumno.Value;
                        direccion.Alumno.Nombre = query.Alumno;
                        direccion.Alumno.ApellidoPaterno = query.ApellidoPaterno;
                        direccion.Alumno.ApellidoMaterno = query.ApellidoMaterno;
                        direccion.Alumno.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        direccion.Alumno.Imagen = query.Imagen;

                        result.Object = direccion;

                        
                        result.Correct = true;

                    }
                    else
                    {

                        result.Correct = false;
                        result.ErrorMessage = " No existen registros en la tabla Pais";
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
