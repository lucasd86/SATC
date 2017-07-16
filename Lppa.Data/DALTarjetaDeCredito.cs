using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Data
{
    public class DALTarjetaDeCredito
    {
        private SATCConexion _conexionDB = new SATCConexion();

        public void AgregarTarjetaDeCredito(Data.TarjetaDeCredito _tarjeta) {
            try
            {

                _conexionDB.TarjetaDeCredito.Add(_tarjeta);
                _conexionDB.Entry(_tarjeta.ClienteTitular).State = System.Data.Entity.EntityState.Modified;
                _conexionDB.SaveChanges();


            }

            finally { }

         }
        public TarjetaDeCredito[] ListarTarjetasDeCredito()

        {
            try
            {
                return _conexionDB.TarjetaDeCredito.ToArray();


            }
            finally { }

        }


    }
}
