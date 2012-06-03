using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías.Objetos {
   public class Emails {
        private int _idEmail;

        public int IdEmail {
            get { return _idEmail; }
            set { _idEmail = value; }
        }
        private string _email;

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public Emails() {
            IdEmail = -1;
            Email = String.Empty;
        }
       public Emails(int idT, String tel)
        {
            IdEmail = idT;
            Email = tel;
        }

       public Emails(int idT)
        { IdEmail = idT; }
    }
}
