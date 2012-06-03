using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegistroBLL;
using JazzTaller_Utilerías.Objetos;
using System.Data;


namespace JazzTaller {
    public partial class WebForm6 : System.Web.UI.Page {
        RegistroConsultasBLL INST_Registro_BLL = new RegistroConsultasBLL();

        
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack)
            {
                Personas Persona = new Personas();
                DataTable Info_Personas = INST_Registro_BLL.ConsultarPersonas(Persona);
                this.GVClientes.DataSource = Info_Personas;
                this.GVClientes.DataBind();
                CargarInfoClientes();
            }
            else
            {
                DDLAutos.Visible = true;
                String placa = this.DDLAutos.SelectedValue;
                if (this.DDLAutos.SelectedValue != "-Seleccione-")
                {
                    String url = "Auto.aspx?placa=" + placa;
                    Response.Redirect(url);
                }
            }

        }

        protected void GVClientes_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void CargarInfoClientes()
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Teléfonos Telefono = new Teléfonos(id);
                DataTable Info_Telefono = INST_Registro_BLL.ConsultarTeléfonos(Telefono);

                Emails Email = new Emails(id);
                DataTable Info_Email = INST_Registro_BLL.ConsultarEmails(Email);

                Personas Persona = new Personas(id);
                DataTable Info_Auto_Persona = INST_Registro_BLL.ConsultarAutPers(Persona);

                if (Info_Telefono.Rows.Count != 0)
                {
                    int cantTel = 0;
                    String STRtelefonos = "";

                    while (cantTel != (Info_Telefono.Rows.Count - 1))
                    {
                        STRtelefonos = STRtelefonos + Info_Telefono.Rows[cantTel]["telefono"].ToString() + ", ";
                        cantTel++;

                    }
                    STRtelefonos = STRtelefonos + Info_Telefono.Rows[cantTel]["telefono"].ToString();
                    TBTeléfonos.Visible = true;
                    TBTeléfonos.Text = STRtelefonos;
                }

                if (Info_Email.Rows.Count != 0)
                {
                    int cantEmail = 0;
                    String STREmail = "";

                    while (cantEmail != (Info_Email.Rows.Count - 1))
                    {
                        STREmail = STREmail + Info_Email.Rows[cantEmail]["correo"].ToString() + ", ";
                        cantEmail++;
                    }
                    STREmail = STREmail + Info_Email.Rows[cantEmail]["correo"].ToString();
                    TBEmails.Visible = true;
                    TBEmails.Text = STREmail;
                }

                if (Info_Auto_Persona.Rows.Count != 0)
                {
                    //this.DDLAutos.DataTextField = "placa";
                    DDLAutos.Visible = true;
                    this.DDLAutos.DataValueField = "placa";
                    this.DDLAutos.DataSource = Info_Auto_Persona;
                    this.DDLAutos.DataBind();
                    DDLAutos.Items.Insert(0, "-Seleccione-");

                }
            }
        }

        protected void DDLAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String placa = this.DDLAutos.SelectedValue;
            if (this.DDLAutos.SelectedValue != "-Seleccione-")
            {
                String url = "Auto.aspx?placa=" + placa;
                Response.Redirect(url);
            }
        }

    }
}