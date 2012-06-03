using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegistroBLL;
using JazzTaller_Utilerías.Objetos;
using System.Data;

namespace JazzTaller {
    public partial class WebForm1 : System.Web.UI.Page
    {

        private bool _knownCar = false;
        private bool _knownClient = false;
        private int _carID = -1;
        private int _clientID = -1;
        RegistroConsultasBLL INST_Registro_BLL = new RegistroConsultasBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1950; i <= DateTime.Now.Year + 1; i++)
            {
                DDAño.Items.Add(i.ToString());
            }
            DDAño.SelectedIndex = DDAño.Items.Count - 2;
            FileStream fs = new FileStream(Server.MapPath("Marcas.txt"), FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            while (line != null)
            {
                DDMarcas.Items.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            int placa;
            int cedula;

            // Due to a timing issue with when page validation occurs, call the
            // Validate method to ensure that the values on the page are valid.
            Page.Validate();
            // Add the values in the text boxes if the page is valid.
            if (Page.IsValid)
            {
                try { placa = Convert.ToInt32(this.TBPlaca.Text); }
                catch (Exception) { placa = -1; }

                try { cedula = Convert.ToInt32(this.TBIdentificación.Text); }
                catch (Exception) { cedula = -1; }

                Autos Auto = new Autos(placa);
                DataTable Info_Auto = INST_Registro_BLL.ConsultarAutos(Auto);

                Personas Persona = new Personas(cedula);
                DataTable Info_Persona = INST_Registro_BLL.ConsultarPersonas(Persona);

                Teléfonos Telefono = new Teléfonos(cedula);
                DataTable Info_Telefono = INST_Registro_BLL.ConsultarTeléfonos(Telefono);

                Emails Email = new Emails(cedula);
                DataTable Info_Email = INST_Registro_BLL.ConsultarEmails(Email);


                if (Info_Auto.Rows.Count != 0)
                {
                    _knownCar = true;
                    _carID = Convert.ToInt32(Info_Auto.Rows[0]["id_auto"].ToString());
                    _clientID = Convert.ToInt32(Info_Auto.Rows[0]["id_persona"].ToString());
                    // Carga los datos del auto en la pagina
                    TBModelo.Text = Info_Auto.Rows[0]["modelo"].ToString();
                    DDMarcas.DataTextField = "marca";
                    DDMarcas.DataSource = Info_Auto;
                    DDMarcas.DataBind();
                    TBNúmeroVIN.Text = Info_Auto.Rows[0]["numero_vin"].ToString();
                    DDAño.SelectedValue = Info_Auto.Rows[0]["anno"].ToString();
                    TBColor.Text = Info_Auto.Rows[0]["color"].ToString();

                    TBModelo.Enabled = false;
                    DDMarcas.Enabled = false;
                    TBNúmeroVIN.Enabled = false;
                    DDAño.Enabled = false;
                    TBColor.Enabled = false;

                }

                if (Info_Persona.Rows.Count > 0 && Info_Persona.Rows.Count < 2) 
                {
                    _knownClient = true;
                    _clientID = Convert.ToInt32(Info_Persona.Rows[0]["id_persona"].ToString());
                    // Carga los datos de la persona en la pagina
                    TBNombre.Text = Info_Persona.Rows[0]["nombre"].ToString();
                    TBApellidos.Text = Info_Persona.Rows[0]["apellido"].ToString();

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

                    TBNombre.Enabled = false;
                    TBApellidos.Enabled = false;
                    TBTeléfonos.Enabled = false;
                    TBEmails.Enabled = false;
                }
                else
                    EnableControls();

            }
        }

        protected void BRegistrarReparación_Click(object sender, EventArgs e)
        {

            // Car is new, store info in DB
            if (_knownCar)
            {
                String notas;
                bool confirma;

                notas = this.TBNotas.Text;
                confirma = this.CBConfirmarTodo.Checked;
                Reparaciones NReparacion = new Reparaciones(_carID, _clientID, false, DateTime.Now, notas, -1, "", -1, "", false, confirma);
                String retorno = INST_Registro_BLL.RegistrarRepas(NReparacion);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" + retorno + ");", true);
            }

            // Store new reparation
            if (!_knownCar && !_knownClient)
            {
                // Datos autos
                int placa;
                String marca;
                String modelo;
                int numero_vin;
                int anno;
                String color;
                String notas;
                // Datos de la persona
                int identificacion;
                String nombre;
                String apellidos;
                bool es_duenno;
                bool confirma;

                try { placa = Convert.ToInt32(this.TBPlaca.Text); }
                catch (Exception) { placa = -1; }

                try { numero_vin = Convert.ToInt32(this.TBNúmeroVIN.Text); }
                catch (Exception) { numero_vin = -1; }

                try { anno = Convert.ToInt32(this.DDAño.SelectedValue); }
                catch (Exception) { anno = -1; }

                try { identificacion = Convert.ToInt32(this.TBIdentificación.Text); }
                catch (Exception) { identificacion = -1; }

                marca = this.DDMarcas.SelectedValue;
                modelo = this.TBModelo.Text;
                color = this.TBColor.Text;
                notas = this.TBNotas.Text;
                nombre = this.TBNombre.Text;
                apellidos = this.TBApellidos.Text;
                es_duenno = this.CBDueño.Checked;
                confirma = this.CBConfirmarTodo.Checked;





                Personas NPersona = new Personas(identificacion, nombre, apellidos);
                Autos NAuto = new Autos(placa, marca, modelo, anno, numero_vin, color);
                Reparaciones NReparacion = new Reparaciones(-1, -1, es_duenno, DateTime.Now, notas, -1, "", -1, "", false, confirma);
                String retorno = INST_Registro_BLL.RegistrarAutsPersRepas(NAuto, NPersona, NReparacion);

                string[] phones = TBTeléfonos.Text.Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string phone in phones)
                {
                    Teléfonos telefono = new Teléfonos(identificacion, phone.Trim().ToString());
                    INST_Registro_BLL.RegistrarTelefonos(telefono);
                }

                string[] emails = TBEmails.Text.Split(Utilities.Separators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string email in emails)
                {
                    Emails correo = new Emails(identificacion, email.Trim().ToString());
                    INST_Registro_BLL.RegistrarEmails(correo);
                }

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" + retorno + ");", true);
            }


            if (!_knownCar && _knownClient)
            {

                // Datos autos
                int placa;
                String marca;
                String modelo;
                int numero_vin;
                int anno;
                String color;
                String notas;
                bool es_duenno;
                bool confirma; 

                try { placa = Convert.ToInt32(this.TBPlaca.Text); }
                catch (Exception) { placa = -1; }

                try { numero_vin = Convert.ToInt32(this.TBNúmeroVIN.Text); }
                catch (Exception) { numero_vin = -1; }

                try { anno = Convert.ToInt32(this.DDAño.SelectedValue); }
                catch (Exception) { anno = -1; }

                marca = this.DDMarcas.SelectedValue;
                modelo = this.TBModelo.Text;
                color = this.TBColor.Text;
                notas = this.TBNotas.Text;
                es_duenno = this.CBDueño.Checked;
                confirma = this.CBConfirmarTodo.Checked;
                


                Autos NAuto = new Autos(placa, marca, modelo, anno, numero_vin, color);
                Reparaciones NReparacion = new Reparaciones(-1, _clientID, es_duenno, DateTime.Now, notas, -1, "", -1, "", false, confirma);
                String retorno = INST_Registro_BLL.RegistrarAutsRepas(NAuto, NReparacion);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" + retorno + ");", true);
            }
            // Clean and enable controls
            ClearControls();
            EnableControls();


        }

        private void ClearControls()
        {
            TBPlaca.Text = String.Empty;
            TBModelo.Text = String.Empty;
            TBColor.Text = String.Empty;
            TBEmails.Text = String.Empty;
            TBIdentificación.Text = String.Empty;
            TBNombre.Text = String.Empty;
            TBNúmeroVIN.Text = String.Empty;
            TBTeléfonos.Text = String.Empty;
            TBApellidos.Text = String.Empty;
            TBNotas.Text = String.Empty;
        }

        private void EnableControls()
        {
            TBModelo.Enabled = true;
            DDMarcas.Enabled = true;
            TBNúmeroVIN.Enabled = true;
            DDAño.Enabled = true;
            TBColor.Enabled = true;
            TBNombre.Enabled = true;
            TBApellidos.Enabled = true;
            TBTeléfonos.Enabled = true;
            TBEmails.Enabled = true;
        }

       
    }
}