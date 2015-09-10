using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using ControlFacturacionElectronica.Comun;


namespace ControlFacturacionElectronica
{
    public partial class _Default : Page
    { 
        mUsuario mu;
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
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (UserName.Text != ""  && Password.Text != "")
            {       
                mu = mUsuario.logging(Datos.DatosComun.constr, UserName.Text, Comun.Utilerias.Code(Password.Text));
            
                LLoginFail.Visible = false;
                Session.RemoveAll();
                if (mu != null)
                {
                    if (mu.IDEmpresa != 0)
                    {
                        Session.Add("Tipo", "0");
                        Session.Add("Nombre", mu.Nombre);
                        Session.Add("IDUsuario",Convert.ToString( mu.IDUsuario));
                        Session.Add("IDClienteEmpresa", "0");
                        Session.Add("RFC", mu.objEmpresa.RFC);
                        Session.Add("IDClienteEmpresaUpdate", "0");
                        Session.Add("IDEmpresaUpdate", "0");
                        Session.Add("User", mu);
                        Response.Redirect("~/Presentacion/FrmHomeEmpresa.aspx");
                        // Response.Write("User");
                    }
                    else
                    {
                        Session.Add("Tipo", "1");                  
                        Session.Add("Nombre", mu.Nombre);                     
                        Session.Add("IDUsuario", Convert.ToString(mu.IDUsuario));                       
                        Session.Add("IDClienteEmpresa", Convert.ToString(mu.objClienteEmpresa.IDClienteEmpresa));                        
                        Session.Add("RFC", mu.objClienteEmpresa.RFC);                        
                        Session.Add("IDClienteEmpresaUpdate", "0");                        
                        Session.Add("IDEmpresaUpdate", "0");
                        Session.Add("User", mu);
                        Response.Redirect("~/Presentacion/FrmHomeClientes.aspx");                        
                    }
                }
                else
                {
                    LLoginFail.Text = "Usuario o Contraseña incorrecto!";
                    LLoginFail.Visible = true;
                }
            } else
            {
                LLoginFail.Text = "Complete los campos de nombre usuario y contraseña!";
                LLoginFail.Visible = true;
            }
        }
    }
}