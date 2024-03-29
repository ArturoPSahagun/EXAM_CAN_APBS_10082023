﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace surtidora_api.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class surtidoradbEntities : DbContext
    {
        public surtidoradbEntities()
            : base("name=surtidoradbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<SP_Actualizar_Result> SP_Actualizar(Nullable<int> idPer, string nombre, string paterno, string materno, string rFC, Nullable<System.DateTime> fNacimiento, Nullable<int> usuario)
        {
            var idPerParameter = idPer.HasValue ?
                new ObjectParameter("IdPer", idPer) :
                new ObjectParameter("IdPer", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var paternoParameter = paterno != null ?
                new ObjectParameter("Paterno", paterno) :
                new ObjectParameter("Paterno", typeof(string));
    
            var maternoParameter = materno != null ?
                new ObjectParameter("Materno", materno) :
                new ObjectParameter("Materno", typeof(string));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var fNacimientoParameter = fNacimiento.HasValue ?
                new ObjectParameter("FNacimiento", fNacimiento) :
                new ObjectParameter("FNacimiento", typeof(System.DateTime));
    
            var usuarioParameter = usuario.HasValue ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Actualizar_Result>("SP_Actualizar", idPerParameter, nombreParameter, paternoParameter, maternoParameter, rFCParameter, fNacimientoParameter, usuarioParameter);
        }
    
        public virtual ObjectResult<SP_Eliminar_Result> SP_Eliminar(Nullable<int> idPer)
        {
            var idPerParameter = idPer.HasValue ?
                new ObjectParameter("IdPer", idPer) :
                new ObjectParameter("IdPer", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Eliminar_Result>("SP_Eliminar", idPerParameter);
        }
    
        public virtual ObjectResult<SP_NuevaPersona_Result> SP_NuevaPersona(string nombre, string paterno, string materno, string rFC, Nullable<System.DateTime> fNacimiento, Nullable<int> usuario)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var paternoParameter = paterno != null ?
                new ObjectParameter("Paterno", paterno) :
                new ObjectParameter("Paterno", typeof(string));
    
            var maternoParameter = materno != null ?
                new ObjectParameter("Materno", materno) :
                new ObjectParameter("Materno", typeof(string));
    
            var rFCParameter = rFC != null ?
                new ObjectParameter("RFC", rFC) :
                new ObjectParameter("RFC", typeof(string));
    
            var fNacimientoParameter = fNacimiento.HasValue ?
                new ObjectParameter("FNacimiento", fNacimiento) :
                new ObjectParameter("FNacimiento", typeof(System.DateTime));
    
            var usuarioParameter = usuario.HasValue ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_NuevaPersona_Result>("SP_NuevaPersona", nombreParameter, paternoParameter, maternoParameter, rFCParameter, fNacimientoParameter, usuarioParameter);
        }
    }
}
