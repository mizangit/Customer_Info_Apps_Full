using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CustomerInformationWEB.Model;
using CustomerInformationWEB.BLL;
using CustomerInformationWEB.UI;
using Microsoft.SqlServer.Server;

namespace CustomerInformationWEB.UI
{
    public partial class CustomerInfoForm : System.Web.UI.Page
    {

        CustomerManagerLayer aManagerLayer = new CustomerManagerLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload:
            if (!IsPostBack)
            {
                CalendarDOB.Visible = false;
               // ShowLastImage();
            }
           

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (validdata())
            {
                SaveData();
            }
           



        }


        private byte[] Photo()
        {
            if (photoFileUpload.HasFile)
            {

                HttpPostedFile aPostedFile = photoFileUpload.PostedFile;
                string imageName = Path.GetFileName(aPostedFile.FileName.ToLower());
                string format = Path.GetExtension(imageName);

                if (format == ".jpg" || format == ".png" || format == "bmp" || format == "gif")
                {
                    Stream aStream = aPostedFile.InputStream;
                    BinaryReader aBinaryReader = new BinaryReader(aStream);
                    byte[] photoBytes = aBinaryReader.ReadBytes((int)aStream.Length);
                    return photoBytes;

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Invalid Image Format')", true);
                    return null;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Image not select')", true);
                return null;
            }



        }

        public bool validdata()
        {
            bool value = true;
            decimal phone;
            DateTime date;
            string email = emailTextBox.Text;
            if (phoneTextBox.Text != String.Empty)
            {
                if (!decimal.TryParse(phoneTextBox.Text, out phone))
                 {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Invalid phone Number')", true);
                value = false;
       
                 } 
            }
           
           
             if (!DateTime.TryParse(dobTextBox.Text, out  date))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Date is wrong')", true);
                value = false;
                 
            }
             if (string.IsNullOrWhiteSpace(email))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Email field is empty.')", true);
                value = false; 
            }
            else if (email.IndexOf("@")==-1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(' @ is missing.')", true);
                value = false; 
            }
            else if (email.IndexOf(".com", System.StringComparison.Ordinal) == -1 && email.IndexOf(".net", System.StringComparison.Ordinal) == -1 && email.IndexOf(".org", System.StringComparison.Ordinal) == -1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(' Domain extention is missing.')", true);
                value = false; 
            }
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Please Input name ')", true);
                value = false;
            }
            if (string.IsNullOrWhiteSpace(customreIdTextBox.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert(' Please Input Customer ID')", true);
                value = false;
            }
             return value;
            

        }

        public void SaveData()
        {
            Customer aCustomer = new Customer();

            aCustomer.Name = nameTextBox.Text;
            aCustomer.CustomerId = customreIdTextBox.Text;

            aCustomer.Phone = Phone();
            aCustomer.Email = emailTextBox.Text;
            aCustomer.Gender = genderDropDownList.SelectedValue;
            aCustomer.Address = addressTextBox.Text;
            aCustomer.DateOfBirth = DateTime.Parse(dobTextBox.Text);
            aCustomer.Photo = Photo();
            string mess = aManagerLayer.InsertCustomerInfo(aCustomer);
            if (mess == "Customer Information saved successfully")
            {
                nameTextBox.Text = string.Empty;
                customreIdTextBox.Text = string.Empty;
                photoFileUpload = null;
                phoneTextBox.Text = string.Empty;
                genderDropDownList.SelectedValue = "Select Gender";
                addressTextBox.Text = string.Empty;
                emailTextBox.Text = string.Empty;
                dobTextBox.Text = string.Empty;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('" + mess + "')", true);
        }

        private decimal Phone()
        {
            if (phoneTextBox.Text == string.Empty)
            {
                return 0;
            }
            return decimal.Parse(phoneTextBox.Text);
        }

        protected void dobTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void showCalanderButton_Click(object sender, EventArgs e)
        {
          
           
        }

        protected void CalendarDOB_SelectionChanged(object sender, EventArgs e)
        {
            dobTextBox.Text = CalendarDOB.SelectedDate.ToShortDateString();
            CalendarDOB.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //CalendarDOB.Visible = !CalendarDOB.Visible;
            if (!CalendarDOB.Visible)
            {
                CalendarDOB.Visible = true;
            }
            else
            {
                CalendarDOB.Visible = false;    
            }
            
        }


        //public void ShowLastImage()
        //{
        //    List<Customer> aCustomerList = aManagerLayer.ShowLastImage();


        //    if (aCustomerList != null)
        //    {
        //        foreach (Customer aCustomer in aCustomerList)
        //        {
        //            Panel aPanel = new Panel();

        //            ImageButton aImage = new ImageButton
        //            {

        //                ImageUrl="data:image/png;base64"+aCustomer.Photo,
        //                CssClass="viewImage",
        //                Height=100,
        //                Width=100,
        //                PostBackUrl=String.Format("~/UI/ViewCustomer.aspx?ID={0}",+aCustomer.Id)
                        
                        
        //            };
        //            Label idLabel1 = new Label
        //            {
        //                Text = aCustomer.Id.ToString(),
        //                CssClass = "viewId"
        //            };

        //            Label nameLabel1 = new Label
        //            {
        //                Text = aCustomer.Name,
        //                CssClass = "nameLabel"
        //            };
        //            Label customerIdLabel1 = new Label
        //            {
        //                Text = aCustomer.CustomerId,
        //                CssClass = "viewCustomerID"
        //            };
                    
        //            Label dobLabel = new Label
        //            {
        //                Text = aCustomer.DateOfBirth.ToShortDateString(),
        //                CssClass = "viewDOB"
        //            };
                    
        //            aPanel.Controls.Add(aImage);
               
        //            aPanel.Controls.Add(new Literal { Text = "<br/>" });
        //            aPanel.Controls.Add(idLabel1);
        //            aPanel.Controls.Add(new Literal { Text = "<br/>" });
        //            aPanel.Controls.Add(nameLabel1);
        //            aPanel.Controls.Add(new Literal { Text = "<br/>" });
        //            aPanel.Controls.Add(customerIdLabel1);
        //            aPanel.Controls.Add(new Literal { Text = "<br/>" });
        //            aPanel.Controls.Add(dobLabel);
                   
        //            Panel1.Controls.Add(aPanel);

        //            //idLabel.Text = aCustomer.Id.ToString();
        //            //nameLabel.Text = aCustomer.Name;
        //            //customreIdTextBox.Text = aCustomer.CustomerId;
        //            //DateOfBirthLabel.Text = aCustomer.DateOfBirth.ToShortDateString();
        //            //Image1.ImageUrl = "data:image/png;base64," + aCustomer.Photo;

        //        }
        //    }
        //    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alerm('Image not available')", true);

        //    //GridView1.DataSource = aCustomerList;
        //    //GridView1.DataBind();

        //}

        protected void viewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/CustomerList.aspx");
        }

        protected void reportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/ReportPage.aspx");
        }

        protected void crystallReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/CrystallReportPage.aspx");
        }
    }
}