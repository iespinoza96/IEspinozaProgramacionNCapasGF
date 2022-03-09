using System;
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
         
            if (IdAlumno == null)
            {
                
                return View(direccion);
            }
            else
            {
                ML.Result result = BL.Alumno.GetById(IdAlumno.Value);
                if (result.Correct)
                {
                    direccion.Alumno = ((ML.Alumno)result.Object);
                    return View(direccion);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al intentar traer los campos" + result.ErrorMessage;
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


    }
}