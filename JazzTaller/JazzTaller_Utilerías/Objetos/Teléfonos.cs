using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class Teléfonos {
        private int _idTeléfono;

        public int IdTeléfono {
            get { return _idTeléfono; }
            set { _idTeléfono = value; }
        }
        private string _teléfono;

        public string Teléfono {
            get { return _teléfono; }
            set { _teléfono = value; }
        }

        public Teléfonos() {
            IdTeléfono = -1;
            Teléfono = String.Empty;
        }
        
        public Teléfonos(int idT, String tel)
        {
            IdTeléfono = idT;
            Teléfono = tel;
        }

        public Teléfonos(int idT)
        { IdTeléfono = idT; }
    }
}
