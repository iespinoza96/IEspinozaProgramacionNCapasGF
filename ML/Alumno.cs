using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Alumno
    {
        public int IdAlumno { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public byte[] Imagen { get; set; }
        public List<object> Alumnos { get; set; }
    }
}
