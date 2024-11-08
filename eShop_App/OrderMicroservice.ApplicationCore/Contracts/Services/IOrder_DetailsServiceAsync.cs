using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface IOrder_DetailsServiceAsync
    {
        Task<IEnumerable<Order_DetailsResponseModel>> GetDetailsByOrderId(int id);
    }
}
