using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Repository;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using OrderMicroservice.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private readonly IOrderRepositoryAsync orderRepo;
        private readonly IMapper mapper;
        private readonly IOrder_DetailsRepositoryAsync orderDetailsRepo;

        public OrderServiceAsync(IOrderRepositoryAsync orderRepo, IOrder_DetailsRepositoryAsync orderDetailsRepo, IMapper mapper)
        {
            this.orderRepo = orderRepo;
            this.mapper = mapper;
            this.orderDetailsRepo = orderDetailsRepo;
        }
        public async Task<int> CancelOrder(int id)
        {
            return await  orderRepo.CancelOrder(id);
        }

        public async Task<IEnumerable<OrderResponseModel>> CheckOrderHistory(int customerId)
        {
            return mapper.Map<IEnumerable<OrderResponseModel>>( await orderRepo.CheckOrderHistory(customerId));
        }

        public async Task<string> CheckOrderStatus(int id)
        {
            return await orderRepo.CheckOrderStatus(id);
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            return mapper.Map<IEnumerable<OrderResponseModel>>( await orderRepo.GetAllAsync());
        }

        public async Task<int> OrderCompleted(int id)
        {

            return await orderRepo.OrderCompleted(id);
        }

        public async Task<int> SaveOrder(OrderRequestModel order)
        {
            order.Order_Status = "Order_Recieved_Inprogress";
            return await orderRepo.InsertAsync(mapper.Map<Order>(order));
        }

        public async Task<int> UpdateOrder(OrderRequestModel order, int id)
        {
            if(order.Id == id)
            {
                return await orderRepo.UpdateAsync(mapper.Map<Order>( order));
            }
            return 0;
        }

    //OrderDetails
        public async Task<IEnumerable<Order_DetailsResponseModel>> GetDetailsByOrderId(int id)
        {
            return mapper.Map<IEnumerable<Order_DetailsResponseModel>>(await orderDetailsRepo.GetDetailsByOrderId(id));
        }
    }
}
