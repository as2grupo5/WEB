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
    
    public partial class T_Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Clientes()
        {
            this.T_Factura = new HashSet<T_Factura>();
        }
    
        public int Id_cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Nit { get; set; }
        public Nullable<int> Telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Factura> T_Factura { get; set; }
    }
}
