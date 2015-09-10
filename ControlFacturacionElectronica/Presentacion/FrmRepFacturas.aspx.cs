using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Ionic;
using Ionic.BZip2;
using Ionic.Crc;
using Ionic.Zip;
using Ionic.Zlib;
using System.Text;
using System.IO;

using ControlFacturacionElectronica.Datos;
using ControlFacturacionElectronica.Comun;
using CrystalDecisions.CrystalReports.Engine;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmRepFacturas : System.Web.UI.Page
    {
        DatosComun dc = new DatosComun();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] == null )
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }

            if (!IsPostBack)
            {
                if ((string)Session["IDClienteEmpresa"] == "0")
                {
                    DDLClientes.DataSource = dc.BindGrid("select IDClienteEmpresa,NombreComercial from TblClienteEmpresa with (nolock) where Active = 1");
                     DDLClientes.DataTextField = "NombreComercial";
                     DDLClientes.DataValueField = "IDClienteEmpresa";
                     DDLClientes.DataBind();     
                } else
                {
                    DDLClientes.DataSource = dc.BindGrid("select IDClienteEmpresa,NombreComercial from TblClienteEmpresa with (nolock) where Active = 1 and IDClienteEmpresa = " + (string)Session["IDClienteEmpresa"]);
                    DDLClientes.DataTextField = "NombreComercial";
                    DDLClientes.DataValueField = "IDClienteEmpresa";
                    DDLClientes.DataBind();
                }

                edEjercico.Text = DateTime.Today.Year.ToString();
            }

        }

        protected void BtBuscar_Click(object sender, EventArgs e)
        {

            DateTime fi, ff,fft;


            if (edEjercico.Text == String.Empty)
            {
                edEjercico.Text = DateTime.Today.Year.ToString();
            }

            fi = Convert.ToDateTime("01/" + cbMesInicio.SelectedValue + "/" + edEjercico.Text);
           
            fft = Convert.ToDateTime("01/" + cbMesFin.SelectedValue + "/" + edEjercico.Text);

            ff = fft.AddMonths(1);
            ff = ff.AddDays(-1);
            /*
            if (CalendarDesde.SelectedDate.Year == 1) 
            {
                Message.Text = "Debe seleccionar una Fecha de inicio.";
                return;
            }
            if (CalendarHasta.SelectedDate.Year == 1) 
            {
                Message.Text = "Debe seleccionar una Fecha de Fin.";
                return;
            }
               
             * */
            mFactura fac = new mFactura(DatosComun.constr);
            DataTable dt = fac.getDataReportFacturas(DatosComun.constr, Convert.ToInt32(DDLClientes.SelectedValue), fi, ff,
                   Convert.ToInt32(RBList.SelectedValue));//metodo creado en la clase factura para devolver
            string reporteLoad = "";

            if (dt.Rows.Count <= 0) 
            {
                Message.Text = "No existen datos con estos parametros.";           
                return;
            }

            switch (Convert.ToInt32(RBList.SelectedValue))
            {
                case 1:
                    reporteLoad= "~/Reports/GeneralReport.rpt";
                    break;
                case 2:
                    reporteLoad="~/Reports/EmitidosReport.rpt";
                    break;
                case 3:
                    reporteLoad="~/Reports/RecibidosReport.rpt";
                    break;
            }

            Session.Add("Data", dt);
            Session.Add("Report",reporteLoad);
            Response.Redirect("~/Presentacion/FrmReport.aspx");
            //CRViewer.ReportSource = reporte;
        }

        protected void CalendarDesde_SelectionChanged(object sender, EventArgs e)
        {
            //
            string var = null;
        }

    }
}