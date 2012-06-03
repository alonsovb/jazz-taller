using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class Mecánico {
        private int _persona;

        public int Persona {
            get { return _persona; }
            set { _persona = value; }
        }
        private int _código;

        public int Código {
            get { return _código; }
            set { _código = value; }
        }
        private string _título;

        public string Título {
            get { return _título; }
            set { _título = value; }
        }
        private int _experiencia;

        public int Experiencia {
            get { return _experiencia; }
            set { _experiencia = value; }
        }

        public Mecánico() {
            Persona = -1;
            Código = -1;
            Título = String.Empty;
            Experiencia = -1;
        }
        
        public Mecánico(int p, int c, String t, int e)
        {
            Persona = p;
            Código = c;
            Título = t;
            Experiencia = e;
        }
        
     }
}
