using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lppa.UI.Website.Models
{
    public class TarjetaModel
    {

        public int NumeroTarjeta { get; set; }
        public string Marca { get; set; }
        public int SaldoMaximo { get; set; }
        public string Tipo { get; set; }
        public int DNICliente { get; set; }
        public string Estado { get; set; }


    }
}