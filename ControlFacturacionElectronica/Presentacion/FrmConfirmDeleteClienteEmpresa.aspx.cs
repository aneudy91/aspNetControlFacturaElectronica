using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ControlFacturacionElectronica.Comun;
using ControlFacturacionElectronica.Datos;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmConfirmDeleteClienteEmpresa : System.Web.UI.Page
    {
        mClienteEmpresa cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] == null || (string)Session["Tipo"] == "1")
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }

            if (!IsPostBack)
            {
                cliente = new mClienteEmpresa(DatosComun.constr, Convert.ToInt32((string)Session["IDClienteEmpresaDelete"]));
                LRazonSocial.Text = cliente.RazonSocial;
                LRfc.Text = cliente.RFC;
                LNombreComercial.Text = cliente.NombreComercial;
                LContacto.Text = cliente.NombreContacto;
            }
        }

        protected void BtEliminar_Click(object sender, EventArgs e)
        {
            cliente = new mClienteEmpresa(DatosComun.constr, Convert.ToInt32((string)Session["IDClienteEmpresaDelete"]));
            cliente.DeleteClienteEmpresa();
            Response.Redirect("~/Presentacion/FrmListaClienteEmpresa.aspx");
        }
    }
}