using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class Repuestos {
        private int _idRepuesto;

        public int IdRepuesto {
            get { return _idRepuesto; }
            set { _idRepuesto = value; }
        }
        private int _reparación;

        public int Reparación {
            get { return _reparación; }
            set { _reparación = value; }
        }
        private string _descripción;

        public string Descripción {
            get { return _descripción; }
            set { _descripción = value; }
        }
        private int _precio;

        public int Precio {
            get { return _precio; }
            set { _precio = value; }
        }

        public Repuestos() {
            IdRepuesto = -1;
            Reparación = -1;
            Descripción = String.Empty;
            Precio = -1;
        }
    }
}
