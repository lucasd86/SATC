using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lppa.UI.Website.Models
{
    public class ClienteModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int CUIT { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        public Nullable<int> IngresoMensual { get; set; }
        public string Sexo { get; set; }
        public string SituacionLaboral { get; set; }
        public Nullable<int> DNIConyuge { get; set; }
        public string NombreConyuge { get; set; }
        public string ApellidoConyuge { get; set; }
        public Nullable<int> DNIAdicional { get; set; }
    }
}