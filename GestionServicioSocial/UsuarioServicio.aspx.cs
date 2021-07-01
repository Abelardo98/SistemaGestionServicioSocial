﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;
using System.IO;

namespace GestionServicioSocial
{
    public partial class UsuarioServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userServicio"]== null)
                {
                    Response.Redirect("index.aspx");
                }
                else 
                {
                    txtNc.Text = Session["userServicio"].ToString();
                }
            }
            llenarTabla();
            llenarDatos();
        }

        public void llenarTabla()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select alu.numerocontrol, nombre, apellidop, apellidom, carrera,semestre,periodo,nombrePrograma from infoEscolar inf join Alumno alu on inf.idescolar = alu.numerocontrol join Programa pro on alu.numerocontrol = pro.idprograma where inf.idescolar = '" + txtNc.Text + "';", conn);

                    ArrayList lista = new ArrayList();
                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                }

            }

        }

        public void llenarDatos()
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                txtNc.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
                txtnombre.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtAP.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtAM.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtCarrera.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtSemestre.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtPeriodo.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
                txtNombreProyecto.Text = HttpUtility.HtmlDecode(row.Cells[7].Text);


            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "SolicitudServicioSocial-"+NoControl+".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        solicitud.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "SolicitudServicioSocial-" + NoControl + ".pdf"));
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        solicitud.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "SolicitudServicioSocial-" + NoControl + ".pdf"));
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    solicitud.Text = "Subido con éxito";
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                solicitud.Text = "Selecciona un archivo primero";
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
        }

        protected void acusePresentacion_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload2.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        presentacion.Text = "Este archvo ya existe";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload2.SaveAs(Server.MapPath(ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + NoControl + ".pdf"));
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        presentacion.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload2.SaveAs(Server.MapPath(ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    presentacion.Text = "Subida con éxito";
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                presentacion.Text = "Selecciona un archivo primero";
            }
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
        }

        protected void cartaAceptacion_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload3.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "CartaAceptaciónServicioSocial-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        aceptacion.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload3.SaveAs(Server.MapPath(ruta + "/" + "CartaAceptaciónServicioSocial-" + NoControl + ".pdf"));
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        aceptacion.Text = "Subida con éxito";
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload3.SaveAs(Server.MapPath(ruta + "/" + "CartaAceptaciónServicioSocial-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    aceptacion.Text = "Subida con éxito";
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                aceptacion.Text = "Selecciona un archivo primero";
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }
        }

        protected void Responsiva_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload4.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "ResponsivaServicioSocial-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        responsivaxd.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload4.SaveAs(Server.MapPath(ruta + "/" + "ResponsivaServicioSocial-" + NoControl + ".pdf"));
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        responsivaxd.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload4.SaveAs(Server.MapPath(ruta + "/" + "ResponsivaServicioSocial-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    responsivaxd.Text = "Subida con éxito";
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                responsivaxd.Text = "Selecciona un archivo primero";
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }
        }

        protected void cartaCompromiso_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload7.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "CartaCompromisoServicioSocial-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        compromiso.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload7.SaveAs(Server.MapPath(ruta + "/" + "CartaCompromisoServicioSocial-" + NoControl + ".pdf"));
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        compromiso.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload7.SaveAs(Server.MapPath(ruta + "/" + "CartaCompromisoServicioSocial-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    compromiso.Text = "Subido con éxito";
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                compromiso.Text = "Selecciona un archivo primero!";
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }
        }

        protected void reporteFinal_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload5.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "ReporteFinal-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        final.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload5.SaveAs(Server.MapPath(ruta + "/" + "ReporteFinal-" + NoControl + ".pdf"));
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        final.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload5.SaveAs(Server.MapPath(ruta + "/" + "ReporteFinal-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    final.Text = "Subido con éxito";
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                final.Text = "Selecciona un archvio primero";
            }
        }

        protected void cartaLibre_Click(object sender, EventArgs e)
        {
            Response.Redirect("liberacion.aspx");

        }
        protected void consTerminacion_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload6.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "ContanciaTerminacionServicioSocial-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        terminacion.Text = "Este archivo ya existe!";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload6.SaveAs(Server.MapPath(ruta + "/" + "ContanciaTerminacionServicioSocial-" + NoControl + ".pdf"));
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        terminacion.Text = "Subido con éxito éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload6.SaveAs(Server.MapPath(ruta + "/" + "ContanciaTerminacionServicioSocial-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    terminacion.Text = "Subida con éxito";
                }
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                terminacion.Text = "Selecciona un archivo primero";
            }
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
                    SqlCommand consulta = new SqlCommand("select idPrograma,servicioTec from Programa where idPrograma = '" + txtNc.Text + "'; ", conn);


                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                }

            }

        }
        public void validarReporte()
        {
            if (GridView1.Rows.Count == 0)
            {


            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {

                    if (row.Cells[1].Text.Equals("SI"))
                    {

                        String NC = txtNc.Text;                       
                        Response.Write("<script type='text/javascript'>window.open('ReportePresentacionInterno2.aspx');</script>");


                    }
                    else if (row.Cells[1].Text.Equals("NO"))
                    {
                        String NC = txtNc.Text;                        
                        Response.Write("<script type='text/javascript'>window.open('ReportePresentacion2.aspx');</script>");
                    }
                    else
                    {




                    }

                }
            }

        }
        protected void planTrabajo_Click(object sender, EventArgs e)
        {
            //Response.Redirect("planTrabajo.aspx");
            Server.Transfer("planTrabajo.aspx");
        }
        protected void generarCarta_Click(object sender, EventArgs e)
        {
            llenarDatosR();
            validarReporte();

        }
        protected void generarSolicitud_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'>window.open('ReporteSolicitud.aspx');</script>");
        }
        protected void subirReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportesxd.aspx");
        }

        protected void BtnGenerarConstanciaTerminacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReporteConstanciaTerminacion2.aspx");
        }

        protected void descargar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
            string ruta = "~/" + nc;
            string documento = DropDownList1.SelectedItem.Value;
            if (documento.Equals("servicioSocial"))
            {
                string rutaArchivo = ruta + "/" + "SolicitudServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=SolicitudServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe documento')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("presentacion"))
            {
                string rutaArchivo = ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaPresentaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("cartaAceptación"))
            {
                string rutaArchivo = ruta + "/" + "CartaAceptaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaAceptaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe directorio')", true);
                }
            }
            else if (documento.Equals("responsiva"))
            {
                string rutaArchivo = ruta + "/" + "ResponsivaServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ResponsivaServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("compromiso"))
            {
                string rutaArchivo = ruta + "/" + "CartaCompromisoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaCompromisoServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("planTrabajo"))
            {
                string rutaArchivo = ruta + "/" + "PlanTrabajoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=PlanTrabajoServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 1"))
            {
                string rutaArchivo = ruta + "/" + "Reporte1-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte1-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 2"))
            {
                string rutaArchivo = ruta + "/" + "Reporte2-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte2-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 3"))
            {
                string rutaArchivo = ruta + "/" + "Reporte3-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte3-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 4"))
            {
                string rutaArchivo = ruta + "/" + "Reporte4-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte4-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 5"))
            {
                string rutaArchivo = ruta + "/" + "Reporte5-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte5-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Evaluaciones finales"))
            {
                string rutaArchivo = ruta + "/" + "EvaluaciónFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=EvaluaciónFinal-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("rFinal"))
            {
                string rutaArchivo = ruta + "/" + "ReporteFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ReporteFinal-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("liberacion"))
            {
                string rutaArchivo = ruta + "/" + "ContanciaLiberaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ContanciaLiberaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if(documento.Equals("Constancia de terminación"))
            {
                string rutaArchivo = ruta + "/" + "ContanciaTerminacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ContanciaTerminacionServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        descarminar.Text = "No existe archivo";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
        }

        protected void BtnCerraSesion_Click(object sender, EventArgs e)
        {
            Response.Write("<script>self.close();</script>");
        }

        protected void eliminar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
            string ruta = "~/" + nc;
            //"~/16XX00N"
            string documento = DropDownList1.SelectedItem.Value;
            if (documento.Equals("servicioSocial"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "SolicitudServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("presentacion"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("cartaAceptación"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "CartaAceptaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("responsiva"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ResponsivaServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("compromiso"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "CartaCompromisoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("planTrabajo"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "PlanTrabajoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 1"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte1-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 2"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte2-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 3"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte3-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 4"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte4-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 5"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte5-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Evaluaciones finales"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "EvaluaciónFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("rFinal"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ReporteFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("liberacion"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ContanciaLiberaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Constancia de terminación"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ContanciaTerminacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            descarminar.Text = "Archivo aun existe";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            descarminar.Text = "Archivo Eliminado";
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        descarminar.Text = "El archivo no existe";
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    descarminar.Text = "El directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else
            {
                descarminar.Text = "error";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("userServicio");
            Response.Redirect("index.aspx");
        }
    }
}