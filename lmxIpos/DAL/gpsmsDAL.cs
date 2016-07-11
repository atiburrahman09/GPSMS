using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace lmxIpos.DAL
{
    public class gpsmsDAL
    {
        internal int SaveInbox(string IN_MSG_ID, string MOBILENO, string BODY, string ORIGIN_PORT, Lumex.Tech.LumexDBPlayer db)
        {
            int count = 0;
            try
            {
                
                count = db.ExecuteNonQuery("Insert Into dbo.INBOX ([IN_MSG_ID],[MOBILENO],[BODY],[ORIGIN_PORT]) Values ('"+IN_MSG_ID+"','"+MOBILENO+"','"+BODY+"','"+ORIGIN_PORT+"')");
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        internal System.Data.DataTable GetSmsList(Lumex.Tech.LumexDBPlayer db)
        {
            try
            {
                DataTable dt = db.ExecuteDataTable("SELECT [SERIAL],[IN_MSG_ID],[MOBILENO],[BODY],[ORIGIN_PORT],[CREATE_DATE]FROM [lmxGPSMS].[dbo].[INBOX]");
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}