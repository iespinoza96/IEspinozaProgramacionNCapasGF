//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    
    public partial class DireccionGetByIdAlumno_Result
    {
        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public Nullable<int> IdColonia { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public Nullable<int> IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public string Estado { get; set; }
        public Nullable<byte> IdPais { get; set; }
        public string Pais { get; set; }
        public Nullable<int> IdAlumno { get; set; }
        public string Alumno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public byte[] Imagen { get; set; }
    }
}
