using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Order>
    {
        Task<IEnumerable<Order>> CheckOrderHistory(int customerId);
        Task<string> CheckOrderStatus(int id);
        Task<int> CancelOrder(int id);
        Task<int> OrderCompleted(int id);
    }
}
