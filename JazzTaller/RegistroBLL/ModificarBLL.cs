using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroDAL;
using System.Data;
using JazzTaller_Utilerías.Objetos;

namespace RegistroBLL
{
   public class ModificarBLL
    {
        ModificarDAL Modificar = new ModificarDAL();

        public void ModificarReparacion(Reparaciones DatosR)
        {
            try { this.Modificar.ModificarReparacion(DatosR); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void ModificarLaborRequerida(LaboresRequeridas labor) {
            try { this.Modificar.ModificarLaborRequerida(labor); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
