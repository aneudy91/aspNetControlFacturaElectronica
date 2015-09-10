using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable data = Session["Data"] as DataTable;
            string report = Session["Report"] as string;
            
            var reporte = new ReportDocument();
            reporte.Load(Server.MapPath(report));
            reporte.SetDataSource(data);
            CRViewer.ReportSource = reporte;
            CRViewer.DataBind();
        }

        protected void CRViewer_Init(object sender, EventArgs e)
        {

        }

    }
}