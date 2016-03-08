using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            if (!IsPostBack)
            {
                CalendarDOB.Visible = false;
            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Customer aCustomer = new Customer();

            aCustomer.Name = nameTextBox.Text;
            aCustomer.CustomerId = customreIdTextBox.Text;
            aCustomer.Phone = decimal.Parse(phoneTextBox.Text);
            aCustomer.Email = emailTextBox.Text;
            aCustomer.Gender = genderDropDownList.SelectedValue;
            aCustomer.Address = addressTextBox.Text;
            aCustomer.DateOfBirth = DateTime.Parse(dobTextBox.Text);
            aCustomer.Photo = Photo();
            string mess = aManagerLayer.InsertCustomerInfo(aCustomer);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('" + mess + "')", true);

            nameTextBox.Text = string.Empty;
            customreIdTextBox.Text = string.Empty;
            photoFileUpload = null;
            phoneTextBox.Text = string.Empty;
            genderDropDownList.SelectedValue = "Select Gender";
            addressTextBox.Text = string.Empty;       
            emailTextBox.Text = string.Empty;
            dobTextBox.Text = string.Empty;
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
            CalendarDOB.Visible = true;
          
            //CalendarDOB.Visible = false;
        }



        public void showLastImage()
        {
            List<Customer> aCustomerList = aManagerLayer.showLastImage();

            if(aCustomerList!=null)
            {
                foreach (Customer aCustomer in aCustomerList)
                {
                    idLabel.Text = aCustomer.Id.ToString();
                    nameLabel.Text = aCustomer.Name.ToString();
                    customreIdTextBox.Text = aCustomer.CustomerId.ToString();
                    DateOfBirthLabel.Text = aCustomer.DateOfBirth.ToShortDateString();
                }
            }
            
        }
    }
}