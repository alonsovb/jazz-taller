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
    public class ConsultasDAL
    {

        public DataTable ConsultarAutos(Autos util)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_autos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTplaca", DbType.Int32, Utilerías.ObtenerValor(util.Placa));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar los autos de una persona
        public DataTable ConsultarAutPers(Personas DatosP)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_aut_pers]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(DatosP.Identificación));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        // Metodo de consultar personas
        public DataTable ConsultarPersonas(Personas util)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_personas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(util.Identificación));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        

        // Metodo de consultar telefonos de una persona
        public DataTable ConsultarTelefonos(Teléfonos util)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_telefonos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(util.IdTeléfono));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar Emails de una persona
        public DataTable ConsultarEmails(Emails util)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_correos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(util.IdEmail));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        // Metodo de consultar los autos que estan en reparacion
        public DataTable ConsultarListaReparacion()
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_lista_rep]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];
                
                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar mecanicos
        public DataTable ConsultarMecanicos()
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_mecanicos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar reparaciones por id de la cita
        public DataTable ConsultarPorDiagnosticar() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_por_diagnosticar]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar reparaciones que no se han evaluado
        public DataTable ConsultarPorEvaluar() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_por_evaluar]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar reparaciones que no se han evaluado
        public DataTable ConsultarPorCompletar() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_por_completar]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar el historial del taller
        public DataTable ConsultarHistorial() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_historial]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }


        // Consultar el costo de las reparaciones de un auto
        public DataTable ConsultarCostoReparacion(int ID_Cita) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_costo_reparacion]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_cita", DbType.Int32, ID_Cita);
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Consultar el costo de los repuestos que llevo un auto
        public DataTable ConsultarCostoRepuestos(int ID_Cita) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_costo_repuestos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_cita", DbType.Int32, ID_Cita);
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar los autos que estan en reparacion
        public DataTable ConsultarReparacion(Reparaciones utilR) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_reparaciones]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_cita", DbType.Int32, Utilerías.ObtenerValor(utilR.IdReparación));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar las labores de una reparación
        public DataTable ConsultarLaboresAsignadas(Reparaciones utilR) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_labores_asignadas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_cita", DbType.Int32, Utilerías.ObtenerValor(utilR.IdReparación));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar los mecánicos asignados a una reparación
        public DataTable ConsultarMecánicosAsignados(Reparaciones utilR) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_mecánicos_asignados]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_cita", DbType.Int32, Utilerías.ObtenerValor(utilR.IdReparación));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar los repuestos asignados a una reparación
        public DataTable ConsultarRepuestosAsignados(Reparaciones utilR) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_repuestos_asignados]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTid_cita", DbType.Int32, Utilerías.ObtenerValor(utilR.IdReparación));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar la lista de roles
        public DataTable ConsultarRoles() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_roles]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar la lista de labores
        public DataTable ConsultarLabores() {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_labores]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }



        // Metodo de consultar mecanicos especificos
        public DataTable ConsultarMecanico(Personas DatosP) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_mecanico]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTcedula", DbType.Int32, Utilerías.ObtenerValor(DatosP.Identificación));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        // Metodo de consultar mecanicos especificos
        public DataTable ConsultarAlerta()
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[consultar_alertas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                return (dtResultado);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
