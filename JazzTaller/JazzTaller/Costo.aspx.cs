using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegistroBLL;
using JazzTaller_Utilerías.Objetos;
using System.Data;

namespace JazzTaller
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        RegistroConsultasBLL registroBLL = new RegistroConsultasBLL();
        ModificarBLL modificarBLL = new ModificarBLL();
        int IDReparación;
        bool reparacionVálida = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                reparacionVálida = true;
                IDReparación = int.Parse(Request.QueryString["id"]);
                DataTable InfoCostosReparacion = registroBLL.ConsultarCostoReparaciones(IDReparación);
                DataTable InfoCostosRepuestos = registroBLL.ConsultarCostoRepuestos(IDReparación);
                this.GVCostosReparacion.DataSource = InfoCostosReparacion;
                this.GVCostosReparacion.DataBind();
                this.GVCostosRepuestos.DataSource = InfoCostosRepuestos;
                this.GVCostosRepuestos.DataBind();

                int total = 0;

                for (int i = 0; i != InfoCostosReparacion.Rows.Count; i++)
                {
                    total = total + Convert.ToInt32(InfoCostosReparacion.Rows[i]["total"].ToString());
                }

                for (int i = 0; i != InfoCostosRepuestos.Rows.Count; i++)
                {
                    total = total + Convert.ToInt32(InfoCostosRepuestos.Rows[i]["total"].ToString());
                }

                LTotal.Visible = true;
                LTotal.Text = total.ToString();

            }
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            if (reparacionVálida) {
                Reparaciones MReparacion = new Reparaciones();
                MReparacion.IdReparación = IDReparación;
                MReparacion.Completada = true;
                modificarBLL.ModificarReparacion(MReparacion);
                Page.Response.Redirect("Default.aspx?listar=completar",true);
            }

        }
    }
}