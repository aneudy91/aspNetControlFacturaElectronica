using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;



namespace WSDescargarXML
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string test(string a, string b) 
        {
            return a + b;
        }

        [WebMethod]
        public byte[] DescargaXMLenZIP(string User, string Pass, string RFC, DateTime FechaInicial, DateTime FechaFinal, string TipoXML)
        {
            string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            bool Loging;
            byte[] data;
            try
            {
                data = null;
                SqlParameter[] paramLogin = new SqlParameter[2];
                paramLogin[0] = new SqlParameter("@NombreCuenta", User);
                paramLogin[1] = new SqlParameter("@Clave", Pass);
                DataTable dtLogin = SqlHelper.ExecuteDataset(conn, "spLogIn", paramLogin).Tables[0];
                if (dtLogin.Rows.Count > 0)
                {
                    Loging = true;
                }
                else
                {
                    Loging = false;
                }

                if (Loging)
                {
                    SqlParameter[] paramURL = new SqlParameter[4];
                    paramURL[0] = new SqlParameter("@RFC", RFC);
                    paramURL[1] = new SqlParameter("@FI", FechaInicial);
                    paramURL[2] = new SqlParameter("@FF", FechaFinal);
                    paramURL[3] = new SqlParameter("@Tipo", TipoXML);
                    DataTable dtURL = SqlHelper.ExecuteDataset(conn, "spBuscarFacturasPorClienteWS", paramURL).Tables[0];

                    if (dtURL.Rows.Count > 0)
                    {

                        List<string> list = new List<string>();

                        foreach (DataRow row in dtURL.Rows)
                        {
                            list.Add((string)"~/Zip/"+row["FileName"].ToString());
                        }
                            
                            
                            foreach (DataRow dr in dtURL.Rows)
                            {
                                Download(dr["File"].ToString(), dr["FileName"].ToString());
                                //CopyFile(Server.MapPath(dr["File"].ToString()),Server.MapPath("~/Zip/"+dr["FileName"].ToString()));
                            }

                            CreateZipFile(list, Server.MapPath("~/Output/Zip.zip"));
                            foreach (DataRow row in dtURL.Rows)
                            {
                               File.Delete(Server.MapPath("~/Zip/" + row["FileName"].ToString()));
                            }

                            data = GetBytesFromFile(Server.MapPath("~/Output/Zip.zip"));
                            File.Delete(Server.MapPath("~/Output/Zip.zip"));
                            
                    }
                
                    
                }
                else
                {
                    
                }
                return data;
                
            }
            catch (Exception e) 
            {
                writeException(e);
                throw e;
            }
            
        }
        public void writeException(Exception ex) 
        {
            string filePath = Server.MapPath( "~/Output/Error.txt");

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        private Exception WSListNotFoundException(int p1, string p2)
        {
            throw new NotImplementedException();
        }


        public static byte[] GetBytesFromFile(string fullFilePath)
        {
            // this method is limited to 2^32 byte files (4.2 GB)

            FileStream fs = null;
            try
            {
                fs = File.OpenRead(fullFilePath);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                return bytes;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

        }

        private void CreateZipFile(List<string> items, string destination)
        {
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            {
                // Loop through all the items
                foreach (string item in items)
                {

                    zip.AddFile(Server.MapPath(item), "");

                    // Finally save the zip file to the destination we want
                    zip.Save(destination);
                }
            }
        }

        public void CopyFile(string Ori, string Dest)
        {
            File.Copy(Ori, Dest);
        }



        private void Download(string file,string FileName)
            {                       
            try
            {                
                string uri = "ftp://" + ConfigurationManager.AppSettings["FTPServer"].ToString()  + file;
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }       
                FtpWebRequest reqFTP;                
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" +  ConfigurationManager.AppSettings["FTPServer"].ToString()  + file));                                
                reqFTP.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FTPUserName"].ToString() , ConfigurationManager.AppSettings["FTPPassword"].ToString() );                
                reqFTP.KeepAlive = false;                
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;                                
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;                 
                reqFTP.UsePassive = false;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writeStream = new FileStream(Server.MapPath("~/Zip/" + FileName), FileMode.Create);
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);               
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }                
                writeStream.Close();
                response.Close(); 
            }
            catch (WebException wEx)
            {
                writeException(wEx);
                throw wEx;
            }
            catch (Exception ex)
            {
                writeException(ex);
                throw ex;
            }
        }


    }

   
}