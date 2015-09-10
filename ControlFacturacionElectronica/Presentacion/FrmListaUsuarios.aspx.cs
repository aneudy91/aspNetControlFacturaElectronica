using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ControlFacturacionElectronica.Datos;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmListaUsuarios : System.Web.UI.Page
    {
        DatosComun dc = new DatosComun();
        Comun.mUsuario user = new Comun.mUsuario(DatosComun.constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["IDUsuario"] == null || (string)Session["Tipo"] == "1")
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }

            if (!IsPostBack)
            {
                GvDatosUsuario.DataSource = dc.BindGrid("exec spBuscarUsuarios 0");
                GvDatosUsuario.DataBind();
            }
        }

        protected void GvDatosUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session.Add("IDUsuarioUpdate", Convert.ToString(GvDatosUsuario.DataKeys[e.NewEditIndex].Value));
            Response.Redirect("~/Presentacion/FrmUsuarios.aspx");
        }

        protected void BtNuevo_Click(object sender, EventArgs e)
        {
            Session.Add("IDUsuarioUpdate", "0");
            Response.Redirect("~/Presentacion/FrmUsuarios.aspx");
        }

        protected void GvDatosUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            int ID = (int) GvDatosUsuario.DataKeys[e.RowIndex].Value;
            user.DeleteUser(ID);
            Response.Redirect("~/Presentacion/FrmListaUsuarios.aspx");
            
   
        }

        protected void GvDatosUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            user.IDUsuario = Convert.ToInt32(Session["IDUsuario"].ToString());


            foreach (Control control in e.Row.Cells[0].Controls) 
            {
                LinkButton deleteButton = control as LinkButton;
                if (deleteButton != null && deleteButton.Text == "Delete") 
                {
                    if (user.getAdminUserValidate())
                    {
                        deleteButton.OnClientClick = "if (!confirm('Esta seguro que deseas borrar este usuario?')) return false;"; 
                        
                    }
                    else 
                    {
                        deleteButton.OnClientClick = "alert('Usted no tiene suficientes permisos para realizar esta acción.'); return false"; 
                    }


                    
                }
            }
        }
    }
}