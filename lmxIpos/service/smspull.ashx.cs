using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using lmxIpos.BLL;
using System.Text;

namespace lmxIpos.service
{
    /// <summary>
    /// Summary description for smspull
    /// </summary>
    public class smspull : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var IN_MSG_ID = context.Request.QueryString["IN_MSG_ID"];
            var MOBILENO = context.Request.QueryString["MOBILENO"];
            var BODY = context.Request.QueryString["BODY"];
            var ORIGIN_PORT = context.Request.QueryString["ORIGIN_PORT"];
            
            gpsmsBLL bll=new gpsmsBLL();
            int count = bll.SaveInbox(IN_MSG_ID , MOBILENO, BODY, ORIGIN_PORT);


            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=" + "\"1.0\"" + " encoding=" + "\"ISO-8859-1\"?>").AppendLine();
            builder.Append("<MT>").AppendLine();
            builder.Append("<OUT_MSG_ID>1110</OUT_MSG_ID>").AppendLine();
            builder.Append("<MOBILENO> " + MOBILENO + "</MOBILENO>").AppendLine();
            builder.Append("<IN_MSG_ID>" + IN_MSG_ID + "</IN_MSG_ID>").AppendLine();
            builder.Append("<REPLY_TEXT>THIS IS A TEST</REPLY_TEXT>").AppendLine();
            builder.Append("<MSG_TYPE>4</MSG_TYPE>").AppendLine();
            builder.Append("<SEND_PORT>2000</SEND_PORT>").AppendLine();
            builder.Append("</MT>").AppendLine();
            String xml = builder.ToString();
            //xmlwritter();


            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.Write(xml);
            
            //JoyDataListBLL joydata = new JoyDataListBLL();
            //int count = joydata.saveData(Appid, Institue, Name, contact, lat, lang, location); 

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