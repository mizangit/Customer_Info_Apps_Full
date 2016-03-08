using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CustomerInformationWEB.Model;

namespace CustomerInformationWEB.DAL
{
    public class CustomerGatewayLayer
    {
        int affectedRow = -1;
        private string connection = ConfigurationManager.ConnectionStrings["ConnectionImageStoreDB"].ConnectionString;
        internal Customer CheckCustomerId(string customerId)
        {
            SqlConnection aConnection = new SqlConnection(connection);
            SqlCommand aCommand = new SqlCommand("Select CustomerID FROM tbl_CustomerInfo Where CustomerID='" + customerId + "'", aConnection);
            aConnection.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();

            Customer aCustomer=null;

            while (aReader.Read())
            {
                if (aCustomer == null)
                {
                    aCustomer = new Customer();
                }

                aCustomer.CustomerId = aReader["CustomerID"].ToString();

            }
            aReader.Close();
            aConnection.Close();
            return aCustomer;

        }

        internal int InsertCustomerInfo(Model.Customer aCustomer)
        {
            SqlConnection aConnection = new SqlConnection(connection);
            SqlCommand aCommand = new SqlCommand("STP_SaveCustomerInfo", aConnection);
            aCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter nameParameter = new SqlParameter("@Name",aCustomer.Name);
            aCommand.Parameters.Add(nameParameter);

            SqlParameter customerIdParameter = new SqlParameter("@CustomerID", aCustomer.CustomerId);
            aCommand.Parameters.Add(customerIdParameter);

            SqlParameter phoneParameter = new SqlParameter("@Phone", aCustomer.Phone);
            aCommand.Parameters.Add(phoneParameter);

            SqlParameter emailParameter = new SqlParameter("@Email", aCustomer.Email);
            aCommand.Parameters.Add(emailParameter);

            SqlParameter addressParameter = new SqlParameter("@Address", aCustomer.Address);
            aCommand.Parameters.Add(addressParameter);

            SqlParameter genderParameter = new SqlParameter("@Gender", aCustomer.Gender);
            aCommand.Parameters.Add(genderParameter);

            SqlParameter dobParameter = new SqlParameter("@DateOfBirth", aCustomer.DateOfBirth);
            aCommand.Parameters.Add(dobParameter);

            SqlParameter photoParameter = new SqlParameter("@Photo", aCustomer.Photo);
            aCommand.Parameters.Add(photoParameter);

            aConnection.Open();
            affectedRow = aCommand.ExecuteNonQuery();
            aConnection.Close();
            return affectedRow;


        }

        internal List<Customer> showLastImage()
        {
            SqlConnection aConnection = new SqlConnection(connection);
            SqlCommand aCommand = new SqlCommand("Select  top 1 ID,Name,CustomerID,DateOfBirth,Photo FROM tbl_CustomerInfo  ORDER  by ID DESC ", aConnection);
            aConnection.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();
            List<Customer> aCustomerList = new List<Customer>();
            while(aReader.Read())
            {
            
            
            }

        }
    }
}