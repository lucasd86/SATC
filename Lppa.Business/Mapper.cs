using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lppa.Data;
using Lppa.Entities;

namespace Lppa.Business
{
    public static class Mapper
    {
        public static Lppa.Entities.ClienteTitular Map(Lppa.Data.ClienteTitular _clienteDAL)
        {
            Lppa.Entities.ClienteTitular _clienteEntities = new Lppa.Entities.ClienteTitular();
            if (_clienteDAL == null) return _clienteEntities;
            _clienteEntities.Nombre = _clienteDAL.Nombre;
            _clienteEntities.Apellido = _clienteDAL.Apellido;
            _clienteEntities.DNI = _clienteDAL.DNI;
            _clienteEntities.CUIT = _clienteDAL.CUIT;
            _clienteEntities.FechaNacimiento = _clienteDAL.FechaNacimiento;
            _clienteEntities.Domicilio = _clienteDAL.Domicilio;
            _clienteEntities.EstadoCivil = (Lppa.Entities.EstadoCivil)_clienteDAL.EstadoCivil;
            _clienteEntities.IngresosMensualesAprox = _clienteDAL.IngresoMensual;
            _clienteEntities.Sexo = (Lppa.Entities.Sexo)_clienteDAL.Sexo;
            _clienteEntities.SituacionLaboral = (Lppa.Entities.SituacionLaboral)_clienteDAL.SituacionLaboral;
            _clienteEntities.DNIConyuge = _clienteDAL.DNIConyuge;

            return _clienteEntities;
        }
    }
}