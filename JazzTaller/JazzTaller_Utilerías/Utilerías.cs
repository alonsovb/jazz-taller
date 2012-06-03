using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JazzTaller_Utilerías {
    public class Utilerías {
        /// <summary>
        /// Recibe como parámetro un objeto (parámetro 
        /// de alguna función o procedimiento de BD).
        /// Si no contiene un valor significativo retorna
        /// NULL.
        /// </summary>
        /// <param name="objDato">Si es numético (-1) en 
        /// el caso de cadenas de caracteres ("")</param>
        /// <returns></returns>
        public static object ObtenerValor(object objDato) {
            if (objDato.GetType() == typeof(Int32)) {
                if ((int)objDato == -1)
                    return null;
            }

            if (objDato.GetType() == typeof(String)) {
                if ((string)objDato == "")
                    return null;
            }

            if (objDato.GetType() == typeof(decimal)) {
                if ((decimal)objDato == -1)
                    return null;

            }

            if (objDato.GetType() == typeof(Int64)) {
                if ((System.Int64)objDato == -1)
                    return null;
            }

            return objDato;
        }
    }
}
