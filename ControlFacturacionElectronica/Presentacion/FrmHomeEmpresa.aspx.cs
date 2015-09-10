using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmHomeEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }

        }

        protected void BtClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/FrmListaClienteEmpresa.aspx");
   
        }

        protected void BtEmpresas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/FrmListaEmpresas.aspx");  
        }

        protected void BtUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Presentacion/FrmListaUsuarios.aspx");  
        }
    }
}