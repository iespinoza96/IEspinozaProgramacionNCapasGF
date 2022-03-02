﻿using System;
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

        public static ML.Result GetById(int IdAlumno)
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

                        DataTable direcccionTable = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(direcccionTable);

                        if (direcccionTable.Rows.Count > 0)
                        {
                            DataRow row = direcccionTable.Rows[0];

                            ML.Direccion direccion = new ML.Direccion();

                            direccion.IdDireccion = int.Parse(row[0].ToString());
                            //result.Object = materia; //Boxing  --n variable -> object

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
    }
}
