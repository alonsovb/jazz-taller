using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class MecánicosParticipantes {
        private int _reparación;

        public int Reparación {
            get { return _reparación; }
            set { _reparación = value; }
        }
        private int _mecánico;

        public int Mecánico {
            get { return _mecánico; }
            set { _mecánico = value; }
        }
        private int _rol;

        public int Rol {
            get { return _rol; }
            set { _rol = value; }
        }
        private int _horas;

        public int Horas {
            get { return _horas; }
            set { _horas = value; }
        }

        public MecánicosParticipantes() {
            Reparación = -1;
            Mecánico = -1;
            Rol = -1;
            Horas = -1;
        }
    }
}
