<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmUsuarios.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
     <br />
     <br />
     <br />
        <h1>Mantenimiento de Usuario</h1>
    <table  class="table table-striped">
            <tr>
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Nombre: </td>
                <td><asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td>

                
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Cuenta de Usuario: </td>
                <td><asp:TextBox ID="txtCuentaUsuario"  CssClass="form-control" runat="server" Width="251px"></asp:TextBox></td> 
               
            </tr>
        <tr>
              <td style="font-weight: bold; color: rgb(119, 119, 119);">Contraseña: </td>
                <td><asp:TextBox ID="txtClave" CssClass="form-control" runat="server" TextMode="Password" Width="251px"></asp:TextBox></td>
             

                
                <td style="font-weight: bold; color: rgb(119, 119, 119);">Confirma su Contraseña: </td>
                <td><asp:TextBox ID="txtConfirmClave"  CssClass="form-control" TextMode="Password" runat="server" Width="251px"></asp:TextBox></td> 
               
        </tr>
        <tr>
            <td>
            <asp:RadioButtonList ID="RBLTipoUsuario" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RBLTipoUsuario_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">Usuario Cliente</asp:ListItem>
                <asp:ListItem Value="1">Usuario Empresa</asp:ListItem>
            </asp:RadioButtonList>
           </td>
            <td>
                <br />
                <asp:DropDownList ID="DDLTipoUsuario" CssClass="form-control" runat="server" Height="49px" Width="277px"></asp:DropDownList>
            </td>
        
        </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="BtGuardar" ImageUrl="~/Img/Guardar.png" runat="server" OnClick="BtGuardar_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="BtCancelar"  ImageUrl="~/Img/Cancelar.png"  runat="server" OnClick="BtCancelar_Click" />
                </td>
            </tr>
    </table>
    <h1>
        <asp:Label ID="LMensaje" runat="server" Text="..."></asp:Label>
    </h1> 
</asp:Content>
