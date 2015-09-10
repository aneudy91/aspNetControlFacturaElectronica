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
    public partial class FrmClienteEmpresa : System.Web.UI.Page
    {
        mClienteEmpresa cEmp;
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
                DDLEmpresa.DataSource = dc.BindGrid("select IDEmpresa,NombreComercial from TblEmpresa with (nolock)");
                DDLEmpresa.DataTextField = "NombreComercial";
                DDLEmpresa.DataValueField = "IDEmpresa";
                DDLEmpresa.DataBind();

                DDLTipoPersona.DataSource = dc.BindGrid("select items as TipoPersona from dbo.split('Fisica|Moral','|')");
                DDLTipoPersona.DataTextField = "TipoPersona";
                DDLTipoPersona.DataValueField = "TipoPersona";
                DDLTipoPersona.DataBind();

                if ((string)Session["IDClienteEmpresaUpdate"] != "0")
                {
                    cEmp = new mClienteEmpresa(DatosComun.constr, Convert.ToInt32((string)Session["IDClienteEmpresaUpdate"]));
                   // DDLEmpresa.Items.FindByValue(cEmp.objEmpresa.idEmpresa.ToString());
                    DDLEmpresa.SelectedValue = cEmp.objEmpresa.idEmpresa.ToString() ;
                    txtNombreComercial.Text = cEmp.NombreComercial ;
                    txtNombreContacto.Text = cEmp.NombreContacto;
                    txtRazonSocial.Text= cEmp.RazonSocial;
                    txtRFC.Text = cEmp.RFC;
                    txtCalle.Text = cEmp.DomicilioFiscal_calle;
                    txtNoExterior.Text = cEmp.DomicilioFiscal_noExterior;
                    txtColonia.Text = cEmp.DomicilioFiscal_colonia;
                    txtLocalidad.Text = cEmp.DomicilioFiscal_localidad;
                    txtMunicipio.Text = cEmp.DomicilioFiscal_municipio;
                    txtEstado.Text = cEmp.DomicilioFiscal_estado;
                    txtPais.Text = cEmp.DomicilioFiscal_pais;
                    txtCodigoPostal.Text = cEmp.DomicilioFiscal_codigoPostal;
                    txtCorreoEletronico.Text = cEmp.CorreoEletronico;
                    txtTelefonoContacto.Text = cEmp.ContactoTelefono;
                    txtCelularContacto.Text = cEmp.ContactoCelular;
                    //DDLTipoPersona.Items.FindByText(cEmp.TipoPersona);
                    DDLTipoPersona.SelectedValue = cEmp.TipoPersona;
                }
            }
               
        }

        protected void BtGuardar_Click(object sender, ImageClickEventArgs e)
        {
            LError.Visible = false;
            
            if (txtNombreComercial.Text == String.Empty)
            {
                LError.Text = "Ingrese un Nombre Comercial";
                LError.Visible = true;
                return;
            }

            if (txtRazonSocial.Text == String.Empty) {
                LError.Text = "Ingrese una Razón Social";
                LError.Visible = true;
                return;
            }

            if (txtNombreContacto.Text == String.Empty) {
                LError.Text = "Ingrese un Nombre Contacto";
                LError.Visible = true;
                return;
            }

            if (txtRFC.Text == String.Empty) {
                LError.Text = "Ingrese un RFC";
                LError.Visible = true;
                return;
            }

            if (DDLEmpresa.SelectedValue == null){
                LError.Visible = true;
                LError.Text = "Seleccione una empresa";
                return;
            }

            try
            {
                if ((string)Session["IDClienteEmpresaUpdate"] == "0")
                {
                    cEmp = new mClienteEmpresa(Datos.DatosComun.constr);
                    cEmp.IDEmpresa = Convert.ToInt32(DDLEmpresa.SelectedValue);
                    cEmp.NombreComercial = txtNombreComercial.Text;
                    cEmp.NombreContacto = txtNombreContacto.Text;
                    cEmp.RazonSocial = txtRazonSocial.Text;
                    cEmp.RFC = txtRFC.Text;
                    cEmp.DomicilioFiscal_calle = txtCalle.Text;
                    cEmp.DomicilioFiscal_noExterior = txtNoExterior.Text;
                    cEmp.DomicilioFiscal_colonia = txtColonia.Text;
                    cEmp.DomicilioFiscal_localidad = txtLocalidad.Text;
                    cEmp.DomicilioFiscal_municipio = txtMunicipio.Text;
                    cEmp.DomicilioFiscal_estado = txtEstado.Text;
                    cEmp.DomicilioFiscal_pais = txtPais.Text;
                    cEmp.DomicilioFiscal_codigoPostal = txtCodigoPostal.Text;
                    cEmp.CorreoEletronico = txtCorreoEletronico.Text;
                    cEmp.ContactoTelefono = txtTelefonoContacto.Text;
                    cEmp.ContactoCelular = txtCelularContacto.Text;
                    cEmp.TipoPersona = DDLTipoPersona.Text;

                    cEmp.insertClienteEmpresa();
                }
                else
                {
                    cEmp = new mClienteEmpresa(DatosComun.constr, Convert.ToInt32((string)Session["IDClienteEmpresaUpdate"]));
                    cEmp.IDEmpresa = Convert.ToInt32(DDLEmpresa.SelectedValue);
                    cEmp.NombreComercial = txtNombreComercial.Text;
                    cEmp.NombreContacto = txtNombreContacto.Text;
                    cEmp.RazonSocial = txtRazonSocial.Text;
                    cEmp.RFC = txtRFC.Text;
                    cEmp.DomicilioFiscal_calle = txtCalle.Text;
                    cEmp.DomicilioFiscal_noExterior = txtNoExterior.Text;
                    cEmp.DomicilioFiscal_colonia = txtColonia.Text;
                    cEmp.DomicilioFiscal_localidad = txtLocalidad.Text;
                    cEmp.DomicilioFiscal_municipio = txtMunicipio.Text;
                    cEmp.DomicilioFiscal_estado = txtEstado.Text;
                    cEmp.DomicilioFiscal_pais = txtPais.Text;
                    cEmp.DomicilioFiscal_codigoPostal = txtCodigoPostal.Text;
                    cEmp.CorreoEletronico = txtCorreoEletronico.Text;
                    cEmp.ContactoTelefono = txtTelefonoContacto.Text;
                    cEmp.ContactoCelular = txtCelularContacto.Text;
                    cEmp.TipoPersona = DDLTipoPersona.Text;

                    cEmp.updateClienteEmpresa();
                }

                Response.Redirect("~/Presentacion/FrmListaClienteEmpresa.aspx");

            }
            catch (Exception er)
            { 
            
            }
        }

        protected void GvClientesEmpresas_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void BtCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Presentacion/FrmListaClienteEmpresa");
        }
    }
}