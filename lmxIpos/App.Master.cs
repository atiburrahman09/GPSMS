using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Tech;

using System.Data;
using System.Web.Services;

namespace lmxIpos
{
    public partial class App : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //string ActiveUser = (string)LumexSessionManager.Get("ActiveUserId");

                ////  lblloginby.Text = ActiveUserName;

                //if (string.IsNullOrEmpty((string)LumexSessionManager.Get("ActiveUserId")))
                //{
                //    LumexSessionManager.RemoveAll();
                //    Response.Redirect("~/Login.aspx");
                //}
                //else
                //{
                //    lbluserName.Text = (string)LumexSessionManager.Get("ActiveUserName");
                //    lblUserDasignation.Text = (string)LumexSessionManager.Get("UserDasignation");
                  


                //}
            }

        }

        
        DataTable usermenu;




    }

}