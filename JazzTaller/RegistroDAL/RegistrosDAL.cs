using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JazzTaller_Utilerías;
using JazzTaller_Utilerías.Objetos;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Sql;

namespace RegistroDAL {
    public class RegistrosDAL {
        ConsultasDAL Consultas = new ConsultasDAL();
        public String RegistrarAutPerRep(Autos DatosA, Personas DatosP, Reparaciones DatosR) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_personas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            using (DbConnection conn = db.CreateConnection()) // conexion para la transaccion
            {
                conn.Open(); //abrimos la conexion
                DbTransaction tranRegistro = conn.BeginTransaction(); //iniciamos la transaccion 

                try {
                    db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(DatosP.Identificación));
                    db.AddInParameter(dbCommand, "@STRnombre", DbType.String, Utilerías.ObtenerValor(DatosP.Nombre));
                    db.AddInParameter(dbCommand, "@STRapellido", DbType.String, Utilerías.ObtenerValor(DatosP.Apellidos));
                    db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                    db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                    db.AddOutParameter(dbCommand, "@INTid", DbType.Int32, 4);

                    db.ExecuteNonQuery(dbCommand, tranRegistro);


                    if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                        throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                    // Se registra la informacion del auto, un vez ingresados los datos personales
                    DatosR.Encargado = int.Parse(db.GetParameterValue(dbCommand, "@INTid").ToString());
                    DatosR.Auto = RegistrarAutos(DatosA, tranRegistro, db);
                    RegistrarReparaciones(DatosR, tranRegistro, db);
                    tranRegistro.Commit();

                } catch (Exception ex) {
                    tranRegistro.Rollback();
                    throw new Exception(ex.Message);
                } finally {
                    conn.Close(); // cerrar la conexion
                }
            }
            return "Se registraron los datos correctamente";
        }

        // Registra autos a un cliente y las reparaciones
        public String RegistrarAutRep(Autos DatosA, Reparaciones DatosR) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_personas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            using (DbConnection conn = db.CreateConnection()) // conexion para la transaccion
            {
                conn.Open(); //abrimos la conexion
                DbTransaction tranRegistro = conn.BeginTransaction(); //iniciamos la transaccion 

                try {
                    // Se registra la informacion del auto, un vez ingresados los datos personales
                    DatosR.Auto = RegistrarAutos(DatosA, tranRegistro, db);
                    RegistrarReparaciones(DatosR, tranRegistro, db);
                    tranRegistro.Commit();

                } catch (Exception ex) {
                    tranRegistro.Rollback();
                    throw new Exception(ex.Message);
                } finally {
                    conn.Close(); // cerrar la conexion
                }
            }
            return "Se registraron los datos del auto correctamente";
        }

        //Funcion para registrar autos
        public int RegistrarAutos(Autos DatosA, DbTransaction tran, Database db) {
            string sqlCommand = "dbo.insertar_autos";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            try {
                db.AddInParameter(dbCommand, "@INTplaca", DbType.Int32, Utilerías.ObtenerValor(DatosA.Placa));
                db.AddInParameter(dbCommand, "@STRmarca", DbType.String, Utilerías.ObtenerValor(DatosA.Marca));
                db.AddInParameter(dbCommand, "@STRmodelo", DbType.String, Utilerías.ObtenerValor(DatosA.Modelo));
                db.AddInParameter(dbCommand, "@INTanno", DbType.Int32, Utilerías.ObtenerValor(DatosA.Año));
                db.AddInParameter(dbCommand, "@INTnumero_vin", DbType.Int32, Utilerías.ObtenerValor(DatosA.Vin));
                db.AddInParameter(dbCommand, "@STRcolor", DbType.String, Utilerías.ObtenerValor(DatosA.Color));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                db.AddOutParameter(dbCommand, "@INTid_Auto", DbType.Int32, 4);


                db.ExecuteNonQuery(dbCommand, tran);


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                //retorna el id del auto que acaba de registrar
                return int.Parse(db.GetParameterValue(dbCommand, "@INTid_Auto").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //Funcion para registrar reparaciones
        public void RegistrarReparaciones(Reparaciones DatosR, DbTransaction tran, Database db) {
            string sqlCommand = "dbo.insertar_reparaciones";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            try {
                db.AddInParameter(dbCommand, "@INTauto", DbType.Int32, Utilerías.ObtenerValor(DatosR.Auto));
                db.AddInParameter(dbCommand, "@DTfecha", DbType.DateTime, Utilerías.ObtenerValor(DatosR.Fecha));
                db.AddInParameter(dbCommand, "@STRnotas", DbType.String, Utilerías.ObtenerValor(DatosR.Notas));
                db.AddInParameter(dbCommand, "@INTdiagnostica", DbType.Int32, Utilerías.ObtenerValor(DatosR.Diagnostica));
                db.AddInParameter(dbCommand, "@STRdiagnostico", DbType.String, Utilerías.ObtenerValor(DatosR.Diagnóstico));
                db.AddInParameter(dbCommand, "@INTevalua", DbType.Int32, Utilerías.ObtenerValor(DatosR.Evalúa));
                db.AddInParameter(dbCommand, "@STRevaluacion", DbType.String, Utilerías.ObtenerValor(DatosR.Evaluación));
                db.AddInParameter(dbCommand, "@CHARcompletado", DbType.Boolean, Utilerías.ObtenerValor(DatosR.Completada));
                db.AddInParameter(dbCommand, "@INTencargado", DbType.Int32, Utilerías.ObtenerValor(DatosR.Encargado));
                db.AddInParameter(dbCommand, "@CHARes_duenno", DbType.Boolean, Utilerías.ObtenerValor(DatosR.EsDueño));
                db.AddInParameter(dbCommand, "@CHARconfirmar_todo", DbType.Boolean, Utilerías.ObtenerValor(DatosR.Confirmar));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);


                db.ExecuteNonQuery(dbCommand, tran);


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //Funcion para registrar reparaciones sin recibir transacciones
        public String RegistrarReparaciones(Reparaciones DatosR) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_reparaciones]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            try {
                db.AddInParameter(dbCommand, "@INTauto", DbType.Int32, Utilerías.ObtenerValor(DatosR.Auto));
                db.AddInParameter(dbCommand, "@DTfecha", DbType.DateTime, Utilerías.ObtenerValor(DatosR.Fecha));
                db.AddInParameter(dbCommand, "@STRnotas", DbType.String, Utilerías.ObtenerValor(DatosR.Notas));
                db.AddInParameter(dbCommand, "@INTdiagnostica", DbType.Int32, Utilerías.ObtenerValor(DatosR.Diagnostica));
                db.AddInParameter(dbCommand, "@STRdiagnostico", DbType.String, Utilerías.ObtenerValor(DatosR.Diagnóstico));
                db.AddInParameter(dbCommand, "@INTevalua", DbType.Int32, Utilerías.ObtenerValor(DatosR.Evalúa));
                db.AddInParameter(dbCommand, "@STRevaluacion", DbType.String, Utilerías.ObtenerValor(DatosR.Evaluación));
                db.AddInParameter(dbCommand, "@CHARcompletado", DbType.Boolean, Utilerías.ObtenerValor(DatosR.Completada));
                db.AddInParameter(dbCommand, "@INTencargado", DbType.Int32, Utilerías.ObtenerValor(DatosR.Encargado));
                db.AddInParameter(dbCommand, "@CHARes_duenno", DbType.Boolean, Utilerías.ObtenerValor(DatosR.EsDueño));
                db.AddInParameter(dbCommand, "@CHARconfirmar_todo", DbType.Boolean, Utilerías.ObtenerValor(DatosR.Confirmar));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);


                db.ExecuteNonQuery(dbCommand);


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            return "Se registró la reparación correctamente";
        }

        //Funcion para registrar los telefonos
        public DataTable RegistrarTelefono(Teléfonos DatosT) {

            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.insertar_telefonos";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(DatosT.IdTeléfono));
                db.AddInParameter(dbCommand, "@STRtelefono", DbType.String, Utilerías.ObtenerValor(DatosT.Teléfono));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());


                return dtResultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //Funcion para registrar los emails
        public DataTable RegistrarEmail(Emails DatosE) {

            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.insertar_correos";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(DatosE.IdEmail));
                db.AddInParameter(dbCommand, "@STRcorreo", DbType.String, Utilerías.ObtenerValor(DatosE.Email));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                DataTable dtResultado = db.ExecuteDataSet(dbCommand).Tables[0];


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());


                return dtResultado;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        //Funcion para registrar Personas-Mecanicos
        public String RegistrarPersMec(Personas DatosP, Mecánico DatosM) {
            DataTable Existe = Consultas.ConsultarPersonas(DatosP);
            int persona = 0;

            if (Existe.Rows.Count != 0)
                persona = Convert.ToInt32(Existe.Rows[0]["id_persona"].ToString());


            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_personas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            using (DbConnection conn = db.CreateConnection()) // conexion para la transaccion
            {
                conn.Open(); //abrimos la conexion
                DbTransaction tranRegistro = conn.BeginTransaction(); //iniciamos la transaccion 

                if (persona < 1) {
                    try {
                        db.AddInParameter(dbCommand, "@INTidentificacion", DbType.Int32, Utilerías.ObtenerValor(DatosP.Identificación));
                        db.AddInParameter(dbCommand, "@STRnombre", DbType.String, Utilerías.ObtenerValor(DatosP.Nombre));
                        db.AddInParameter(dbCommand, "@STRapellido", DbType.String, Utilerías.ObtenerValor(DatosP.Apellidos));
                        db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                        db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);
                        db.AddOutParameter(dbCommand, "@INTid", DbType.Int32, 4);

                        db.ExecuteNonQuery(dbCommand, tranRegistro);

                        if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                            throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

                        // Se registra la informacion del auto, un vez ingresados los datos personales
                        DatosM.Persona = int.Parse(db.GetParameterValue(dbCommand, "@INTid").ToString());
                        RegistrarMecanicos(DatosM, tranRegistro, db);
                        tranRegistro.Commit();

                    } catch (Exception ex) {
                        tranRegistro.Rollback();
                        throw new Exception(ex.Message);
                    }
                } else {
                    DatosM.Persona = persona;
                    RegistrarMecanicos(DatosM, tranRegistro, db);
                    tranRegistro.Commit();
                }
                try { } finally {
                    conn.Close(); // cerrar la conexion
                }

            }
            return "Se registraron los datos del auto correctamente";
        }

        //Funcion para registrar Mecanicos
        public void RegistrarMecanicos(Mecánico DatosM, DbTransaction tran, Database db) {
            string sqlCommand = "dbo.insertar_mecanicos";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            try {
                db.AddInParameter(dbCommand, "@INTpersona", DbType.Int32, Utilerías.ObtenerValor(DatosM.Persona));
                db.AddInParameter(dbCommand, "@STRtitulo", DbType.String, Utilerías.ObtenerValor(DatosM.Título));
                db.AddInParameter(dbCommand, "@INTcodigo", DbType.Int32, Utilerías.ObtenerValor(DatosM.Código));
                db.AddInParameter(dbCommand, "@INTexperiencia", DbType.Int32, Utilerías.ObtenerValor(DatosM.Experiencia));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);


                db.ExecuteNonQuery(dbCommand, tran);


                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // Funcion para registrar un repuesto en una reparacion
        public void RegistrarRepuestoAsignado(Repuestos repuesto) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_repuestos]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTreparacion", DbType.Int32, Utilerías.ObtenerValor(repuesto.Reparación));
                db.AddInParameter(dbCommand, "@STRdescripcion", DbType.String, Utilerías.ObtenerValor(repuesto.Descripción));
                db.AddInParameter(dbCommand, "@INTprecio", DbType.Int32, Utilerías.ObtenerValor(repuesto.Precio));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                db.ExecuteNonQuery(dbCommand);

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // Funcion para registrar un repuesto en una reparacion
        public void RegistrarMecánicoParticipante(MecánicosParticipantes mecánico) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_mecanicos_participantes]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTreparacion", DbType.Int32, Utilerías.ObtenerValor(mecánico.Reparación));
                db.AddInParameter(dbCommand, "@INTmecanico", DbType.Int32, Utilerías.ObtenerValor(mecánico.Mecánico));
                db.AddInParameter(dbCommand, "@INTrol", DbType.Int32, Utilerías.ObtenerValor(mecánico.Rol));
                db.AddInParameter(dbCommand, "@INThoras_invertida", DbType.Int32, Utilerías.ObtenerValor(mecánico.Horas));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                db.ExecuteNonQuery(dbCommand);

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // Funcion para registrar un repuesto en una reparacion
        public void RegistrarLaborRequerida(LaboresRequeridas labor) {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_labores_requeridas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try {
                db.AddInParameter(dbCommand, "@INTreparacion", DbType.Int32, Utilerías.ObtenerValor(labor.Reparación));
                db.AddInParameter(dbCommand, "@INTlabor", DbType.Int32, Utilerías.ObtenerValor(labor.Labor));
                db.AddInParameter(dbCommand, "@INTmecanico", DbType.Int32, Utilerías.ObtenerValor(labor.Mecánico));
                db.AddInParameter(dbCommand, "@CHARaprobada", DbType.Boolean, Utilerías.ObtenerValor(labor.Aprobada));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                db.ExecuteNonQuery(dbCommand);

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // Funcion para registrar un repuesto en una reparacion
        public void RegistrarAlerta(Alerta DatosAlert)
        {
            Database db = DatabaseFactory.CreateDatabase("Desarrollo");
            string sqlCommand = "dbo.[insertar_alertas]";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            try
            {
                db.AddInParameter(dbCommand, "@INTplaca", DbType.Int32, Utilerías.ObtenerValor(DatosAlert.Placa));
                db.AddInParameter(dbCommand, "@DTfecha", DbType.DateTime, Utilerías.ObtenerValor(DatosAlert.Fecha));
                db.AddInParameter(dbCommand, "@STRrecordatorio", DbType.String, Utilerías.ObtenerValor(DatosAlert.Recordatorio));
                db.AddOutParameter(dbCommand, "@nStatus", DbType.Int16, 2);
                db.AddOutParameter(dbCommand, "@strMessage", DbType.String, 250);

                db.ExecuteNonQuery(dbCommand);

                if (int.Parse(db.GetParameterValue(dbCommand, "@nStatus").ToString()) > 0)
                    throw new Exception(db.GetParameterValue(dbCommand, "@strMessage").ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
