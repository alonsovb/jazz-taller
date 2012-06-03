using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RegistroBLL;

namespace JazzTaller
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        RegistroConsultasBLL registroBLL = new RegistroConsultasBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable mecanicos = registroBLL.ConsultarMecanicos();
            GVMecanicos.DataSource = mecanicos;
            GVMecanicos.DataBind();

        }

        protected void BRegistrarMecanico_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("registrarMecánicos.aspx", true);
        }
    }
}