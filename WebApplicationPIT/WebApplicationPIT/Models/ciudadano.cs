//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationPIT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class ciudadano
    {
        [DisplayName("ID")]
        public int idciudadano { get; set; }
        [DisplayName("Nombres")]
        public string nombres { get; set; }
        [DisplayName("Nacionalidad")]
        public string nacionalidad { get; set; }
        [DisplayName("Documento")]
        public string tipodocumento { get; set; }
        [DisplayName("Numero de  Documento")]
        public string numdocumento { get; set; }
        [DisplayName("Departamento")]
        public string iddepartamento { get; set; }
        [DisplayName("Provincia")]
        public string idprovincia { get; set; }
        [DisplayName("Distrito")]
        public string iddistrito { get; set; }
        [DisplayName("Estado")]
        public int idestado { get; set; }

    
        public virtual estado estado { get; set; }
    }
}
