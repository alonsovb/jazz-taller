using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos
{
    public class Alerta
    {
        private int _placa;

        public int Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private string _recordatorio;

        public string Recordatorio
        {
            get { return _recordatorio; }
            set { _recordatorio = value; }
        }

        public Alerta() {
            Placa = -1;
            Fecha = DateTime.Now;
            Recordatorio = String.Empty;
        }
         public Alerta(int placa, DateTime fec, String rec)
        {
             this._placa = placa;
             this._fecha = fec;
             this._recordatorio=rec;
        }
    }
}
