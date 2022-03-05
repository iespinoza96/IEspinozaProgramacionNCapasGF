using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct { get; set; }//1-0
        public Exception Ex { get; set; }//excepcion
        public string ErrorMessage { get; set; } //guardar el error
        public object Object { get; set; } //objeto
        public List<object> Objects { get; set; } //lista objetos 
    }
}
