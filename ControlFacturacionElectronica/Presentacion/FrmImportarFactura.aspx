<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmImportarFactura.aspx.cs" Inherits="ControlFacturacionElectronica.Presentacion.FrmImportarFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <br />
          <br />
          <br />
          <br />
    <div class="row">
    <div class="row-fluid">
        <div class="span12">
            <table  class="table table-striped">
                <tr>
                    <td style="width: 479px">
                       Archivo XML <asp:FileUpload ID="FileUploaderXML" class="fileUpload btn btn-primary" text="Archivo XML" runat="server" Width="473px" AllowMultiple="True" /> 
                    </td>
<%--                    <td>
                      Archivo PDF  <asp:FileUpload ID="FileUploadPDF" class="fileUpload btn btn-primary" text="Archivo PDF" runat="server" Width="499px" />
                    </td>--%>
                </tr>
                <tr>
                    <td style="width: 479px">

                        <asp:RadioButtonList ID="RBEmitidaRecibida" CssClass="form-control" runat="server" RepeatColumns="2" Width="226px" Visible="False">
                            <asp:ListItem Selected="True" Value="0">Emita</asp:ListItem>
                            <asp:ListItem Value="1">Recibida</asp:ListItem>
                        </asp:RadioButtonList>

                    </td>
     <%--               <td>
                        <asp:Label ID="Label1" runat="server" Text="Respuesta de Validación con el SAT:"></asp:Label>
                        <br />
                        <asp:Label ID="LRespSAT" runat="server" Text="..."></asp:Label>
                    </td>--%>
                </tr>
                <tr>
                    <td style="width: 479px">
                        <asp:Button ID="BiImportarArchivo" runat="server" class="btn btn-primary btn-lg" Text="Subir archivos" OnClick="BiImportarArchivo_Click" />
                    </td>
<%--                    <td>            
                        <asp:Label ID="LMensajeValidacionCFDI" runat="server" Text="..."></asp:Label>
                        <br />
                        <asp:Label ID="LMensajeSubirPDF" runat="server" Text="..."></asp:Label>
                    </td>--%>
                </tr>
               <%-- <tr>
                    <td style="width: 479px">
                         <asp:Label ID="LMensajeValidacionCFDI" runat="server" Text="..."></asp:Label><br />
                        <asp:Label ID="LFile" runat="server" Text="..."></asp:Label>
                  
                    </td>
                </tr>--%>
            </table>
            
        </div>
       
    </div>
    </div>

    <asp:Label ID="lLog" runat="server" Text="Log de Eventos: "></asp:Label>

   
</asp:Content>
