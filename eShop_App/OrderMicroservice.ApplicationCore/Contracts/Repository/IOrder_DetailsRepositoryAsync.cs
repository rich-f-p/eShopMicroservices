using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IOrder_DetailsRepositoryAsync : IRepositoryAsync<Order_Details>
    {
        Task<IEnumerable<Order_Details>> GetDetailsByOrderId(int id);
    }
}
