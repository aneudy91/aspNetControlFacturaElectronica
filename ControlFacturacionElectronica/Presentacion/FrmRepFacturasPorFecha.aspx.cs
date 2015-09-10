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

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmRepFacturasPorFecha : System.Web.UI.Page
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
            DateTime fi, ff, fft;

            if (edEjercico.Text == String.Empty)
            {
                edEjercico.Text = DateTime.Today.Year.ToString();
            }

            fi = Convert.ToDateTime("01/" + cbMesInicio.SelectedValue + "/" + edEjercico.Text);

            fft = Convert.ToDateTime("01/" + cbMesFin.SelectedValue + "/" + edEjercico.Text);

            ff = fft.AddMonths(1);
            ff = ff.AddDays(-1);

            GridViewFacturas.DataSource = dc.BindGrid("exec spBuscarFacturasPorCliente "+DDLClientes.SelectedValue+",'"+
                        fi.ToString("yyyy-MM-dd") + "','" + ff.ToString("yyyy-MM-dd")+"',1");           
            GridViewFacturas.DataBind();    
        }

        protected void GridViewFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewFacturas.SelectedRow;
            var ZipName = "Factura_" + GridViewFacturas.DataKeys[row.RowIndex].Value + ".zip";
            string path = "~/Documentos/";
           // string fXML, fPDF;
            var dt = dc.BindGrid("exec spBuscarArchivosDescargar " + GridViewFacturas.DataKeys[row.RowIndex].Value);

            using (ZipFile zip = new ZipFile())
            {
                Response.ContentType = "application/zip";
                Response.AppendHeader("content-disposition", "attachment; filename=" + ZipName);

                foreach (DataRow mrow in dt.Rows)
                {
                  string rul = (Server.MapPath(path + (string)mrow["XML"] ));

                    if (File.Exists(Server.MapPath(path + (string)mrow["XML"] )))
                    {
                        zip.AddFile(Server.MapPath(path + (string)mrow["XML"]), String.Empty);
                    }

                    /*
                    if (File.Exists(Server.MapPath(path + (string)mrow["PDF"])))
                    {
                        zip.AddFile(Server.MapPath(path + (string)mrow["PDF"]), String.Empty);
                    }
                     */
                }
                zip.Save(Response.OutputStream);
            }

        }

        protected void CalendarDesde_SelectionChanged(object sender, EventArgs e)
        {
            //
            string var = null;
        }

        protected void GridViewFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DateTime fi, ff, fft;

            if (edEjercico.Text == String.Empty)
            {
                edEjercico.Text = DateTime.Today.Year.ToString();
            }

            fi = Convert.ToDateTime("01/" + cbMesInicio.SelectedValue + "/" + edEjercico.Text);

            fft = Convert.ToDateTime("01/" + cbMesFin.SelectedValue + "/" + edEjercico.Text);

            ff = fft.AddMonths(1);
            ff = ff.AddDays(-1);

            GridViewFacturas.PageIndex = e.NewPageIndex;
            GridViewFacturas.DataSource = dc.BindGrid("exec spBuscarFacturasPorCliente " + DDLClientes.SelectedValue + ",'" +
                        fi.ToString("yyyy-MM-dd") + "','" + ff.ToString("yyyy-MM-dd") + "',1");
            GridViewFacturas.DataBind();    
        }

    }
}