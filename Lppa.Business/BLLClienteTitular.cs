using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lppa.Data;
using Lppa.Entities;

namespace Lppa.Business
{
    public class BLLClienteTitular
    {
         DALCliente DAL = new DALCliente();

        public void CrearClienteTitular(Lppa.Entities.ClienteTitular _clienteEntities) {

            DALCliente _DALCliente = new DALCliente();

            _DALCliente.CrearClienteTitular(Mapper.Map(_clienteEntities));


            }
        public void CrearAdicional(Entities.ClienteTitular _cliente, int? dniTitular)
        {
            DALCliente _DALCliente = new DALCliente();
            

            _DALCliente.CrearClienteTitular(Mapper.Map(_cliente));

            _DALCliente.ActualizarDNIAdicional(dniTitular, _cliente.DNI);
        }

        public Entities.ClienteTitular  ListarClientePorDNI(int _dni)
        
        {
            DALCliente _DALCliente = new DALCliente();

            return Mapper.Map(_DALCliente.ListarClientePorDNI(_dni));
            
        }

        public bool AptoNoAPto(int _dni)
        {
            return true;
        }


   }
}
