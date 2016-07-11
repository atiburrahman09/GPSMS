using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lmxIpos.BLL;

namespace lmxIpos.UI
{
    public partial class JoyDataList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // LoadJoyData();
            }
        }

        //private void LoadJoyData()
        //{
        //    JoyDataListBLL listBll=new JoyDataListBLL();
        //    try
        //    {
        //        DataTable dt = listBll.GetJoyData();
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
    }
}