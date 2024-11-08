//using AutoMapper;
//using OrderMicroservice.ApplicationCore.Contracts.Services;
//using OrderMicroservice.ApplicationCore.Entities;
//using OrderMicroservice.ApplicationCore.Models.Request;
//using OrderMicroservice.ApplicationCore.Models.Response;
//using OrderMicroservice.Infrastructure.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OrderMicroservice.Infrastructure.Services
//{
//    public class ShoppingCartServiceAsync : IShoppingCartServiceAsync
//    {
//        private readonly ShoppingCartRepositoryAsync shoppingCartRepo;
//        private readonly IMapper mapper;

//        public ShoppingCartServiceAsync(ShoppingCartRepositoryAsync shoppingCartRepo, IMapper mapper)
//        {
//            this.shoppingCartRepo = shoppingCartRepo;
//            this.mapper = mapper;
//        }
//        public async Task<int> DeleteShoppingCartAsync(int id)
//        {
//            return await shoppingCartRepo.DeleteAsync(id);
//        }

//        public async Task<ShoppingCartResponseModel> GetShoppingCartByCustomerIdAsync(int id)
//        {
//            return mapper.Map<ShoppingCartResponseModel>( await shoppingCartRepo.GetShoppingCartByCustomerIdAsync(id));
//        }

//        public async Task<int> SaveShoppingCartAsync(ShoppingCartRequestModel cart)
//        {
//            return await shoppingCartRepo.InsertAsync(mapper.Map<ShoppingCart>( cart));
//        }
//    }
//}
