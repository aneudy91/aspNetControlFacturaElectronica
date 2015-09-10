using ControlFacturacionElectronica.Comun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ControlFacturacionElectronica.Presentacion
{
    public partial class FrmImportarFactura : System.Web.UI.Page
    { 
        mFactura fac;
        mUsuario mUser ;
        string tipoComprobante = null;
      //  string pathGeneral = "";
        public string DefaultFileName = "Upload/"; //---- is the folder where files are uploaded to
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( (string)Session["IDUsuario"] == null ||  (string)Session["IDClienteEmpresa"] == "0"  )
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }

          
            mUser = Session["User"] as mUsuario;
        
            fac = new mFactura(Datos.DatosComun.constr);
        }

        protected void BiImportarArchivo_Click(object sender, EventArgs e)
        {
            string appPath = Request.PhysicalApplicationPath;
            var pathTemp = Server.MapPath("~/Documentos/Temp");
            var pathMove = Server.MapPath("~/Documentos/Move");
            string fileXML,fileMove;
                 //filePDF, dirPDF
            DirectoryInfo dirXML;
            Boolean insertFac = true;
            int errorCount, correctosCount,totalArchivos, tipoFactura;


            errorCount = 0;
            correctosCount = 0;
            totalArchivos = 0;
            tipoFactura = 0;

            lLog.Text = "Log de Eventos: ";

            //if (RBEmitidaRecibida.SelectedValue == "0")
            //    TipoFactura = "EMITIDAS";
            //else TipoFactura = "RECIBIDA";

            //LFile.Text = "...";

            if ((FileUploaderXML.HasFile))
            {
                foreach (HttpPostedFile postedFile in FileUploaderXML.PostedFiles)
                {
                    insertFac = true;
               
                    fac = new mFactura(Datos.DatosComun.constr);
                    try
                    {
                        fileXML = "";
                        fileXML = Path.Combine(pathTemp, Path.GetFileName(postedFile.FileName));
                        fileMove = "";
                        fileMove = Path.Combine(pathMove, Path.GetFileName(postedFile.FileName));
                        postedFile.SaveAs(fileXML);
                        postedFile.SaveAs(fileMove);
                    
                        string text;// = File.ReadAllText(fileXML);                      
                        StringBuilder sb = new StringBuilder();
                        using (StreamReader sr = new StreamReader(fileMove))
                        {
                            String line;
                            // Read and display lines from the file until the end of 
                            // the file is reached.
                            while ((line = sr.ReadLine()) != null)
                            {
                                sb.AppendLine(line);
                            }
                        }

                        text = sb.ToString();
                        DataTable dt = null;
                        dt = fac.extracXMLtoDatatable(fileXML, text);
                        fac.importDataTableToObj(fac.GetInversedDataTable(dt, "Nodo_Atributo", null));


                        if (fac.Emisor_rfc == mUser.objClienteEmpresa.RFC)
                        {
                            tipoComprobante = "egreso";
                            tipoFactura = 1;
                        } else
                            if (fac.Receptor_RFC == mUser.objClienteEmpresa.RFC)
                            {
                                tipoComprobante = "ingreso";
                                tipoFactura = 0;
                            }
                            else
                            {
                                lLog.Text = lLog.Text + "<br/>" + "Esta factura no pertenece a este cliente: RFC del Cliente <b>" + mUser.objClienteEmpresa.RFC +
                                     "</b> RFC EMISOR: <b>" + fac.Emisor_rfc + "</b> RFC Receptor: <b>" + fac.Receptor_RFC + "</b>";
                                insertFac = false;
                            }

                        if ( insertFac ) 
                        {
                            
                            /*
                             * try
                            {
                                fac.ValidaCFDI();
                                LRespSAT.Text = fac.oacuse.Estado;
                            }
                            catch (Exception vCFDI)
                            {
                                LMensajeValidacionCFDI.Text = "Ocurrió un error a validar factura en el SAT.<br/>" + vCFDI.Message;
                            }
                            */

                            string fecha = fac.Comprobante_fecha;
                            string pathXML = Server.MapPath("/Documentos/" + fac.Emisor_rfc + "/" + fecha.Substring(0, 4) + "/" + fecha.Substring(5, 2) + "/XML/" + tipoComprobante);

                            dirXML = new DirectoryInfo(pathXML);
                            if (dirXML.Exists == false)
                            {
                                dirXML.Create();
                            }

                            fac.TipoFactura = tipoFactura;
                            //fac.TipoFactura = Convert.ToInt32(RBEmitidaRecibida.SelectedValue);
                            fac.ArchivoXML = Path.GetFileName(postedFile.FileName);

                            File.Copy(fileMove, Path.Combine(pathXML, Path.GetFileName(postedFile.FileName)),true);
                            File.Delete(fileMove);
                            File.Delete(fileXML);
                            //LFile.Text += Path.GetFileName(postedFile.FileName).ToString() + ": Archivo subidos correctamente.<br/>";

                           // if (fac.insertFactura(fac, Convert.ToInt32((string)Session["IDClienteEmpresa"])) == 1)
                            if (fac.insertFactura(fac, mUser.IDClienteEmpresa) == 1)
                            {
                                //  GridView1.DataBind();
                            }
                            else
                            {
                               // LFile.Text += fac.ArchivoXML + ": Error al guardar la factura.<br/>";
                                return;
                            }

                            //if (FileUploadPDF.HasFile)
                            //{
                            //    try
                            //    {
                            //        filePDF = Path.Combine(pathTemp, FileUploadPDF.FileName);
                            //        FileUploadPDF.SaveAs(filePDF);
                            //        string pathPDF = Server.MapPath("/Documentos/" + fac.Emisor_rfc + "/" + fecha.Substring(0, 4) + "/" + fecha.Substring(5, 2) + "/PDF/" + TipoFactura);
                            //        dirPDF = new DirectoryInfo(pathPDF);

                            //        if (dirPDF.Exists == false)
                            //        {
                            //            dirPDF.Create();
                            //        }
                            //        File.Move(filePDF, Path.Combine(pathPDF, FileUploadPDF.FileName));
                            //    }
                            //    catch (Exception ePDF)
                            //    {
                            //        LMensajeSubirPDF.Text += "Ocurrió un error al subir archivo PDF.<br/>" + ePDF.Message;
                            //    }
                            //}

                            correctosCount++;
                           // lLog.Text = lLog.Text + " <br/> Archivo importado Correctamente: <b>" + fac.ArchivoXML +"</b>";
                        }
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        lLog.Text = lLog.Text + " <br/> " + ex.Message.ToString() + " corresponde al archivo: <b>" + fac.ArchivoXML + "</b> ";
                            // "Ocurrió un error en la importación, por favor informe al administrador.";
                    }

                    totalArchivos++;

                }
            }
            else
            {
                //LFile.Text = "You have not specified a file.";
            }


          //  totalArchivos = correctosCount + errorCount;
            lLog.Text = lLog.Text + "<br/> <br/> <b> Se importaron "+correctosCount+" archivos de "+ totalArchivos + "</b>";
        }

        private object DirectoryInfo(string p)
        {
            throw new NotImplementedException();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            var path = Server.MapPath("/Documentos/2323DDEEI3/XML/2014/01");
            var directory = new DirectoryInfo(path);

            if (directory.Exists == false)
            {
                directory.Create();
            }

            var file = Path.Combine(path, FileUploaderXML.FileName);
            Response.Write("<script LANGUAGE='JavaScript' >alert('" + file + "')</script>");
            FileUploaderXML.SaveAs(file);
             */
            HttpPostedFile mifichero;
            mifichero = FileUploaderXML.PostedFile;
            string nombreArchivo = FileUploaderXML.FileName;
            string path = mifichero.FileName;

            File.Move(Server.MapPath("~/Documentos/XML/FA-A000748-EAVR8303088U0.xml"), Server.MapPath("~/Documentos/2323DDEEI3/FA-A000748-EAVR8303088U0.xml"));
          //  LFile.Text = "4 - " + mifichero.
        }
    }
}