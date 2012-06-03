using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegistroBLL;
using System.Data;

namespace JazzTaller
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        RegistroConsultasBLL registroBLL = new RegistroConsultasBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable Info_Historial = registroBLL.ConsultarHistorial();
            this.GVHistorial.DataSource = Info_Historial;
            this.GVHistorial.DataBind();
        }
    }
}