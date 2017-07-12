﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lppa.Entities
{
    public class ClienteTitular
    {

        private string _nombre;
        private string _appellido;
        private int _dni;
        private int _cuit;
        private DateTime _fechanacimiento;
        private string _domicilio;
        private EstadoCivil _estadocivil;
        private int? _ingresomensual;
        private Sexo _sexo;
        private SituacionLaboral _situacionlaboral;
        private int? _dniconyuge;

        [DataMember]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        [DataMember]
        public string Apellido
        {
            get { return _appellido; }
            set { _appellido = value; }
        }
        [DataMember]
        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }
        [DataMember]
        public int CUIT
        {
            get { return _cuit; }
            set { _cuit = value; }
        }
        [DataMember]
        public DateTime FechaNacimiento
        {
            get { return _fechanacimiento; }
            set { _fechanacimiento = value; }
        }

        [DataMember]
        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }
        [DataMember]
        public EstadoCivil EstadoCivil
        {
            get { return _estadocivil; }
            set { _estadocivil = value; }
        }
        [DataMember]
        public int? IngresosMensualesAprox
        {
            get { return _ingresomensual; }
            set { _ingresomensual = value; }
        }

        [DataMember]
        public Sexo Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        [DataMember]
        public SituacionLaboral SituacionLaboral
        {
            get { return _situacionlaboral; }
            set { _situacionlaboral = value; }
        }
        public int? DNIConyuge
        {
            get { return _dniconyuge; }
            set { _dniconyuge = value; }

        }
        
        
    }
}