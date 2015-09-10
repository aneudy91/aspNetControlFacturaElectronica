using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmHomeClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                    
            if ((string)Session["IDUsuario"] == null)
            {
                if ((string)Session["Tipo"] != "1")
                Session.RemoveAll();
                Response.Redirect("~/Presentacion/FrmCerrarSession.aspx");
            }

        }

        protected void BtUploadFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/FrmImportarFactura.aspx");
        }

        protected void BtConsultas_Click(object sender, EventArgs e)
        {

        }
    }
}