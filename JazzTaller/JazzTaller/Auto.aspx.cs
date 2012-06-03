using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JazzTaller_Utilerías.Objetos;
using RegistroBLL;

namespace JazzTaller {

    public partial class AutoWebForm : System.Web.UI.Page {

        RegistroConsultasBLL bll = new RegistroConsultasBLL();

        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["placa"] != null) {
                CargarPorPlaca(int.Parse(Request.QueryString["placa"]));
            }
        }

        private void CargarPorPlaca(int placa) {
            Autos auto = new Autos();
            auto.Placa = placa;
            DataTable dt = bll.ConsultarAutos(auto);
            if (dt.Rows.Count != 0)
            {
                LPlaca.Text = placa.ToString();
                LModelo.Text = dt.Rows[0]["modelo"].ToString();
                LMarca.Text = dt.Rows[0]["marca"].ToString();
                LAño.Text = dt.Rows[0]["anno"].ToString();
                LVIN.Text = dt.Rows[0]["numero_vin"].ToString();
                LColor.Text = dt.Rows[0]["color"].ToString();
            }
        }
    }
}