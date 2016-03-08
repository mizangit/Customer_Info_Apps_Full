using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerInformationWEB.Model;
using CustomerInformationWEB.BLL;


namespace CustomerInformationWEB.UI
{
    public partial class CustomerList : System.Web.UI.Page
    {
        CustomerManagerLayer aManagerLayer = new CustomerManagerLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowLastImage();
        }


        public void ShowLastImage()
        {
            List<Customer> aCustomerList = aManagerLayer.ShowLastImage();


            if (aCustomerList != null)
            {
                foreach (Customer aCustomer in aCustomerList)
                {
                    Panel aPanel = new Panel();

                    ImageButton aImage = new ImageButton
                    {
                        ImageUrl = "data:image/png;base64" + aCustomer.Photo,
                        CssClass = "viewImage",
                        Height = 100,
                        Width = 100,
                        PostBackUrl = String.Format("~/UI/ViewCustomer.aspx?ID={0}", +aCustomer.Id)
                    };
                    Label idLabel1 = new Label
                    {
                        Text = aCustomer.Id.ToString(),
                        CssClass = "viewId"
                    };

                    Label nameLabel1 = new Label
                    {
                        Text = aCustomer.Name,
                        CssClass = "nameLabel"
                    };
                    Label customerIdLabel1 = new Label
                    {
                        Text = aCustomer.CustomerId,
                        CssClass = "viewCustomerID"
                    };

                    Label dobLabel = new Label
                    {
                        Text = aCustomer.DateOfBirth.ToShortDateString(),
                        CssClass = "viewDOB"
                    };

                    aPanel.Controls.Add(aImage);
                    aPanel.Controls.Add(new Literal { Text = "<br/>" });
                    aPanel.Controls.Add(idLabel1);
                    aPanel.Controls.Add(new Literal { Text = "<br/>" });
                    aPanel.Controls.Add(nameLabel1);
                    aPanel.Controls.Add(new Literal { Text = "<br/>" });
                    aPanel.Controls.Add(customerIdLabel1);
                    aPanel.Controls.Add(new Literal { Text = "<br/>" });
                    aPanel.Controls.Add(dobLabel);

                    Panel1.Controls.Add(aPanel);

                    //idLabel.Text = aCustomer.Id.ToString();
                    //nameLabel.Text = aCustomer.Name;
                    //customreIdTextBox.Text = aCustomer.CustomerId;
                    //DateOfBirthLabel.Text = aCustomer.DateOfBirth.ToShortDateString();
                    //Image1.ImageUrl = "data:image/png;base64," + aCustomer.Photo;

                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alerm('Image not available')", true);

            //GridView1.DataSource = aCustomerList;
            //GridView1.DataBind();

        }
    }
}