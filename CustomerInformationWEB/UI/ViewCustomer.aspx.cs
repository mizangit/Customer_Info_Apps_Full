using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerInformationWEB.BLL;
using CustomerInformationWEB.DAL;

namespace CustomerInformationWEB.UI
{
   
    public partial class ViewCustomer : System.Web.UI.Page
    {
        CustomerManagerLayer aManagerLayer= new CustomerManagerLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

            int id = int.Parse(Request.QueryString["ID"]);

            string Photo = aManagerLayer.ViewCustomerPhoto( id);
            customerImage.ImageUrl = "data:image/png;base64," + Photo;
        }




    }
}