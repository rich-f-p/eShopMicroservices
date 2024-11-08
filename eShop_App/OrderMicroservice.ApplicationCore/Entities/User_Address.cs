using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class User_Address
    {
        public int Id { get; set; }
        //FK
        public int Customer_Id { get; set; }
        //FK
        public int Address_Id { get; set; }
        public bool IsDefaultAddress { get; set; }

        public Customer? Customer { get; set; }
        public Address? Address { get; set; }

    }
}
