using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using CustomerInformationWEB.DAL;
using CustomerInformationWEB.Model;

namespace CustomerInformationWEB.BLL
{
    public class CustomerManagerLayer
    {
        CustomerGatewayLayer aGatewayLayer = new CustomerGatewayLayer();

        internal string InsertCustomerInfo(Model.Customer aCustomer)
        {
            Customer checkCustomerId = aGatewayLayer.CheckCustomerId(aCustomer.CustomerId);
            if (checkCustomerId ==null)
            {
                int mess = aGatewayLayer.InsertCustomerInfo(aCustomer);
                if (mess > 0)
                {
                    return "Customer Information saved successfully";
                }
                else
                {
                    return "Customer information not saved";
                }
                
            }
            else
            {
                return "Customer ID already exist";
            }
                
               
                
            

        }

        internal List<Customer> showLastImage()
        {
            return aGatewayLayer.showLastImage();
        }
    }
}