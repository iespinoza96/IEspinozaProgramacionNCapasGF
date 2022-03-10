﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Direccion direccion = new ML.Direccion();

             direccion.Alumno = new ML.Alumno();
             direccion.Colonia = new ML.Colonia();
             direccion.Colonia.Municipio = new ML.Municipio();
             direccion.Colonia.Municipio.Estado = new ML.Estado();
             direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
             ML.Result resultPais = BL.Pais.GetAllEF();
             direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

            if (IdAlumno == null)
            {
                
                return View(direccion);
            }
            else
            {
                ML.Result result = BL.Alumno.GetById(IdAlumno.Value);
                if (result.Correct)
                {
                    
                    direccion.Colonia = new ML.Colonia();
                    direccion.Colonia.Municipio = new ML.Municipio();
                    direccion.Colonia.Municipio.Estado = new ML.Estado();
                    direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                    direccion.Alumno = ((ML.Alumno)result.Object);

                    ML.Result resultEstados = BL.Estado.EstadoGetByIdPais(direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Result resultMunicipios = BL.Municipio.MunicipioGetByIdEstado(direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultColonias = BL.Colonia.ColoniaGetByIdMunicipio(direccion.Colonia.Municipio.IdMunicipio);
                    ML.Result resultDirecciones = BL.Direccion.DireccionGetByIdColonia(direccion.Colonia.IdColonia);

                    direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                    direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                    direccion.Colonia.Colonias = resultColonias.Objects;


                    return View(direccion);
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error " + result.ErrorMessage;
                }
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Form(ML.Direccion direccion)
        {
            if (direccion.Alumno.IdAlumno == 0)
            {
                ML.Result result = BL.Alumno.Add(direccion.Alumno);

                if (result.Correct)
                {
                    direccion.Alumno.IdAlumno = ((int)result.Object);
                    ML.Result resultDireccion = BL.Direccion.Add(direccion);
                    if (resultDireccion.Correct)
                    {
                        ViewBag.Message = "Alumno Ingresado Correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al insertar el alumno" + resultDireccion.ErrorMessage;
                    }
                    
                }
                else
                {
                    ViewBag.Message = "Error al intentar ingresar al usuario" + result.ErrorMessage;
                }
            }
            else
            {
                ML.Result result = BL.Alumno.Update(direccion.Alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Alumno actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "Error al tratar de actualizar al usuario" + result.ErrorMessage;
                }
            }

            return PartialView("ValidationModal");
        }

        public JsonResult GetEstado(byte IdPais)
        {
            var result = BL.Estado.EstadoGetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }


    }
}