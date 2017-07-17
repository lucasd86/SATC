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
        public static Entities.ClienteTitular Map(Data.ClienteTitular _clienteDAL)
        {
            Entities.ClienteTitular _clienteEntities = new Entities.ClienteTitular();
            if (_clienteDAL == null) return _clienteEntities;
            _clienteEntities.Nombre = _clienteDAL.Nombre;
            _clienteEntities.Apellido = _clienteDAL.Apellido;
            _clienteEntities.DNI = _clienteDAL.DNI;
            _clienteEntities.CUIT = _clienteDAL.CUIT;
            _clienteEntities.FechaNacimiento = _clienteDAL.FechaNacimiento;
            _clienteEntities.Domicilio = _clienteDAL.Domicilio;
            _clienteEntities.EstadoCivil = (EstadoCivil)_clienteDAL.EstadoCivil;
            _clienteEntities.IngresosMensualesAprox = _clienteDAL.IngresoMensual;
            _clienteEntities.Sexo = (Sexo)_clienteDAL.Sexo;
            _clienteEntities.SituacionLaboral = (SituacionLaboral)_clienteDAL.SituacionLaboral;
            _clienteEntities.DNIConyuge = _clienteDAL.DNIConyuge;
            _clienteEntities.NombreConyuge = _clienteDAL.NombreConyuge;
            _clienteEntities.ApellidoConyuge = _clienteDAL.ApellidoConyuge;
            _clienteEntities.DNIAdicional = _clienteDAL.DNIAdicional;



            return _clienteEntities;
        }
        public static Data.ClienteTitular Map(Entities.ClienteTitular _clienteEntities) {
            Data.ClienteTitular _clienteDAL = new Data.ClienteTitular();
            _clienteDAL.Nombre = _clienteEntities.Nombre;
            _clienteDAL.Apellido = _clienteEntities.Apellido;
            _clienteDAL.DNI = _clienteEntities.DNI;
            _clienteDAL.CUIT = _clienteEntities.CUIT;
            _clienteDAL.FechaNacimiento = _clienteEntities.FechaNacimiento;
            _clienteDAL.Domicilio = _clienteEntities.Domicilio;
            _clienteDAL.EstadoCivil = (int)_clienteEntities.EstadoCivil;
            _clienteDAL.IngresoMensual = _clienteEntities.IngresosMensualesAprox;
            _clienteDAL.Sexo = (int)_clienteEntities.Sexo;
            _clienteDAL.SituacionLaboral = (int)_clienteEntities.SituacionLaboral;
            _clienteDAL.DNIConyuge = _clienteEntities.DNIConyuge;
            _clienteDAL.NombreConyuge = _clienteEntities.NombreConyuge;
            _clienteDAL.ApellidoConyuge = _clienteEntities.ApellidoConyuge;
            _clienteDAL.DNIAdicional = _clienteEntities.DNIAdicional;
          
            return _clienteDAL;

        }
        public static Data.TarjetaDeCredito Map(Entities.TarjetaDeCredito _tarjetaEntities)
        {
            Data.TarjetaDeCredito _tarjetaDAL = new Data.TarjetaDeCredito();
            if (_tarjetaEntities == null) return _tarjetaDAL;

            _tarjetaDAL.ClienteTitular = Map(_tarjetaEntities._cliente);
            _tarjetaDAL.DNICliente = _tarjetaEntities._cliente.DNI;
            _tarjetaDAL.Estado = (int)_tarjetaEntities._estadoTarjeta;
            _tarjetaDAL.Marca = (int)_tarjetaEntities.Marca;
            _tarjetaDAL.NumeroTarjeta = (int)new Random().Next();
            _tarjetaDAL.SaldoMaximo = _tarjetaEntities.CreditoMaximo;
            _tarjetaDAL.Tipo = (int)_tarjetaEntities.Tipo;
                      
            return _tarjetaDAL;

        }
        public static Entities.TarjetaDeCredito Map(Data.TarjetaDeCredito _tarjetaDAL)
        {
            Entities.TarjetaDeCredito _tarjetaEntities = new Entities.TarjetaDeCredito();
            if (_tarjetaDAL == null) return _tarjetaEntities;
            _tarjetaEntities._cliente = Map(_tarjetaDAL.ClienteTitular);
            _tarjetaEntities.Marca = (Entities.MarcasTarjetasCredito)_tarjetaDAL.Marca;
            _tarjetaEntities.Numero = _tarjetaDAL.NumeroTarjeta;
            _tarjetaEntities.CreditoMaximo= _tarjetaDAL.SaldoMaximo;
            _tarjetaEntities.Tipo = (Entities.TipoDeTarjetaDeCredito) _tarjetaDAL.Tipo;
            _tarjetaEntities._estadoTarjeta = (Entities.EstadoTarjeta) _tarjetaDAL.Estado;


            return _tarjetaEntities;



        }
               
    }
}