using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace lmxIpos.service
{
    /// <summary>
    /// Summary description for smspush
    /// </summary>
    public class smspush : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //var STATUS = context.Request.QueryString["STATUS"];
            //if (STATUS=="OK")
            //{
                
            //}
            String xml = "<STATUS>OK<STATUS>";
            //xmlwritter();


            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.Write(xml);


        }

        private void xmlwritter()
        {
            string statuspath = HttpContext.Current.Server.MapPath("~");
            XmlWriter xmlWriter = XmlWriter.Create(statuspath + "status.xml");
            
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("STATUS");
            xmlWriter.WriteString("OK");
            xmlWriter.WriteEndElement();

            xmlWriter.Close();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}