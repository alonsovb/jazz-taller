using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RegistroBLL;
using JazzTaller_Utilerías.Objetos;

namespace JazzTaller
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        RegistroConsultasBLL registroBLL = new RegistroConsultasBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable Info_Recordatorio = registroBLL.ConsultarAlertas();

            if (Info_Recordatorio.Rows.Count != 0)
            {
                this.GVRecordatorio.Visible = true;
                this.GVRecordatorio.DataSource = Info_Recordatorio;
                this.GVRecordatorio.DataBind();
            }
        }

        protected void BRegistrarAlerta_Click(object sender, EventArgs e)
        {
            int placa;
            DateTime fecha;
            String recordatorio;

            try { placa = Convert.ToInt32(this.TBPlacaReg.Text); }
            catch { placa = -1; }

            try { fecha = this.CAlertaReg.SelectedDate; }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Debe escojer una fecha');", true);
                return;
            }

            recordatorio = TBAlertaReg.Text;

            if (fecha < DateTime.Now)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Debe escojer una fecha mayor a la de hoy');", true);
                return;
            }

            Alerta Alert = new Alerta(placa,fecha,recordatorio);
            registroBLL.RegistrarAlerta(Alert);


        }
    }
}