﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestionServicioSocial
{
    public partial class Recidencia1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton2.Visible = false;
            if (Request.Params["parametro"] != null)
            {

                txtNumeroControl.Text = Request.Params["parametro"];

            }

        }

        public void insertarPrograma()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarProgramaReci";
                    cmd.Parameters.Add("@idPrograma", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@razonSocial", SqlDbType.VarChar).Value = txtRazonSocial.Text.Trim();
                    cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = txtTipo.SelectedItem.ToString();
                    cmd.Parameters.Add("@nombreTitular", SqlDbType.VarChar).Value = txtTitularDependencia.Text.Trim();
                    cmd.Parameters.Add("@puestoTitular", SqlDbType.VarChar).Value = txtPuestoTitular.Text.Trim();
                    cmd.Parameters.Add("@areaAlumno", SqlDbType.VarChar).Value = txtAreaAlumno.Text.Trim();
                    cmd.Parameters.Add("@nombreAcesor", SqlDbType.VarChar).Value = txtNombreAsesorExterno.Text.Trim();
                    cmd.Parameters.Add("@puestoAcesor", SqlDbType.VarChar).Value = txtPuestoAsesorExterno.Text.Trim();
                    cmd.Parameters.Add("@correoAcesor", SqlDbType.VarChar).Value = txtCorreo.Text.Trim();
                    cmd.Parameters.Add("@nombreProyecto", SqlDbType.VarChar).Value = txtNombreProyecto.Text.Trim();
                    cmd.Parameters.Add("@recidenciaTec", SqlDbType.VarChar).Value = txtResidencia.SelectedItem.ToString();
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
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

        public void insertaripyss()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarrpyssReci";
                    cmd.Parameters.Add("@idrpyss", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@modalidad", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@fechaTermi", SqlDbType.VarChar).Value = " ";
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
        

        protected void BtnContinuar_Click(object sender, EventArgs e)
        {
            insertarPrograma();
            insertaripyss();
            Server.Transfer("sesion.aspx");
        }

        protected void txtResidencia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtResidencia.SelectedItem.ToString().Equals("SI")) {
                
                LinkButton2.Visible = true;
                LinkButton1.Visible = false;
                txtTipo.Enabled = true;
                BtnContinuar.Enabled = false;
                txtRazonSocial.Text = "INSTITUTO TECNOLÓGICO SUPERIOR DE ZACAPOAXTLA";
                txtTitularDependencia.Text = "GUSTAVO URBANO JUÁREZ";
                txtPuestoTitular.Text = "DIRECTOR GENERAL";
                txtTipo.SelectedValue= "Público";
                txtTipo.Enabled = false;

            }
            else {
                
                LinkButton2.Visible = false;
                LinkButton1.Visible = true;
                txtTipo.Enabled = true;
                txtRazonSocial.Text = "";
                txtTitularDependencia.Text = "";
                txtPuestoTitular.Text = "";               
                txtAreaAlumno.Text = "";
                txtNombreAsesorExterno.Text = "";
            }
            

        }

        public void validarCamposServicioTec()
        {
            BtnContinuar.Enabled = false;
            
            if (txtResidencia.SelectedItem.Text.ToString().Equals("SI"))
            {
                LinkButton2.Visible = true;


                if (txtAreaAlumno.Text.Length > 1 && txtNombreAsesorExterno.Text.Length > 1 && txtPuestoAsesorExterno.Text.Length > 1)
                {
                    BtnContinuar.Enabled = true;
                }

            }
            else if (txtResidencia.SelectedItem.Text.ToString().Equals("NO"))
            {

                BtnContinuar.Enabled = true;


            }
            else
            {
                txtPuestoAsesorExterno.Text = "Entro al else";
            }


        }

        protected void txtNombreAsesorExterno_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtAreaAlumno_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtPuestoAsesorExterno_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }
    }
}