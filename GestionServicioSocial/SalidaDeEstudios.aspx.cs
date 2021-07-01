using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace GestionServicioSocial
{
    public partial class SalidaDeEstudios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["userProfe"] == null) 
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        

        public void insertarPermisoAcademico() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarpermisosDatosAcademicos";
                    cmd.Parameters.Add("@idPermisoAcademico", SqlDbType.VarChar).Value = txtyCantidadAlumnos.Text.Trim()+txtNumeroCelDocente.Text.Trim();
                    cmd.Parameters.Add("@visitaPractica", SqlDbType.VarChar).Value = txtVisitaPractica.SelectedItem.ToString();
                    cmd.Parameters.Add("@visitaIndustrial", SqlDbType.VarChar).Value = txtVisitaIndustrial.SelectedItem.ToString();
                    cmd.Parameters.Add("@practica", SqlDbType.VarChar).Value = txtPractica.SelectedItem.ToString();
                    cmd.Parameters.Add("@docenteResponsable", SqlDbType.VarChar).Value = txtDocenteResponsable.Text.Trim();
                    cmd.Parameters.Add("@numCelularDocente", SqlDbType.VarChar).Value = txtNumeroCelDocente.Text.Trim();
                    cmd.Parameters.Add("@CorreoElectronicoDocente", SqlDbType.VarChar).Value = txtCorreoElextronicoDocente.Text.Trim();
                    cmd.Parameters.Add("@materia", SqlDbType.VarChar).Value = txtMateria.Text.Trim();
                    if (txtSemestre.SelectedValue.ToString().Equals("primer"))
                    {
                        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = "primer";
                    }
                    else if (txtSemestre.SelectedValue.ToString().Equals("tercer"))
                    {
                        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = "tercer";
                    }
                    else {
                        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = txtSemestre.SelectedItem.ToString();
                    }
                    

                    cmd.Parameters.Add("@grupo", SqlDbType.VarChar).Value = txtGrupo.SelectedItem.ToString();
                    cmd.Parameters.Add("@alumnosProgramados", SqlDbType.VarChar).Value = txtyCantidadAlumnos.Text.Trim();
                    cmd.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = txtEspecialidad.SelectedItem.ToString();

                    if (txtEspecialidad.SelectedItem.ToString().Equals("IINF"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA INFORMÁTICA";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IM"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA MECATRÓNICA";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IA"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA EN ADMINISTRACIÓN";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("II"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA INDUSTRIAL";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IF"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA FORESTAL";
                        
                    }
                    
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("LB"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "LICENCIATURA EN BIOLOGÍA";
                        
                    }
                    else
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "LICENCIATURA EN GASTRONOMÍA";
                        
                    }

                    cmd.Parameters.Add("@objetivo", SqlDbType.VarChar).Value = txtObjetivo.Text.Trim();
                    cmd.Parameters.Add("@practicaDescripcion", SqlDbType.VarChar).Value = txtEncasoPractica.Text.Trim();
                  
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtInstitucion.Text = ex.Message.ToString();
                }




            }
        }


        public void insertarPermisosEmpresa() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarpermisosDatosEmpresa";
                    cmd.Parameters.Add("@idPermiso", SqlDbType.VarChar).Value = txtyCantidadAlumnos.Text.Trim() + txtNumeroCelDocente.Text.Trim();
                    cmd.Parameters.Add("@nombreInstitucion", SqlDbType.VarChar).Value = txtInstitucion.Text.Trim();
                    cmd.Parameters.Add("@representante", SqlDbType.VarChar).Value = txtRepresentante.Text.Trim();
                    cmd.Parameters.Add("@puestoOcargo", SqlDbType.VarChar).Value = txtPuestoOCargo.Text.Trim();
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txtDireccion.Text.Trim();
                    cmd.Parameters.Add("@municipioEstado", SqlDbType.VarChar).Value = txtMunicipioEstado.Text.Trim();
                    cmd.Parameters.Add("@telefonoOrganizacion", SqlDbType.VarChar).Value = txtTelefonoEmpresa.Text.Trim();
                    cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = txtFax.Text.Trim();
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("@paginaWeb", SqlDbType.VarChar).Value = txtPaginaWeb.Text.Trim();
                    cmd.Parameters.Add("@fechaVisita", SqlDbType.VarChar).Value = txtFechaPropuesta.Text.Trim();
                    cmd.Parameters.Add("@horaPropuesta", SqlDbType.VarChar).Value = txtHoraPropuesta.Text.Trim();
                    cmd.Parameters.Add("@viajeNoche", SqlDbType.VarChar).Value = txtViajeNoche.SelectedItem.ToString();
                    cmd.Parameters.Add("@recomendaciones", SqlDbType.VarChar).Value = txtRecomedacionesOrganizacion.Text.Trim();
                    cmd.Parameters.Add("@idPermisoAcademico", SqlDbType.VarChar).Value = txtyCantidadAlumnos.Text.Trim() + txtNumeroCelDocente.Text.Trim();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtInstitucion.Text = ex.Message.ToString();
                }




            }
        }

        protected void BtnGenerarPermiso_Click(object sender, EventArgs e)
        {

            insertarPermisoAcademico();
            insertarPermisosEmpresa();
            Response.Redirect("ReportePermisos.aspx?parametro=" + txtyCantidadAlumnos.Text.Trim() + txtNumeroCelDocente.Text.Trim());

        }




        protected void txtVisitaPractica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtVisitaPractica.SelectedItem.ToString().Equals("PRESENCIAL")) {
                txtVisitaIndustrial.Text = "";
                txtPractica.Text = "";
                txtEncasoPractica.Visible = true;
                txtEncasoDeSerPractica2.Visible = true;

            }
            else if(txtVisitaPractica.SelectedItem.ToString().Equals("VIRTUAL"))
            {
                txtVisitaIndustrial.Text = "";
                txtPractica.Text = "";
                txtEncasoPractica.Visible = true;
                txtEncasoDeSerPractica2.Visible = true;
            }
        }

        protected void txtVisitaIndustrial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtVisitaIndustrial.SelectedItem.ToString().Equals("PRESENCIAL"))
            {
                txtVisitaPractica.Text = "";
                txtPractica.Text = "";
                txtEncasoPractica.Visible = false;
                txtEncasoDeSerPractica2.Visible = false;

            }
            else if (txtVisitaIndustrial.SelectedItem.ToString().Equals("VIRTUAL"))
            {
                txtVisitaPractica.Text = "";
                txtPractica.Text = "";
            }
        }

        protected void txtPractica_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (txtPractica.SelectedItem.ToString().Equals("PRESENCIAL"))
            {
                txtVisitaPractica.Text = "";
                txtVisitaIndustrial.Text = "";
                txtEncasoPractica.Visible = true;
                txtEncasoDeSerPractica2.Visible = true;

            }
            else if (txtVisitaIndustrial.SelectedItem.ToString().Equals("VIRTUAL"))
            {
                txtVisitaPractica.Text = "";
                txtVisitaIndustrial.Text = "";
            }
        }
    }
}