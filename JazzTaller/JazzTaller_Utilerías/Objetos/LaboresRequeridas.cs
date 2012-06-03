using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class LaboresRequeridas {
        private int _idLaborRequerida;

        public int IdLaborRequerida {
            get { return _idLaborRequerida; }
            set { _idLaborRequerida = value; }
        }
        private int _reparación;

        public int Reparación {
            get { return _reparación; }
            set { _reparación = value; }
        }
        private int _labor;

        public int Labor {
            get { return _labor; }
            set { _labor = value; }
        }
        private int _mecánico;

        public int Mecánico {
            get { return _mecánico; }
            set { _mecánico = value; }
        }
        private bool _aprobada;

        public bool Aprobada {
            get { return _aprobada; }
            set { _aprobada = value; }
        }

        public LaboresRequeridas() {
            IdLaborRequerida = -1;
            Reparación = -1;
            Labor = -1;
            Mecánico = -1;
            Aprobada = false;
        }
    }
}
