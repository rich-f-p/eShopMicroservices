using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface ICustomerServiceAsync
    {
        Task<CustomerResponseModel> GetCustomerAddressByUserId(int id);
    }
}
