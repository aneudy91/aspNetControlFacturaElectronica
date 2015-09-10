using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ControlFacturacionElectronica.Datos;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmListaEmpresas : System.Web.UI.Page
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
                GvDatosEmpresa.DataSource = dc.BindGrid("exec spBuscarEmpresa 0");
                GvDatosEmpresa.DataBind();
            }
        }

        protected void BtNuevo_Click(object sender, EventArgs e)
        {
            Session.Add("IDEmpresaUpdate", "0");
            Response.Redirect("~/Presentacion/FrmEmpresas.aspx");     
        }

        protected void GvDatosEmpresa_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session.Add("IDEmpresaUpdate", Convert.ToString(GvDatosEmpresa.DataKeys[e.NewEditIndex].Value));
            Response.Redirect("~/Presentacion/FrmEmpresas.aspx");
        }
    }
}