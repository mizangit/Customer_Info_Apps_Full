using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInformationWEB.Model
{
    public class Customer
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public decimal Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }



    }
}