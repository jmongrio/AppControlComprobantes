//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppControlComprobantes.MVVM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.ComprobanteDeposito = new HashSet<ComprobanteDeposito>();
        }
    
        public int Id { get; set; }
        public int TipoCedulaRef { get; set; }
        public string NumeroCedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Puesto { get; set; }
        public int TipoPermisosRef { get; set; }
        public string Contrasenna { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComprobanteDeposito> ComprobanteDeposito { get; set; }
        public virtual TipoCedula TipoCedula { get; set; }
        public virtual TipoPermisos TipoPermisos { get; set; }
    }
}
