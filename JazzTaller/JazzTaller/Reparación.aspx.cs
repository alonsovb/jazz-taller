using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JazzTaller_Utilerías.Objetos;
using RegistroBLL;
using System.Data;

namespace JazzTaller {
    public partial class WebForm3 : System.Web.UI.Page {

        RegistroConsultasBLL consultaBll = new RegistroConsultasBLL();
        ModificarBLL modBll = new ModificarBLL();
        Reparaciones actual;
        private DataTable Labores, Mecánicos, Repuestos, Roles, ListaLabores;
        private int IDReparación;
        bool reparacionVálida = false;

        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["id"] != null) {
                int id = int.Parse(Request.QueryString["id"]);
                IDReparación = id;
                if (!Page.IsPostBack)
                {
                    try
                    {
                        LoadInfo(IDReparación);
                    }
                    catch { }
                }
                else 
                {
                    reparacionVálida = true;
                }
            }
        }

        private void LoadInfo(int id) {
            actual = new Reparaciones(id);

            DataTable dt = consultaBll.ConsultarReparacion(actual);
            Labores = consultaBll.ConsultarLaboresAsignadas(actual);
            Mecánicos = consultaBll.ConsultarMecánicosAsignados(actual);
            Repuestos = consultaBll.ConsultarRepuestosAsignados(actual);
            Roles = consultaBll.ConsultarRoles();
            ListaLabores = consultaBll.ConsultarLabores();

            if (dt.Rows.Count > 0) {

                reparacionVálida = true;

                TBClienteID.Text = dt.Rows[0]["encargado"].ToString();
                TBPlaca.Text = dt.Rows[0]["placa"].ToString();
                LFecha.Text = dt.Rows[0]["fecha"].ToString();
                TBNotas.Text = dt.Rows[0]["notas"].ToString();
                CBConfirmarAutomático.Checked = int.Parse(dt.Rows[0]["confirmar_todo"].ToString()) > 0;

                TBDiagnóstico.Text = dt.Rows[0]["diagnostico"].ToString();
                TBDiagnostica.Text = dt.Rows[0]["id_diagnostica"].ToString();
                HLDiagnostica.Text = dt.Rows[0]["diagnostica"].ToString();
                TBEvaluación.Text = dt.Rows[0]["evaluacion"].ToString();
                TBEvalúa.Text = dt.Rows[0]["id_evalua"].ToString();
                HLEvalúa.Text = dt.Rows[0]["evalua"].ToString();

                foreach (DataRow row in Labores.Rows) {
                    if (int.Parse(row["aprobada"].ToString()) > 0)
                        row["aprobada"] = true;
                    else
                        row["aprobada"] = false;
                }
                GVLaboresRequeridas.DataSource = Labores;
                GVMecánicosParticipantes.DataSource = Mecánicos;
                GVRepuestos.DataSource = Repuestos;
                foreach (DataRow row in Roles.Rows) {
                    DDLRol.Items.Add(new ListItem(row["nombre_rol"].ToString(), row["id_rol"].ToString()));
                }
                foreach (DataRow row in ListaLabores.Rows) {
                    DDLLabores.Items.Add(new ListItem(row["descripcion"].ToString(), row["id_labor"].ToString()));
                }

                GVLaboresRequeridas.DataBind();
                GVMecánicosParticipantes.DataBind();
                GVRepuestos.DataBind();
            }
        }

        protected void BAgregarRepuesto_Click(object sender, EventArgs e) {
            if (reparacionVálida) {
                JazzTaller_Utilerías.Objetos.Repuestos repuesto = new Repuestos();
                repuesto.Descripción = TBRepuestoDescripción.Text;
                repuesto.Precio = int.Parse(TBRepuestoPrecio.Text);
                repuesto.Reparación = IDReparación;

                consultaBll.RegistrarRepuestoAsignado(repuesto);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void BAgregarMecánico_Click(object sender, EventArgs e) {
            if (reparacionVálida) {
                MecánicosParticipantes mecánico = new MecánicosParticipantes();
                mecánico.Reparación = IDReparación;
                mecánico.Mecánico = int.Parse(TBCódigoMecánico.Text);
                mecánico.Rol = int.Parse(DDLRol.SelectedValue);
                mecánico.Horas = int.Parse(TBHoras.Text);

                consultaBll.RegistrarMecánicoParticipante(mecánico);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void BAgregarLabor_Click(object sender, EventArgs e) {
            if (reparacionVálida) {
                LaboresRequeridas labores = new LaboresRequeridas();
                labores.Reparación = IDReparación;
                labores.Mecánico = int.Parse(TBCódigoMecánicoLabor.Text);
                labores.Labor = int.Parse(DDLLabores.SelectedValue);
                labores.Aprobada = CBConfirmarAutomático.Checked;

                consultaBll.RegistrarLaborRequerida(labores);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void BGuardar_Click(object sender, EventArgs e) {
            if (reparacionVálida) {
                GuardarCambios();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void BCompletar_Click(object sender, EventArgs e) {
            if (reparacionVálida) {
                GuardarCambios();
                Page.Response.Redirect("Costo.aspx?id=" + IDReparación.ToString(), true);
            }
        }

        private void GuardarCambios() {
            Reparaciones reparacion = new Reparaciones(IDReparación);
            reparacion.Notas = TBNotas.Text;
            reparacion.Diagnóstico = TBDiagnóstico.Text;
            int diagnostica, evalua;
            if (int.TryParse(TBDiagnostica.Text, out diagnostica))
                reparacion.Diagnostica = diagnostica;
            else
                reparacion.Diagnostica = -1;
            if (int.TryParse(TBEvalúa.Text, out evalua))
                reparacion.Evalúa = evalua;
            else
                reparacion.Evalúa = -1;
            reparacion.Evaluación = TBEvaluación.Text;
            reparacion.Fecha = DateTime.Parse(LFecha.Text);
            reparacion.Completada = false;

            modBll.ModificarReparacion(reparacion);
        }

        protected void BModificarLabor_Click(object sender, EventArgs e) {
            if (reparacionVálida) {
                int idLabor;
                if (int.TryParse(TBIDLabor.Text, out idLabor)) {
                    LaboresRequeridas labor = new LaboresRequeridas();
                    labor.IdLaborRequerida = idLabor;
                    labor.Aprobada = CBAprobarLabor.Checked;
                    modBll.ModificarLaborRequerida(labor);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
        }
    }
}