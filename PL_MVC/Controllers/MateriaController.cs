using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            ML.Materia materia = new ML.Materia();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
                return View(materia);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }

        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.Semestre = new ML.Semestre();
            ML.Result resultSemestre = BL.Semestre.GetAll();
            if (IdMateria == null)
            {
                materia.Semestre.Semestres = resultSemestre.Objects;
                return View(materia);
            }
            else
            {
                ML.Result result = BL.Materia.GetById(IdMateria.Value);
                if (result.Correct)
                {
                    materia = ((ML.Materia)result.Object);
                    return View(materia);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al intentar traer los campos" + result.ErrorMessage;
                }
            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.IdMateria == null)
            {
                ML.Result result = BL.Materia.AddEF(materia);
                if (result.Correct)
                {
                    ViewBag.Message = "Ususario Ingresado Correctamente";
                }
                else
                {
                    ViewBag.Message = "Error al intentar ingresar al usuario" + result.ErrorMessage;
                }
            }
            else
            {
                ML.Result result = BL.Materia.UpdateSP(materia);
                if (result.Correct)
                {
                    ViewBag.Message = "Usuario Actualizado Correctamente";
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