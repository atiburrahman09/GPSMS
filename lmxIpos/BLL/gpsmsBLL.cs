using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lmxIpos.DAL;
using Lumex.Tech;

namespace lmxIpos.BLL
{
    public class gpsmsBLL
    {
        internal int SaveInbox(string IN_MSG_ID, string MOBILENO, string BODY, string ORIGIN_PORT)
        {
            gpsmsDAL dal = new gpsmsDAL();
            int count =0;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(true);
                count = dal.SaveInbox(IN_MSG_ID, MOBILENO, BODY, ORIGIN_PORT, db);
                db.Stop();
                return count;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}