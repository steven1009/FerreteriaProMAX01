﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FerreteriaProMAX01.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FerreteriaDBEntities : DbContext
    {
        public FerreteriaDBEntities()
            : base("name=FerreteriaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<CompraProdProv> CompraProdProv { get; set; }
        public virtual DbSet<DetalleEstado> DetalleEstado { get; set; }
        public virtual DbSet<DetalleEstadoUsuario> DetalleEstadoUsuario { get; set; }
        public virtual DbSet<DetalleRoles> DetalleRoles { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<IdDetalleProvProd> IdDetalleProvProd { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<proveedores> proveedores { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<USUARIO_LOGIN> USUARIO_LOGIN { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
    
        public virtual ObjectResult<Nullable<int>> BuscarApellido(string apellido)
        {
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarApellido", apellidoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuscarCedula(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarCedula", cedulaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuscarCodigo(Nullable<int> codigo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarCodigo", codigoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuscarEmpleado(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarEmpleado", nombreParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuscarNombre(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarNombre", nombreParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuscarProducto(Nullable<int> idproducto)
        {
            var idproductoParameter = idproducto.HasValue ?
                new ObjectParameter("idproducto", idproducto) :
                new ObjectParameter("idproducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarProducto", idproductoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuscarUsuario(string usuario)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("usuario", usuario) :
                new ObjectParameter("usuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarUsuario", usuarioParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<int>> UserPassword(string usuario, string password)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("usuario", usuario) :
                new ObjectParameter("usuario", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UserPassword", usuarioParameter, passwordParameter);
        }
    
        public virtual ObjectResult<BuscarCedulaP_Result> BuscarCedulaP(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarCedulaP_Result>("BuscarCedulaP", cedulaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> BuscarEmpleadoU(Nullable<int> idusuario)
        {
            var idusuarioParameter = idusuario.HasValue ?
                new ObjectParameter("idusuario", idusuario) :
                new ObjectParameter("idusuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("BuscarEmpleadoU", idusuarioParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> ObtenerVenta()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ObtenerVenta");
        }
    
        public virtual ObjectResult<DetailsVentas_Result> DetailsVentas(Nullable<int> idVenta)
        {
            var idVentaParameter = idVenta.HasValue ?
                new ObjectParameter("idVenta", idVenta) :
                new ObjectParameter("idVenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetailsVentas_Result>("DetailsVentas", idVentaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> buscarventad(Nullable<int> idDetallev, Nullable<int> idVenta)
        {
            var idDetallevParameter = idDetallev.HasValue ?
                new ObjectParameter("idDetallev", idDetallev) :
                new ObjectParameter("idDetallev", typeof(int));
    
            var idVentaParameter = idVenta.HasValue ?
                new ObjectParameter("idVenta", idVenta) :
                new ObjectParameter("idVenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("buscarventad", idDetallevParameter, idVentaParameter);
        }
    
        public virtual ObjectResult<sp_DettalleRoles_Result> sp_DettalleRoles(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_DettalleRoles_Result>("sp_DettalleRoles", idUsuarioParameter);
        }
    }
}
