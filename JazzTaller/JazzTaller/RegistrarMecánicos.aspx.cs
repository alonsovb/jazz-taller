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
    public partial class WebForm2 : System.Web.UI.Page {
        RegistroConsultasBLL registroBLL = new RegistroConsultasBLL();

        protected void Page_Load(object sender, EventArgs e) {

                int cedula;
                bool existeMecanico = false;

                try { cedula = Convert.ToInt32(this.TBIdentificación.Text); }
                catch (Exception) { cedula = -1; }

                Personas Mecanico = new Personas(cedula);
                DataTable Info_Mecanico = registroBLL.ConsultarMecanico(Mecanico);

                Teléfonos Telefono = new Teléfonos(cedula);
                DataTable Info_Telefono = registroBLL.ConsultarTeléfonos(Telefono);

                Emails Email = new Emails(cedula);
                DataTable Info_Email = registroBLL.ConsultarEmails(Email);


                if (Info_Mecanico.Rows.Count != 0)
                {
                    existeMecanico = true;
                    TBNombre.Text = Info_Mecanico.Rows[0]["nombre"].ToString();
                    TBApellidos.Text = Info_Mecanico.Rows[0]["apellido"].ToString();
                    TBCódigo.Text = Info_Mecanico.Rows[0]["codigo"].ToString();
                    TBTítulo.Text = Info_Mecanico.Rows[0]["titulo"].ToString();
                    TBExperiencia.Text = Info_Mecanico.Rows[0]["experiencia"].ToString();
                }

                else if (Info_Mecanico.Rows.Count == 0)
                { 
                    BRegistrarMecánico.Enabled = true;
                    return;
                }

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
                    TBEmails.Text = STREmail;
                }

                if (existeMecanico)
                    BRegistrarMecánico.Enabled = false;
        }

        protected void BRegistrarMecánico_Click(object sender, EventArgs e)
        {
            int identificacion;
            int codigo;
            int experiencia;
            String nombre;
            String apellido;
            String titulo;

            try { identificacion = Convert.ToInt32(this.TBIdentificación.Text); }
            catch (Exception) { identificacion = -1; }
            try { codigo = Convert.ToInt32(this.TBCódigo.Text); }
            catch (Exception) { codigo = -1; }
            try { experiencia = Convert.ToInt32(this.TBExperiencia.Text); }
            catch (Exception) { experiencia = -1; }

            nombre = this.TBNombre.Text;
            apellido = this.TBApellidos.Text;
            titulo = this.TBTítulo.Text;

            Personas NPersona = new Personas(identificacion, nombre, apellido);
            Mecánico NMecanico = new Mecánico(-1, codigo, titulo, experiencia);
            String retorno = registroBLL.RegistrarMecanicos(NPersona, NMecanico);

            //Registrar telefonos y correos
            Teléfonos Telefono = new Teléfonos(identificacion);
            DataTable Info_Telefono = registroBLL.ConsultarTeléfonos(Telefono);

            Emails Email = new Emails(identificacion);
            DataTable Info_Email = registroBLL.ConsultarEmails(Email);

            if (Info_Telefono.Rows.Count == 0)
            {
                string[] phones = TBTeléfonos.Text.Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string phone in phones)
                {
                    Teléfonos telefono = new Teléfonos(identificacion, phone.Trim().ToString());
                    registroBLL.RegistrarTelefonos(telefono);
                }
            }

            if (Info_Email.Rows.Count == 0)
            {
                string[] emails = TBEmails.Text.Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string email in emails)
                {
                    Emails correo = new Emails(identificacion, email.Trim().ToString());
                    registroBLL.RegistrarEmails(correo);
                }
            }
            BRegistrarMecánico.Enabled = false;          

        }

        
    }
}