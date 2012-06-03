using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegistroBLL;

namespace JazzTaller {

    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            RegistroConsultasBLL consultarBLL = new RegistroConsultasBLL();
            if (Request.QueryString["listar"] != null) {
                switch (Request.QueryString["listar"]) {
                    case "diagnosticar":
                        GVListaReparacion.DataSource = consultarBLL.ConsultarPorDiagnosticar();
                        LTipoLista.Text = "Lista de reparaciones por diagnosticar";
                        break;
                    case "evaluar":
                        GVListaReparacion.DataSource = consultarBLL.ConsultarPorEvaluar();
                        LTipoLista.Text = "Lista de reparaciones por evaluar";
                        break;
                    case "completar":
                        GVListaReparacion.DataSource = consultarBLL.ConsultarPorCompletar();
                        LTipoLista.Text = "Lista de reparaciones por completar";
                        break;
                    default:
                        GVListaReparacion.DataSource = consultarBLL.ConsultarListaReparacion();
                        LTipoLista.Text = "Lista de reparaciones";
                        break;
                }
                this.GVListaReparacion.DataBind();
            }
        }
    }
}
