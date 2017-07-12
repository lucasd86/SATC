using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lppa.Data;
using Lppa.Entities;

namespace Lppa.Business
{
    class BLLClienteTitular
    {
         DALCliente DAL = new DALCliente();

        public void Create(Lppa.Entities.ClienteTitular Cliente) {
            try { 
            DAL.Create();
            }
            catch
            {



            }
            }

    }
}
