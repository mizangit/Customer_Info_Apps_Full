using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CustomerInformationWEB.Model
{
    public class Customer
    {
        public int _Id;
        public string _Name;
        public string _CustomerId;
        public decimal _Phone;
        public string _Email;
        public string _Address;
        public string _Gender;
        public DateTime _DateOfBirth;
       


        public int  Id { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public decimal Phone 
        {
            set
            {
                if (decimal.TryParse(value.ToString(), out _Phone))
                {
                    _Phone = value;
                }
                
                
            }
            get { return _Phone; }
            
        }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }



    }
}