using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Request
{
    public class User_AddressRequestModel
    {
        public int Id { get; set; }
        //FK
        public int Customer_Id { get; set; }
        //FK
        public int Address_Id { get; set; }
        public bool IsDefaultAddress { get; set; }

        public Customer? Customer { get; set; }
        public Address Address { get; set; }

    }
}
