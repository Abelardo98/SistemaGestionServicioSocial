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
    public partial class vistaRecidencia : System.Web.UI.Page
    {
        DataTable dt;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["userAdmin"] == null) 
                {
                    Response.Redirect("index.aspx");
                }
                
            }
            //txtCambioVistas.Text = "Residencias profesionales";
        }

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }
        public void busquedaGeneral()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    //da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido Paterno\",apellidom as \"Apellido Materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\", nombretitular as \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\", nombreacesor as \"Nombre Asesor\", puestoacesor as \"Puesto Asesor\", nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\", modalidad as \"Madalidad\", fechainicio as \"Fecha Inicio\", fechatermi as \"Fecha Termino\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss; ", conn);
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad Modalidad,creditosAprovados as \"Creditos aprovados\" , localidad as \"localidad\",calle as \"calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre Titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre Acesor\" , puestoacesor as \"Puesto acesor\",correoAcesor  as \"Correo acesor\", nombreProyecto as \"Nombre Proyecto\",recidenciaTec as \"Recidencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();




                }
                catch (Exception ex)
                {
                    txtNumerocontrol.Text = ex.Message;
                }

            }
        }

        public void busquedaIndividual()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    //da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido Paterno\",apellidom as \"Apellido Materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\",calle as \"Calle\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\", nombretitular as \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\", nombreacesor as \"Nombre Asesor\", puestoacesor as \"Puesto Asesor\", nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\", modalidad as \"Madalidad\", fechainicio as \"Fecha Inicio\", fechatermi as \"Fecha Termino\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtNumerocontrol.Text + "'; ", conn);
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad Modalidad,creditosAprovados as \"Creditos aprovados\" , localidad as \"localidad\",calle as \"calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre Titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre Acesor\" , puestoacesor as \"Puesto acesor\",correoAcesor  as \"Correo acesor\", nombreProyecto as \"Nombre Proyecto\",recidenciaTec as \"Recidencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtNumerocontrol.Text + "'; ", conn);

                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();




                }
                catch (Exception ex)
                {

                }

            }

        }
        public void eliminarRpyysReci()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarrpyssReci";
                    cmd.Parameters.Add("@idrpyss", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

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
        public void eliminarProgramaReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarProgramaReci";
                    cmd.Parameters.Add("@idPrograma", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

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
        public void eliminarAlumnoReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarAlumnoReci";
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

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
        public void eliminarInfoEscolarReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarEscolarReci";
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

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
        public void eliminarDomicilioReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarDomicilioReci";
                    cmd.Parameters.Add("@iddomicilio", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

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



        protected void BtnVerRegistros_Click(object sender, EventArgs e)
        {
            busquedaGeneral();
        }

        protected void BTN_BUSCARREGISTRO_Click(object sender, EventArgs e)
        {
            busquedaIndividual();
        }

        protected void BTN_Eliminar_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            eliminarRpyysReci();
                            eliminarProgramaReci();
                            eliminarAlumnoReci();
                            eliminarInfoEscolarReci();
                            eliminarDomicilioReci();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Dato Eliminado!')", true);
                            txtNumerocontrol.Text = "";
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }
            }
        }

        protected void BTNeditar_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Response.Redirect("EditarResidencia.aspx?parametro=" + txtNumerocontrol.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }
            }
        }



        protected void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Session["userResidencia"] = txtNumerocontrol.Text;
                            Response.Redirect("ExportarReportesReci.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Session["userResidencia"] = txtNumerocontrol.Text;
                            Response.Redirect("UsuarioResidencia.aspx?parametro=" + txtNumerocontrol.Text);
                            

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }
            }
        }

        protected void BtnServicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }

        protected void BtnResidencia_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaRecidencia.aspx");
        }

        protected void BtnPermisos_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaPermisos.aspx");
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Session.Remove("userAdmin");
            Response.Redirect("index.aspx");
        }
    }
}