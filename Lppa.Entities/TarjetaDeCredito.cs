using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities
{
    class TarjetaDeCredito
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
            get;
            set;
        }
        [DataMember]
        public int CreditoMaximo
        {
            get;
            set;
        }

        [DataMember]
        public MarcasTarjetasCredito Marca
        {
            get;
            set;
        }
       
        [DataMember]
        public TipoDeTarjetaDeCredito Tipo
        {
            get;
            set;
        }
    }
}
