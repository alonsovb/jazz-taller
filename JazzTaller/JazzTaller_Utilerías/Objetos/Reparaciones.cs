using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class Reparaciones {
        private int _idReparación;

        public int IdReparación {
            get { return _idReparación; }
            set { _idReparación = value; }
        }
        private int _auto;

        public int Auto {
            get { return _auto; }
            set { _auto = value; }
        }
        private int _encargado;

        public int Encargado {
            get { return _encargado; }
            set { _encargado = value; }
        }
        private bool _esDueño;

        public bool EsDueño {
            get { return _esDueño; }
            set { _esDueño = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private string _notas;

        public string Notas {
            get { return _notas; }
            set { _notas = value; }
        }
        private int _diagnostica;

        public int Diagnostica {
            get { return _diagnostica; }
            set { _diagnostica = value; }
        }
        private string _diagnóstico;

        public string Diagnóstico {
            get { return _diagnóstico; }
            set { _diagnóstico = value; }
        }
        private int _evalúa;

        public int Evalúa {
            get { return _evalúa; }
            set { _evalúa = value; }
        }
        private string _evaluación;

        public string Evaluación {
            get { return _evaluación; }
            set { _evaluación = value; }
        }
        private bool _completada;

        public bool Completada {
            get { return _completada; }
            set { _completada = value; }
        }

        private bool _confirmar_todo;

        public bool Confirmar
        {
            get { return _confirmar_todo; }
            set { _confirmar_todo = value; }
        }

        public Reparaciones() {
            Auto = -1;
            Encargado = -1;
            EsDueño = false;
            Fecha = DateTime.Now;
            Notas = String.Empty;
            Diagnostica = -1;
            Diagnóstico = String.Empty;
            Evalúa = -1;
            Evaluación = String.Empty;
            Completada = false;
            Confirmar = false;
        }

        public Reparaciones(int aut, int enc, bool esd, DateTime fec,
                            String not, int diag, String diagnost, int evalua,
                            String eval, bool comp, bool confirm)
        {
            Auto = aut;
            Encargado = enc;
            EsDueño = esd;
            Fecha = DateTime.Now;
            Notas = not;
            Diagnostica = diag;
            Diagnóstico = diagnost;
            Evalúa = evalua;
            Evaluación = eval;
            Completada = comp;
            Confirmar = confirm;
        }

        public Reparaciones(int id_repa)
        {
            IdReparación = id_repa;
        }
    }
}
