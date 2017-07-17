//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lppa.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClienteTitular
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClienteTitular()
        {
            this.ClienteTitular1 = new HashSet<ClienteTitular>();
            this.TarjetaDeCredito = new HashSet<TarjetaDeCredito>();
        }
    
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int CUIT { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public int EstadoCivil { get; set; }
        public Nullable<int> IngresoMensual { get; set; }
        public int Sexo { get; set; }
        public int SituacionLaboral { get; set; }
        public Nullable<int> DNIConyuge { get; set; }
        public string NombreConyuge { get; set; }
        public string ApellidoConyuge { get; set; }
        public Nullable<int> DNIAdicional { get; set; }
        public byte[] FOTO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClienteTitular> ClienteTitular1 { get; set; }
        public virtual ClienteTitular ClienteTitular2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarjetaDeCredito> TarjetaDeCredito { get; set; }
    }
}
