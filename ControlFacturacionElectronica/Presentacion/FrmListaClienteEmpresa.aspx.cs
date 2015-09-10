using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using ControlFacturacionElectronica.Datos;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmListaClienteEmpresa : System.Web.UI.Page
    {
        DatosComun dc = new DatosComun();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] == null || (string)Session["Tipo"] == "1")
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }

            if (!IsPostBack)
            {
                GvDatosClienteEmpresa.DataSource = dc.BindGrid("exec spBuscarClienteEmpresa 0");
                GvDatosClienteEmpresa.DataBind();
            }
        }

        protected void GvDatosClienteEmpresa_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session.Add("IDClienteEmpresaUpdate", Convert.ToString(GvDatosClienteEmpresa.DataKeys[e.NewEditIndex].Value));
            Response.Redirect("~/Presentacion/FrmClienteEmpresa.aspx");
        }

        protected void BtNuevo_Click(object sender, EventArgs e)
        {
            Session.Add("IDClienteEmpresaUpdate", "0");
            Response.Redirect("~/Presentacion/FrmClienteEmpresa.aspx");
        }

        protected void GvDatosClienteEmpresa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("IDClienteEmpresaDelete", Convert.ToString(GvDatosClienteEmpresa.DataKeys[e.RowIndex].Value));
            Response.Redirect("~/Presentacion/FrmConfirmDeleteClienteEmpresa.aspx");
        }
    }
}