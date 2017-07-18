using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using System.Drawing;

namespace Lppa.Data
{
    public class DALCliente
    {
        private SATCConexion   db = new SATCConexion();

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

        public bool Existe(int _dni)

        {
            try
            {

                ClienteTitular _cliente = new ClienteTitular();
                _cliente = db.ClienteTitular.Where(c => c.DNI == _dni).FirstOrDefault();
                if (_cliente != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception exception)
            {
                throw new Exception("ERROR EXISTE cliente DAL", exception);

            }

        }
        public void ActualizarFoto(Lppa.Entities.ClienteTitular _ClienteEntities)
        {
            ClienteTitular Cliente = new ClienteTitular();
            Cliente = db.ClienteTitular.Where(c => c.DNI == _ClienteEntities.DNI).FirstOrDefault();
          

            if (Cliente != null)
            {

                Cliente.FOTO = _ClienteEntities.Foto;
                db.Entry(Cliente).State = EntityState.Modified;
                db.SaveChanges();


            }
            else
            {
                throw new Exception("No se puede actualizar la foto / DAL");
            }



        }
        public void ObtenerFoto(Lppa.Entities.ClienteTitular _ClienteEntities)
        {

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        //Byte array to photo
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}



      
    
    