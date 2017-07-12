using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Data
{
    public class DALCliente
    {
        private SATCconexion db = new SATCconexion();

        public void Create(ClienteTitular _cliente)

        {
            try
            {
                db.ClienteTitular.Add(_cliente);
                db.SaveChanges();

            }
            catch (Exception exception)
            {
                throw exception;

            }
        }

        public ClienteTitular ListarClientePorDNI(int _dni)

        {
            try
            {

                ClienteTitular _cliente = new ClienteTitular();
                _cliente = db.ClienteTitular.Where(c => c.DNI == _dni).FirstOrDefault();
                return _cliente;

            }
            catch (Exception exception)
            {
                throw exception;

            }




        }

        public List<ClienteTitular> listar()
        {
            List<ClienteTitular> _lista = new List<ClienteTitular>();
            _lista = db.ClienteTitular.ToList();
            return _lista;


        }
    }
}



      
    
    