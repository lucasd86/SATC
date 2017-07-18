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

        public void ImprimirTarjeta(TarjetaDeCredito _tarjetaEntities) { 


            TarjetaImpresion _tarjetaIMP = new TarjetaImpresion(_tarjetaEntities);
            TarjetaPDF _tarjetaPDF = new TarjetaPDF();
            if (_tarjetaIMP.Marca == MarcasTarjetasCredito.Visa)
            {

                _tarjetaPDF.TarjetaVisa(_tarjetaIMP);
            }
            else if (_tarjetaIMP.Marca == MarcasTarjetasCredito.MasterCard)
            {

                _tarjetaPDF.TarjetaMaster(_tarjetaIMP);

            }
            else if (_tarjetaIMP.Marca == MarcasTarjetasCredito.AmericanExpress)
            {
                _tarjetaPDF.TarjetaAmerican(_tarjetaIMP);
            }
            else
                throw new Exception("ERROR al crear Tarjeta PDF");
            

        }

    }
}
