using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class Personas {
        private int _idPersona;

        public int IdPersona {
            get { return _idPersona; }
            set { _idPersona = value; }
        }
        private int _identificación;

        public int Identificación {
            get { return _identificación; }
            set { _identificación = value; }
        }
        private string _nombre;

        public string Nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apellidos;

        public string Apellidos {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public Personas() {
            IdPersona = -1;
            Identificación = -1;
            Nombre = String.Empty;
            Apellidos = String.Empty;
        }
        
        public Personas(int ident, String nom, String apell)
        {

                this._identificación = ident;
                this._nombre = nom;
                this._apellidos = apell;      
        }

        public Personas(int ident)
        {

            this._identificación = ident;
        }
    }
}
