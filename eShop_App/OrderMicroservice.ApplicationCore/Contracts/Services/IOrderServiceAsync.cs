using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface IOrderServiceAsync
    {
        Task<IEnumerable<OrderResponseModel>> GetAllOrders();
        Task<int> SaveOrder(OrderRequestModel order);
        Task<IEnumerable<OrderResponseModel>> CheckOrderHistory(int customerId);
        Task<string> CheckOrderStatus(int id);
        Task<int> CancelOrder(int id);
        Task<int> OrderCompleted(int id);
        Task<int> UpdateOrder(OrderRequestModel order,int id);
        Task<IEnumerable<Order_DetailsResponseModel>> GetDetailsByOrderId(int id);
        Task<OrderResponseModel> GetOrderById(int id);

    }
}
