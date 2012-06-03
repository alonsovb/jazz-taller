using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class Autos {
        private int _idAuto;

        public int IdAuto {
            get { return _idAuto; }
            set { _idAuto = value; }
        }
        private int _placa;

        public int Placa {
            get { return _placa; }
            set { _placa = value; }
        }
        private string _marca;

        public string Marca {
            get { return _marca; }
            set { _marca = value; }
        }
        private string _modelo;

        public string Modelo {
            get { return _modelo; }
            set { _modelo = value; }
        }

        
        private int _año;

        public int Año {
            get { return _año; }
            set { _año = value; }
        }
        private int _vin;

        public int Vin {
            get { return _vin; }
            set { _vin = value; }
        }
        private string _color;

        public string Color {
            get { return _color; }
            set { _color = value; }
        }

        public Autos() {
            IdAuto = -1;
            Placa = -1;
            Marca = String.Empty;
            Modelo = String.Empty;
            Año = -1;
            Vin = -1;
            Color = String.Empty;
        }
         public Autos(int placa, String mar, String mod,int anno, int numero_vin,String color)
        {

                this._placa = placa;
                this._marca = mar;
                this._modelo = mod;
                this._año = anno;
                this._vin = numero_vin;
                this._color = color;        
        }

         public Autos(int pla)
        {

            this._placa = pla;
        }
    }
}
