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
    public partial class FrmEmpresas : System.Web.UI.Page
    {
        mEmpresa eEmp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] == null || (string)Session["Tipo"] == "1")
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }

            if (!IsPostBack)
            {
                if ((string)Session["IDEmpresaUpdate"] != "0")
                {
                    eEmp = new mEmpresa(DatosComun.constr, Convert.ToInt32((string)Session["IDEmpresaUpdate"]));
                    txtNombreComercial.Text = eEmp.NombreComercial;
                    txtRazonSocial.Text = eEmp.RazonSocial;
                    txtRFC.Text = eEmp.RFC;
                    txtCalle.Text = eEmp.DomicilioFiscal_calle;
                    txtNoExterior.Text = eEmp.DomicilioFiscal_noExterior;
                    txtColonia.Text = eEmp.DomicilioFiscal_colonia;
                    txtLocalidad.Text = eEmp.DomicilioFiscal_localidad;
                    txtMunicipio.Text = eEmp.DomicilioFiscal_municipio;
                    txtEstado.Text = eEmp.DomicilioFiscal_estado;
                    txtPais.Text = eEmp.DomicilioFiscal_pais;
                    txtCodigoPostal.Text = eEmp.DomicilioFiscal_codigoPostal;
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

            if (txtRazonSocial.Text == String.Empty)
            {
                LError.Text = "Ingrese una Razón Social";
                LError.Visible = true;
                return;
            }

            if (txtRFC.Text == String.Empty)
            {
                LError.Text = "Ingrese un RFC";
                LError.Visible = true;
                return;
            }


            try
            {
                if ((string)Session["IDEmpresaUpdate"] == "0")
                {
                    eEmp = new mEmpresa(DatosComun.constr);
                    eEmp.NombreComercial = txtNombreComercial.Text;
                    eEmp.RazonSocial = txtRazonSocial.Text;
                    eEmp.RFC = txtRFC.Text;
                    eEmp.DomicilioFiscal_calle = txtCalle.Text;
                    eEmp.DomicilioFiscal_noExterior = txtNoExterior.Text;
                    eEmp.DomicilioFiscal_colonia = txtColonia.Text;
                    eEmp.DomicilioFiscal_localidad = txtLocalidad.Text;
                    eEmp.DomicilioFiscal_municipio = txtMunicipio.Text;
                    eEmp.DomicilioFiscal_estado = txtEstado.Text;
                    eEmp.DomicilioFiscal_pais = txtPais.Text;
                    eEmp.DomicilioFiscal_codigoPostal = txtCodigoPostal.Text;

                    eEmp.insertEmpresa();
                }
                else
                {
                    eEmp = new mEmpresa(DatosComun.constr, Convert.ToInt32((string)Session["IDEmpresaUpdate"]));
                    eEmp.NombreComercial = txtNombreComercial.Text;
                    eEmp.RazonSocial = txtRazonSocial.Text;
                    eEmp.RFC = txtRFC.Text;
                    eEmp.DomicilioFiscal_calle = txtCalle.Text;
                    eEmp.DomicilioFiscal_noExterior = txtNoExterior.Text;
                    eEmp.DomicilioFiscal_colonia = txtColonia.Text;
                    eEmp.DomicilioFiscal_localidad = txtLocalidad.Text;
                    eEmp.DomicilioFiscal_municipio = txtMunicipio.Text;
                    eEmp.DomicilioFiscal_estado = txtEstado.Text;
                    eEmp.DomicilioFiscal_pais = txtPais.Text;
                    eEmp.DomicilioFiscal_codigoPostal = txtCodigoPostal.Text;

                    eEmp.updateEmpresa();
                }

                Response.Redirect("~/Presentacion/FrmListaEmpresas.aspx");
            }
            catch (Exception er)
            { 
            
            }
        }

        protected void BtCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Presentacion/FrmListaEmpresas");
        }
    }
}