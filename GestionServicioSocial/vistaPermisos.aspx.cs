﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace GestionServicioSocial
{
    public partial class vistaPermisos : System.Web.UI.Page
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
        }

        protected void BtnVerRegistros_Click(object sender, EventArgs e)
        {
            busquedaGeneral();
        }

        public void busquedaGeneral()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    //da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido Paterno\",apellidom as \"Apellido Materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\", nombretitular as \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\", nombreacesor as \"Nombre Asesor\", puestoacesor as \"Puesto Asesor\", nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\", modalidad as \"Madalidad\", fechainicio as \"Fecha Inicio\", fechatermi as \"Fecha Termino\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss; ", conn);
                    da = new SqlDataAdapter("select pd.idPermisoAcademico as \"id registro\",visitaPractica as \"Visita y practica\",visitaIndustrial as \"Tipo de visita\",practica as \"Práctica\",docenteResponsable as \"Docente responsable\",numCelularDocente as \"Numero celular docente\",CorreoElectronicoDocente as \"Correo electrónico docente\",materia as \"Materia\",semestre as \"Semestre\",grupo as \"Grupo\",alumnosProgramados as \"Alumnos Programados\",especialidad as \"Especialidad\",objetivo as \"Objetivo\",practicaDescripcion as \"Descripción practica\",nombreInstitucion \"Nombre institución\",representante as \"Representante\",puestoOcargo as \"Puesto ó cargo\",direccion as \"Dirección\",municipioEstado as \"Municipio/Estado\",telefonoOrganizacion as \"Teléfono Organización\",fax as \"Fax\",email as \"Email\",paginaWeb as \"Pagina web\",fechaVisita as \"Fecha propuesta visita\",horaPropuesta as \"Hora propuesta visita\",viajeNoche as \"Viaje noche\",recomendaciones as \"Recomendaciones\" from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso; ", conn);
                    //da = new SqlDataAdapter("select contador as \"id registro\",visitaPractica as \"Visita y practica\",visitaIndustrial as \"Tipo de visita\",practica as \"Práctica\",docenteResponsable as \"Docente responsable\",numCelularDocente as \"Numero celular docente\",CorreoElectronicoDocente as \"Correo electrónico docente\",materia as \"Materia\",semestre as \"Semestre\",grupo as \"Grupo\",alumnosProgramados as \"Alumnos Programados\",especialidad as \"Especialidad\",objetivo as \"Objetivo\",practicaDescripcion as \"Descripción practica\",nombreInstitucion \"Nombre institución\",representante as \"Representante\",puestoOcargo as \"Puesto ó cargo\",direccion as \"Dirección\",municipioEstado as \"Municipio/Estado\",telefonoOrganizacion as \"Teléfono Organización\",fax as \"Fax\",email as \"Email\",paginaWeb as \"Pagina web\",fechaVisita as \"Fecha propuesta visita\",horaPropuesta as \"Hora propuesta visita\",viajeNoche as \"Viaje noche\",recomendaciones as \"Recomendaciones\" from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso; ", conn);

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

        public void eliminarDatosAcademicos()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarDatosAcademicos";
                    cmd.Parameters.Add("@idPermisoAcademico", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

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

        public void eliminarDatosEmpresa()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarDatosEmpresa";
                    cmd.Parameters.Add("@idPermiso", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

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

        protected void BTN_Eliminar_Click(object sender, EventArgs e)
        {
            eliminarDatosAcademicos();
            eliminarDatosEmpresa();
        }

        protected void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
           // Response.Redirect("ReportePermisos.aspx?parametro=" + txtNumerocontrol.Text);
            Response.Write("<script type='text/javascript'>window.open('ReportePermisos.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Server.Transfer("index.aspx");
        }

        protected void BTNeditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPermisos.aspx?parametro=" + txtNumerocontrol.Text);
        }

        protected void BTNCaraPresentacion_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CartaPrecentacionPermisos.aspx?parametro=" + txtNumerocontrol.Text);
            //Response.Write("<script type='text/javascript'>window.open('CartaPrecentacionPermisos.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");
            llenarDatosR();
            validarReporte();
        }
        public void llenarDatosR()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select visitaPractica,visitaIndustrial,practica from permisosDatosAcademicos where idPermisoAcademico = '" + txtNumerocontrol.Text + "'; ", conn);


                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView2.DataSource = dt;
                    GridView2.DataBind();


                }
                catch (Exception ex)
                {
                }

            }

        }
        public void validarReporte()
        {
            if (GridView2.Rows.Count == 0)
            {


            }
            else
            {
                foreach (GridViewRow row in GridView2.Rows)
                {

                    if (row.Cells[0].Text.Equals("VIRTUAL") || row.Cells[0].Text.Equals("PRESENCIAL"))
                    {
                        Response.Write("<script type='text/javascript'>window.open('CartaPrecentacionPermisos.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");
                        
                    }
                    else if (row.Cells[1].Text.Equals("VIRTUAL") || row.Cells[1].Text.Equals("PRESENCIAL"))
                    {
                        
                        Response.Write("<script type='text/javascript'>window.open('CartaPrecentacionPermisos2.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");

                    }
                    else if (row.Cells[2].Text.Equals("VIRTUAL") || row.Cells[2].Text.Equals("PRESENCIAL"))
                    {
                        
                        Response.Write("<script type='text/javascript'>window.open('CartaPrecentacionPermisos3.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");

                    }
                    else
                    {


                        txtNumerocontrol.Text = "Entro al else";
                        
                    }

                }
            }

        }

        protected void BTN_BUSCARREGISTRO_Click(object sender, EventArgs e)
        {
            //as \"id registro\"
        }

        protected void BtnSeervicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }

        protected void BtnRecidencia_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaRecidencia.aspx");
        }

        protected void BtnPermisos_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaPermisos.aspx");
        }

        public void cargarDatos(string ruta)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    try
                    {
                        /*var bulkCopy = new SqlBulkCopy(conn);
                        bulkCopy.*/
                        string cadenax = "BULK INSERT usuarios FROM '" + ruta + "' WITH(FIELDTERMINATOR = ';', ROWTERMINATOR = '\n')";
                        SqlCommand cmd = new SqlCommand(cadenax, conn);
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        txtNumerocontrol.Text = ex.Message;
                    }
                }

            }
        }

        protected void cargarBase_Click(object sender, EventArgs e)
        {
            string ruta1 = "";
            string ruta = "~/" + "CargaArchivos";

            //Label1.Text = ruta;
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "cargaDatosUsuario.csv")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        //ruta1 = Server.MapPath(ruta + "/" + "cargaDatos.csv");

                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        ruta1 = Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv");
                        cargarDatos(ruta1);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath(ruta));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv"));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con exito')", true);
                    ruta1 = Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv");
                    cargarDatos(ruta1);
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("userAdmin");
            Response.Redirect("index.aspx");
        }
    }
}