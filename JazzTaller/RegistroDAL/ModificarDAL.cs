using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JazzTaller_Utilerías.Objetos;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Sql;
using JazzTaller_Utilerías;

namespace RegistroDAL
{
   public class ModificarDAL
    {
        public void ModificarReparacion(Reparaciones utilR)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[modificar_reparacion]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTid_cita", DbType.Int32, Utilerías.ObtenerValor(utilR.IdReparación));
                db.AddInParameter(dbCommand, "@DTfecha", DbType.DateTime, Utilerías.ObtenerValor(utilR.Fecha));
                db.AddInParameter(dbCommand, "@STRnotas", DbType.String, Utilerías.ObtenerValor(utilR.Notas));
                db.AddInParameter(dbCommand, "@STRdiagnostico", DbType.String, Utilerías.ObtenerValor(utilR.Diagnóstico));
                db.AddInParameter(dbCommand, "@STRevaluacion", DbType.String, Utilerías.ObtenerValor(utilR.Evaluación));
                db.AddInParameter(dbCommand, "@CHARcompletado", DbType.Boolean, Utilerías.ObtenerValor(utilR.Completada));
                db.AddInParameter(dbCommand, "@INTdiagnostica", DbType.Int32, Utilerías.ObtenerValor(utilR.Diagnostica));
                db.AddInParameter(dbCommand, "@INTevalua", DbType.Int32, Utilerías.ObtenerValor(utilR.Evalúa));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void ModificarLaborRequerida(LaboresRequeridas labor) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[modificar_labor_requerida]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTlabor_requerida", DbType.Int32, Utilerías.ObtenerValor(labor.IdLaborRequerida));
                db.AddInParameter(dbCommand, "@CHARaprobada", DbType.Boolean, Utilerías.ObtenerValor(labor.Aprobada));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
