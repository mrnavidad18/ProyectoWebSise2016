//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoMiniMarket
{
    using System;
    using System.Collections.Generic;
    
    public partial class categorias
    {
        public categorias()
        {
            this.productos = new HashSet<productos>();
        }
    
        public int idcategoria { get; set; }
        public string nombrecategoria { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<productos> productos { get; set; }
    }
}
