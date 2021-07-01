﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class presentacionPermiso3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarReporte();
        }
        public void llenarReporte() 
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    string id = "302331219948";
                    conn.Open();
                    string cadena = "select pd.CONTADOR,nombreInstitucion,practica,alumnosProgramados,semestre,grupo,carrera,docenteResponsable,materia,objetivo,fechaVisita,horaPropuesta from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso WHERE pd.idPermisoAcademico='" + id + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        CartaPrecentacionPermisos3 reporte = new CartaPrecentacionPermisos3();
                        reporte.SetParameterValue("@CONTADOR", registro["CONTADOR"].ToString());
                        reporte.SetParameterValue("@nombreInstitucion", registro["nombreInstitucion"].ToString());
                        reporte.SetParameterValue("@practica", registro["practica"].ToString());
                        reporte.SetParameterValue("@alumnosProgramados", registro["alumnosProgramados"].ToString());
                        reporte.SetParameterValue("@semestre", registro["semestre"].ToString());
                        reporte.SetParameterValue("@grupo", registro["grupo"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@docenteResponsable", registro["docenteResponsable"].ToString());
                        reporte.SetParameterValue("@materia", registro["materia"].ToString());
                        reporte.SetParameterValue("@objetivo", registro["objetivo"].ToString());
                        reporte.SetParameterValue("@horaPropuesta", registro["horaPropuesta"].ToString());
                        reporte.SetParameterValue("@fechaVisita", registro["fechaVisita"].ToString());
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception e)
                {
                    //Mensaje.Text = e.Message;
                }
            }
        }
    }
}