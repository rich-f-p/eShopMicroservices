using AutoMapper;
using Microsoft.Identity.Client;
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
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepo;
        private readonly IMapper mapper;
        private readonly IAddressRepositoryAsync addressRepo;
        private readonly IUser_AddressRepositoryAsync userAddressRepo;

        public CustomerServiceAsync(ICustomerRepositoryAsync customerRepo, IAddressRepositoryAsync addressRepo, IUser_AddressRepositoryAsync userAddressRepo, IMapper mapper)
        {
            this.customerRepo = customerRepo;
            this.mapper = mapper;
            this.addressRepo = addressRepo;
            this.userAddressRepo = userAddressRepo;
        }
        public async Task<List<AddressResponseModel>> GetCustomerAddressByUserId(int id)
        { 
            return mapper.Map<List<AddressResponseModel>>( await customerRepo.GetCustomerAddressByUserIdAsync(id));
        }

        public async Task<int> SaveCustomerAddress(AddressRequestModel address, int customerId)
        {
            var test = mapper.Map<Address>(address);
            
            var addressId = await addressRepo.InsertAsync(test);
            var model = new User_AddressRequestModel
            {
                Customer_Id = customerId,
                Address_Id = addressId,
                IsDefaultAddress = true
            };
            return await userAddressRepo.InsertAsync(mapper.Map<User_Address>(model));
        }
    }
}
