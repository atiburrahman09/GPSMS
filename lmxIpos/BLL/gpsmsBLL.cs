using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using lmxIpos.DAL;
using Lumex.Tech;

namespace lmxIpos.BLL
{
    public class gpsmsBLL
    {
        internal DataTable SaveInbox(string IN_MSG_ID, string MOBILENO, string BODY, string ORIGIN_PORT)
        {
            gpsmsDAL dal = new gpsmsDAL();
            int count =0;
            DataTable dt;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                dt = dal.SaveInbox(IN_MSG_ID, MOBILENO, BODY, ORIGIN_PORT, db);
                db.Stop();
                return dt;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal System.Data.DataTable GetSmsList()
        {
            gpsmsDAL dal = new gpsmsDAL();
            int count = 0;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                DataTable dt = dal.GetSmsList(db);
                db.Stop();
                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}