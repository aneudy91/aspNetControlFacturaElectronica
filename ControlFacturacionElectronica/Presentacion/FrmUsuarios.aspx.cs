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
    public partial class FrmUsuarios : System.Web.UI.Page
    {
        mUsuario mUser;
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
                if ((string)Session["IDUsuarioUpdate"] != "0")
                {
                    mUser = new mUsuario(DatosComun.constr);
                    mUser.loadUsuario(Convert.ToInt32((string)Session["IDUsuarioUpdate"]));
                    txtNombre.Text = mUser.Nombre;
                    txtCuentaUsuario.Text = mUser.NombreCuenta;
                    txtClave.Text = mUser.Clave;
                    txtConfirmClave.Text = mUser.Clave;

                    if (mUser.IDEmpresa == 0)
                    {
                        RBLTipoUsuario.SelectedValue = "0";
                    }
                    else RBLTipoUsuario.SelectedValue = "1";

                    if (RBLTipoUsuario.SelectedValue == "0")
                    {
                        DDLTipoUsuario.DataSource = dc.BindGrid("select IDClienteEmpresa,NombreComercial from TblClienteEmpresa with (nolock) where Active = 1 ");
                        DDLTipoUsuario.DataTextField = "NombreComercial";
                        DDLTipoUsuario.DataValueField = "IDClienteEmpresa";
                        DDLTipoUsuario.DataBind();
                        DDLTipoUsuario.SelectedValue = mUser.IDClienteEmpresa.ToString();
                    }
                    else
                    {
                        DDLTipoUsuario.DataSource = dc.BindGrid("select IDEmpresa,NombreComercial from TblEmpresa with (nolock)");
                        DDLTipoUsuario.DataTextField = "NombreComercial";
                        DDLTipoUsuario.DataValueField = "IDEmpresa";
                        DDLTipoUsuario.DataBind();
                        DDLTipoUsuario.SelectedValue = mUser.IDEmpresa.ToString();
                    }
                }
                else
                {
                    DDLTipoUsuario.DataSource = dc.BindGrid("select IDClienteEmpresa,NombreComercial from TblClienteEmpresa with (nolock) where Active = 1 ");
                    DDLTipoUsuario.DataTextField = "NombreComercial";
                    DDLTipoUsuario.DataValueField = "IDClienteEmpresa";
                    DDLTipoUsuario.DataBind();
                }
            }
        }

        protected void BtGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if ( (txtClave.Text != txtConfirmClave.Text) || (txtClave.Text == String.Empty || txtConfirmClave.Text == String.Empty) )
            {
                LMensaje.Text = "Las contraseñas no coinciden o uno de los campos estan vacios!";
                return;
            }
            else LMensaje.Text = "...";

            if ((string)Session["IDUsuarioUpdate"] == "0")
            {
                mUser = new mUsuario(DatosComun.constr);
                mUser.Nombre = txtNombre.Text;
                mUser.NombreCuenta = txtCuentaUsuario.Text;

                // if (RBLTipoUsuario.SelecctedValue == 0)
                if (RBLTipoUsuario.SelectedValue == "0")
                {
                    mUser.IDClienteEmpresa = Convert.ToInt32(DDLTipoUsuario.SelectedValue);
                    mUser.IDEmpresa = 0;
                }
                else
                {
                    mUser.IDClienteEmpresa = 0;
                    mUser.IDEmpresa = Convert.ToInt32(DDLTipoUsuario.SelectedValue);
                }
                mUser.Clave = Utilerias.Code(txtClave.Text);

                mUser.insertUsuario();
            }
            else
            {
                mUser = new mUsuario(DatosComun.constr);
                mUser.loadUsuario(Convert.ToInt32((string)Session["IDUsuarioUpdate"]));
                mUser.Nombre = txtNombre.Text;
                mUser.NombreCuenta = txtCuentaUsuario.Text;

                // if (RBLTipoUsuario.SelecctedValue == 0)
                if (RBLTipoUsuario.SelectedValue == "0")
                {
                    mUser.IDClienteEmpresa = Convert.ToInt32(DDLTipoUsuario.SelectedValue);
                    mUser.IDEmpresa = 0;
                }
                else
                {
                    mUser.IDClienteEmpresa = 0;
                    mUser.IDEmpresa = Convert.ToInt32(DDLTipoUsuario.SelectedValue);
                }
                mUser.Clave = Utilerias.Code(txtClave.Text);

                mUser.updateUsuario();             
            }

            Response.Redirect("~/Presentacion/FrmListaUsuarios");
        }

        protected void BtCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Presentacion/FrmListaUsuarios");
        }

        protected void RBLTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBLTipoUsuario.SelectedValue == "0")
            {
                DDLTipoUsuario.DataSource = dc.BindGrid("select IDClienteEmpresa,NombreComercial from TblClienteEmpresa with (nolock) where Active = 1 ");
                DDLTipoUsuario.DataTextField = "NombreComercial";
                DDLTipoUsuario.DataValueField = "IDClienteEmpresa";
                DDLTipoUsuario.DataBind();            
            }
            else
            {
                DDLTipoUsuario.DataSource = dc.BindGrid("select IDEmpresa,NombreComercial from TblEmpresa with (nolock)");
                DDLTipoUsuario.DataTextField = "NombreComercial";
                DDLTipoUsuario.DataValueField = "IDEmpresa";
                DDLTipoUsuario.DataBind();
            }
        }
    }
}