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
    
    public partial class T_Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Producto()
        {
            this.T_Detalle = new HashSet<T_Detalle>();
        }
    
        public int Id_producto { get; set; }
        public Nullable<int> Id_tipo { get; set; }
        public Nullable<int> Id_Color { get; set; }
        public Nullable<int> Id_Proveedor { get; set; }
        public string Nombre_oproducto { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> Fecha_ingreso { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public string imagen { get; set; }
    
        public virtual T_color T_color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Detalle> T_Detalle { get; set; }
        public virtual T_Proveedor T_Proveedor { get; set; }
        public virtual T_Tipo T_Tipo { get; set; }
    }
}