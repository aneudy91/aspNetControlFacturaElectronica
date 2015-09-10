using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] != null)
            {
                if ((string)Session["Tipo"] == "0")
                {
                    Response.Redirect("~/Presentacion/FrmHomeEmpresa.aspx");
                }
                else
                    if ((string)Session["Tipo"] == "1")
                    {
                        Response.Redirect("~/Presentacion/FrmHomeClientes.aspx");
                    }
            }
            else Response.Redirect("~/Presentacion/FrmCerrarSession.aspx");
        }
    }
}