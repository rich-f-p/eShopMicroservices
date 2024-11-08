using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface IAddressServiceAsync
    {
        Task<int> SaveCustomerAddress(AddressRequestModel address, int customerId);
    }
}
