using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lppa.Data
{
    public class DALCliente
    {
        private SATCConexion db = new SATCConexion();

        public void CrearClienteTitular(ClienteTitular _cliente)

        {
            try
            {
                db.ClienteTitular.Add(_cliente);
                db.SaveChanges();

            }
            catch (Exception exception)
            {
                throw new Exception("ERROR al crear Cliente DAL", exception);

            }
        }

        public ClienteTitular ListarClientePorDNI(int _dni)

        {
            try
            {

                ClienteTitular _cliente = new ClienteTitular();
                _cliente = db.ClienteTitular.Where(c => c.DNI == _dni).FirstOrDefault();
                if(_cliente != null)
                {
                    return _cliente;
                }
                else
                {
                    throw new Exception("No se encuentra el Titular / DAL");
                }

            }
            catch (Exception exception)
            {
                throw new Exception("ERROR al listar cliente DAL", exception);

            }




        }

        public List<ClienteTitular> listarTodos()
        {
            List<ClienteTitular> _lista = new List<ClienteTitular>();
            _lista = db.ClienteTitular.ToList();
            return _lista;


        }

        public void ActualizarDNIAdicional(int? _dniTitular, int _dni)
        {
            try
            {
                ClienteTitular _Cliente = new ClienteTitular();

                _Cliente = db.ClienteTitular.Where(c => c.DNI == _dniTitular).FirstOrDefault();

                if (_Cliente != null)
                {
                    _Cliente.DNIAdicional = _dni;
                    db.Entry(_Cliente).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("No se encuentra el cliente / DAL");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR al Agregar Adicional DAL", ex);
            }
        }
    }
}



      
    
    