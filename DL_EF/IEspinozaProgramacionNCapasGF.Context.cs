﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IEspinozaProgramacionNCapasGFEntities : DbContext
    {
        public IEspinozaProgramacionNCapasGFEntities()
            : base("name=IEspinozaProgramacionNCapasGFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumnoes { get; set; }
        public virtual DbSet<Colonia> Colonias { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
    
        public virtual int AlumnoAdd(string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento, ObjectParameter idAlumno)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AlumnoAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, fechaNacimientoParameter, idAlumno);
        }
    
        public virtual int DireccionAdd(string calle, string numeroExterior, string numeroInterior, Nullable<int> idColonia, Nullable<int> idAlumno)
        {
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            var idAlumnoParameter = idAlumno.HasValue ?
                new ObjectParameter("IdAlumno", idAlumno) :
                new ObjectParameter("IdAlumno", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DireccionAdd", calleParameter, numeroExteriorParameter, numeroInteriorParameter, idColoniaParameter, idAlumnoParameter);
        }
    
        public virtual int MateriaAdd(string nombre, Nullable<decimal> costo, Nullable<byte> creditos, string descripcion, Nullable<byte> idSemestre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(decimal));
    
            var creditosParameter = creditos.HasValue ?
                new ObjectParameter("Creditos", creditos) :
                new ObjectParameter("Creditos", typeof(byte));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var idSemestreParameter = idSemestre.HasValue ?
                new ObjectParameter("IdSemestre", idSemestre) :
                new ObjectParameter("IdSemestre", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaAdd", nombreParameter, costoParameter, creditosParameter, descripcionParameter, idSemestreParameter);
        }
    
        public virtual int MateriaDelete(Nullable<int> idMateria)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaDelete", idMateriaParameter);
        }
    
        public virtual ObjectResult<MateriaGetAll_Result> MateriaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MateriaGetAll_Result>("MateriaGetAll");
        }
    
        public virtual ObjectResult<MateriaGetById_Result> MateriaGetById(Nullable<int> idMateria)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MateriaGetById_Result>("MateriaGetById", idMateriaParameter);
        }
    
        public virtual int MateriaUpdate(Nullable<int> idMateria, string nombre, Nullable<decimal> costo, Nullable<byte> creditos, string descripcion, Nullable<byte> idSemestre)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var costoParameter = costo.HasValue ?
                new ObjectParameter("Costo", costo) :
                new ObjectParameter("Costo", typeof(decimal));
    
            var creditosParameter = creditos.HasValue ?
                new ObjectParameter("Creditos", creditos) :
                new ObjectParameter("Creditos", typeof(byte));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var idSemestreParameter = idSemestre.HasValue ?
                new ObjectParameter("IdSemestre", idSemestre) :
                new ObjectParameter("IdSemestre", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MateriaUpdate", idMateriaParameter, nombreParameter, costoParameter, creditosParameter, descripcionParameter, idSemestreParameter);
        }
    }
}
