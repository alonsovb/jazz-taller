using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroDAL;
using System.Data;
using JazzTaller_Utilerías.Objetos;

namespace RegistroBLL {
    public class RegistroConsultasBLL {

        ConsultasDAL Consultas = new ConsultasDAL();
        RegistrosDAL Registros = new RegistrosDAL();

        public DataTable ConsultarAutos(Autos DatosA) {
            try { return this.Consultas.ConsultarAutos(DatosA); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarAutPers(Personas DatosP)
        {
            try { return this.Consultas.ConsultarAutPers(DatosP); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarPersonas(Personas DatosP) {
            try { return this.Consultas.ConsultarPersonas(DatosP); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarTeléfonos(Teléfonos DatosT) {
            try { return this.Consultas.ConsultarTelefonos(DatosT); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarEmails(Emails DatosE) {
            try { return this.Consultas.ConsultarEmails(DatosE); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarListaReparacion() {
            try { return this.Consultas.ConsultarListaReparacion(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarMecanico(Personas DatosP) {
            try { return this.Consultas.ConsultarMecanico(DatosP); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarMecanicos() {
            try { return this.Consultas.ConsultarMecanicos(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public DataTable ConsultarPorDiagnosticar() {
            try { return this.Consultas.ConsultarPorDiagnosticar(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarPorEvaluar() {
            try { return this.Consultas.ConsultarPorEvaluar(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarPorCompletar() {
            try { return this.Consultas.ConsultarPorCompletar(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarHistorial() {
            try { return this.Consultas.ConsultarHistorial(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarCostoReparaciones(int id_cita) {
            try { return this.Consultas.ConsultarCostoReparacion(id_cita); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarCostoRepuestos(int id_cita) {
            try { return this.Consultas.ConsultarCostoRepuestos(id_cita); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarReparacion(Reparaciones DatosR) {
            try { return this.Consultas.ConsultarReparacion(DatosR); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarLaboresAsignadas(Reparaciones DatosR) {
            try { return this.Consultas.ConsultarLaboresAsignadas(DatosR); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarMecánicosAsignados(Reparaciones DatosR) {
            try { return this.Consultas.ConsultarMecánicosAsignados(DatosR); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarRepuestosAsignados(Reparaciones DatosR) {
            try { return this.Consultas.ConsultarRepuestosAsignados(DatosR); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarRoles() {
            try { return this.Consultas.ConsultarRoles(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarLabores() {
            try { return this.Consultas.ConsultarLabores(); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable ConsultarAlertas()
        {
            try { return this.Consultas.ConsultarAlerta(); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        //Funciones para registrar informacion
        public String RegistrarAutsPersRepas(Autos DatosA, Personas DatosP, Reparaciones DatosR) {
            try { return this.Registros.RegistrarAutPerRep(DatosA, DatosP, DatosR); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public String RegistrarAutsRepas(Autos DatosA, Reparaciones DatosR) {
            try { return this.Registros.RegistrarAutRep(DatosA, DatosR); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public String RegistrarRepas(Reparaciones DatosR) {
            try { return this.Registros.RegistrarReparaciones(DatosR); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable RegistrarTelefonos(Teléfonos DatosT) {
            try { return this.Registros.RegistrarTelefono(DatosT); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable RegistrarEmails(Emails DatosE) {
            try { return this.Registros.RegistrarEmail(DatosE); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public String RegistrarMecanicos(Personas DatosP, Mecánico DatosM) {
            try { return this.Registros.RegistrarPersMec(DatosP, DatosM); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void RegistrarRepuestoAsignado(Repuestos repuesto) {
            try { this.Registros.RegistrarRepuestoAsignado(repuesto); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void RegistrarMecánicoParticipante(MecánicosParticipantes mecánico) {
            try { this.Registros.RegistrarMecánicoParticipante(mecánico); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void RegistrarLaborRequerida(LaboresRequeridas labor) {
            try { this.Registros.RegistrarLaborRequerida(labor); } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void RegistrarAlerta(Alerta DatosAlert)
        {
            try { this.Registros.RegistrarAlerta(DatosAlert); }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
