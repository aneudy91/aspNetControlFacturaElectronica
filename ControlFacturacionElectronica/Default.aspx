<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlFacturacionElectronica._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Acceso al sistema</h4>     
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                     <table>
                         <tr>
                           <td style="width: 860px">
                               <asp:Label runat="server" AssociatedControlID="UserName" Height="32px">Nombre de usuario:</asp:Label>
                               <br />
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" Height="39px" Width="396px" />
            
                            </td>
                          </tr>
                         <tr>
                             <td style="width: 860px">
                                 <asp:Label runat="server" AssociatedControlID="Password" Height="31px" >Contraseña:</asp:Label>                      
                                 <br />
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Height="40px" Width="397px" />
                                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                             
                                
                                <br />
                                <asp:Label ID="LLoginFail" runat="server" Visible="false" Text="..."></asp:Label>       
                             </td>
                        </tr>

                      </table>
                        </div>
                    </div>
            </section>
        </div>
    </div>
      </div>
   <%-- <div class="row">
        <div class="col-md-4">
            <h2>Todo sobre Factura Electrónica</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Leer mas &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>

</asp:Content>
