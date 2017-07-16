using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities
{
    public class TarjetaDeCredito
    {
        private int _numero;
        private int _CreditoMaximo;
        private MarcasTarjetasCredito _marca;
        private TipoDeTarjetaDeCredito _tipo;

        public Lppa.Entities.TarjetaDeCredito _extension;
        public Lppa.Entities.ClienteTitular _cliente;
        public Lppa.Entities.EstadoTarjeta _estadoTarjeta;


        [DataMember]
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        [DataMember]
        public int CreditoMaximo
        {
            get { return _CreditoMaximo; }
            set { _CreditoMaximo = value; }
        }

        [DataMember]
        public MarcasTarjetasCredito Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
       
        [DataMember]
        public TipoDeTarjetaDeCredito Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}
