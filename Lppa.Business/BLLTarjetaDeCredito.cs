using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lppa.Entities;

namespace Lppa.Business
{
    public class BLLTarjetaDeCredito
    {
        public void CrearTarjetaDeCredito(TarjetaDeCredito _tarjeta, int _dni)
        {
            Data.DALTarjetaDeCredito _DALTarjeta = new Data.DALTarjetaDeCredito();
            Data.DALCliente _DALCliente = new Data.DALCliente();
            _tarjeta._cliente = Mapper.Map(_DALCliente.ListarClientePorDNI(_dni));
            Data.TarjetaDeCredito _DATATarjeta = Mapper.Map(_tarjeta);
            _DALTarjeta.AgregarTarjetaDeCredito(_DATATarjeta);
        }

        public TarjetaDeCredito[] ListarTarjetaDeCredito()

        {
            Data.DALTarjetaDeCredito _DALTarjeta = new Data.DALTarjetaDeCredito();
            Data.TarjetaDeCredito[] _listaTarjeta = _DALTarjeta.ListarTarjetasDeCredito();
            TarjetaDeCredito[] _listaTarjetasEntities = new TarjetaDeCredito[_listaTarjeta.Length];

            for (int i = 0; i < _listaTarjeta.Length; i++)
            {
                _listaTarjetasEntities[i] = Mapper.Map(_listaTarjeta[i]);
            }

            return _listaTarjetasEntities;


        }

    }
}
