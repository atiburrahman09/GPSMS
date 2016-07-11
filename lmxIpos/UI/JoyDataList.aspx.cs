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
                GetSmsList();
            }
        }

        private void GetSmsList()
        {
            gpsmsBLL bll=new gpsmsBLL();
            try
            {
                DataTable dt = bll.GetSmsList();
                smsListGridView.DataSource = dt;
                smsListGridView.DataBind();

                if (smsListGridView.Rows.Count > 0)
                {
                    smsListGridView.UseAccessibleHeader = true;
                    smsListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "SMS List Data Not Found!!!"; msgDetailLabel.Text = "";
                    msgbox.Attributes.Add("class", "alert alert-warning");
                }
            }
            catch (Exception)
            {
                
                throw;
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