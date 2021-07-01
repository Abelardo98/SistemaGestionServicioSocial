﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class servicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                BtnContinuar.Enabled = true;
                LinkButton2.Visible = false;
            }

            if (Request.Params["parametro"] != null)
            {

                txtNumeroControl.Text = Request.Params["parametro"];

            }
        }

        public void insertarPrograma() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarPrograma";
                    cmd.Parameters.Add("@idPrograma", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@nombreDependencia", SqlDbType.VarChar).Value = txtDependenciaOficial.Text.Trim();
                    cmd.Parameters.Add("@nombreTitular", SqlDbType.VarChar).Value = txtTitularDependencia.Text.Trim();
                    cmd.Parameters.Add("@puestoTitular", SqlDbType.VarChar).Value = txtPuestoTitular.Text.Trim();
                    cmd.Parameters.Add("@areaAlumno", SqlDbType.VarChar).Value = txtAreaAlumno.Text.Trim();
                    cmd.Parameters.Add("@nombreAcesor", SqlDbType.VarChar).Value = txtNombrePersonaServicio.Text.Trim();
                    cmd.Parameters.Add("@puestoAcesor", SqlDbType.VarChar).Value = txtPuesto.Text.Trim();
                    cmd.Parameters.Add("@nombrePrograma", SqlDbType.VarChar).Value = txtNombrePrograma.Text.Trim();
                    cmd.Parameters.Add("@programaActividad", SqlDbType.VarChar).Value = txtProgramaActividades.Text.Trim();

                    if (txttipoprograma.SelectedItem.ToString().Equals("OTRO"))
                    {
                        cmd.Parameters.Add("@tipoPrograma", SqlDbType.VarChar).Value = TextBox1.Text.Trim(); ;
                    }
                    else
                    {
                        cmd.Parameters.Add("@tipoPrograma", SqlDbType.VarChar).Value = txttipoprograma.SelectedItem.ToString();
                    }
                 
                    cmd.Parameters.Add("@servicioTec", SqlDbType.VarChar).Value = txtServicio.SelectedItem.ToString();
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@correoAsesorExterno", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@fechaInicioServ", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@fechaTerminoServ", SqlDbType.VarChar).Value = "";
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtPuestoTitular.Text = ex.Message;
                }
            }
        }

        public void insertaripyss() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarrpyss";
                    cmd.Parameters.Add("@idrpyss", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@modalidad", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value =" ";
                    cmd.Parameters.Add("@fechaTermi", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@aceptado", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@motivo", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@idprograma", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {

                }




            }

        }

        public void validarCamposServicioTec() {

            if (txtServicio.SelectedItem.Text.ToString().Equals("SI"))
            {
                LinkButton2.Visible = true;
                BtnContinuar.Enabled = false;

                if (txtAreaAlumno.Text.Length > 1 && txtNombrePersonaServicio.Text.Length > 1)
                {
                    BtnContinuar.Enabled = true;
                }
                
            }
            else if (txtServicio.SelectedItem.Text.ToString().Equals("NO"))
            {
                
                BtnContinuar.Enabled = true;


            }
            else {
                txtProgramaActividades.Text = "Entro al else";
            }
            
        
        }
        


        protected void BtnContinuar_Click(object sender, EventArgs e)
        {
            insertarPrograma();
            insertaripyss();
            Server.Transfer("sesion.aspx");
        }

        protected void txtServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtServicio.SelectedItem.ToString().Equals("SI"))
            {
                LinkButton2.Visible = true;
                LinkButton1.Visible = false;
                txtDependenciaOficial.Text = "INSTITUTO TECNOLÓGICO SUPERIOR DE ZACAPOAXTLA";
                txtTitularDependencia.Text = "GUSTAVO URBANO JUÁREZ";
                txtPuestoTitular.Text = "DIRECTOR GENERAL";
                
            }
            else
            {

                BtnContinuar.Enabled = true;
                LinkButton2.Visible = false;
                LinkButton1.Visible = true;
                txtDependenciaOficial.Text = "";
                txtTitularDependencia.Text = "";
                txtPuestoTitular.Text = "";
                txtAreaAlumno.Text = "";
                txtNombrePersonaServicio.Text = "";
            }
        }

        protected void txtDependenciaOficial_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtTitularDependencia_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtPuestoTitular_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtAreaAlumno_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtNombrePersonaServicio_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        public void validarTipoPrograma() {

            if (txtServicio.SelectedItem.ToString().Equals("SI")) {
                if (txtDependenciaOficial.Text.Length > 1 && txtTitularDependencia.Text.Length > 1 && txtPuestoTitular.Text.Length > 1)
                {
                    LinkButton1.Visible = true;
                    BtnContinuar.Enabled = true;
                }
                else {
                    LinkButton1.Visible = true;
                    BtnContinuar.Enabled = false;

                }


            } else if (txtServicio.SelectedItem.ToString().Equals("NO")) {
                if (txtDependenciaOficial.Text.Length > 1 && txtTitularDependencia.Text.Length > 1 && txtPuestoTitular.Text.Length > 1 && txtAreaAlumno.Text.Length >1 && txtNombrePersonaServicio.Text.Length > 1)
                {
                    BtnContinuar.Enabled = true;
                }
                else {
                    BtnContinuar.Enabled = false;
                }

            }
            else { 
            
            }
        
        }
        
        protected void txttipoprograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txttipoprograma.SelectedItem.ToString().Equals("OTRO"))
            {
                
                Label11.Visible = true;
                TextBox1.Visible = true;
                
                //validarTipoPrograma();
            }
            else {
                Label11.Visible = false;
                TextBox1.Visible = false;
                
                //validarTipoPrograma();
            }
        }
    }
}