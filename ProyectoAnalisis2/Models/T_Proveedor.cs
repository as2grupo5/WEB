//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAnalisis2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Proveedor()
        {
            this.T_Producto = new HashSet<T_Producto>();
        }
    
        public int Id_proveedor { get; set; }
        public string Nombre_proveedor { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> telefono { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Producto> T_Producto { get; set; }
    }
}
