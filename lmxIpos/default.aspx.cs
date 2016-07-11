using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lmxIpos.BLL;

namespace lmxIpos
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // LoadJoyData();
            }
            //if (productListGridView.Rows.Count > 0)
            //{
            //    productListGridView.UseAccessibleHeader = true;
            //    productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
        }

        //private void LoadJoyData()
        //{
        //    JoyDataListBLL listBll=new JoyDataListBLL();
        //    try
        //    {
        //        DataTable dt = listBll.GetJoyData();
        //        productListGridView.DataSource = dt;
        //        productListGridView.DataBind();
        //        if (productListGridView.Rows.Count > 0)
        //        {
        //            productListGridView.UseAccessibleHeader = true;
        //            productListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }

        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}
    
    }
}