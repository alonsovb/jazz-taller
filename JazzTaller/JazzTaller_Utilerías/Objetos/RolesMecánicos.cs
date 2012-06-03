using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
    public class RolesMecánicos {
        private int _idRolMecánico;

        public int IdRolMecánico {
            get { return _idRolMecánico; }
            set { _idRolMecánico = value; }
        }
        private string _nombre;

        public string Nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public RolesMecánicos() {
            IdRolMecánico = -1;
            Nombre = String.Empty;
        }
    }
}
