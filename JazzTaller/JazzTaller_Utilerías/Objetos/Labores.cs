using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class Labores {
        private int _idLabor;

        public int IdLabor {
            get { return _idLabor; }
            set { _idLabor = value; }
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

        public Labores() {
            IdLabor = -1;
            Descripción = String.Empty;
            Precio = -1;
        }
    }
}
