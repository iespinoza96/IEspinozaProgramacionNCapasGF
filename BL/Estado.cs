﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result EstadoGetByIdPais(byte IdPais)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGFEntities context = new DL_EF.IEspinozaProgramacionNCapasGFEntities())
                {
                    var query = context.EstadoGetByIdPais(IdPais).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = obj.IdEstado;
                            estado.Nombre = obj.Nombre;
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = obj.IdPais.Value;

                            result.Objects.Add(estado);

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
    }
}
