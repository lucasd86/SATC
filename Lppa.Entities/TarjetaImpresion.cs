using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities
{
    public class TarjetaImpresion : TarjetaDeCredito
    {

        public DateTime FechaDesde { get; set; }
        public DateTime FechaVenc { get; set; }
        public int CodigoSeguridad { get; set; }
        private Random rnd = new Random();

        public int GetRandomInt()
        {
            var number = rnd.Next(0, 999);
            return number;
        }
        public TarjetaImpresion(TarjetaDeCredito _tarjeta)

        {
            
            FechaDesde = DateTime.Now;
            FechaDesde = DateTime.Now.AddYears(5);
            CodigoSeguridad = GetRandomInt();


        }



    }
}
