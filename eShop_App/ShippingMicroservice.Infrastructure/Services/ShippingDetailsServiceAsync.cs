using AutoMapper;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class ShippingDetailsServiceAsync : IShippingDetailsServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IShipping_DetailsRepositoryAsync detailsRepo;

        public ShippingDetailsServiceAsync(IMapper mapper, IShipping_DetailsRepositoryAsync detailsRepo)
        {
            this.mapper = mapper;
            this.detailsRepo = detailsRepo;
        }
        public async Task<int> DeleteDetails(int id)
        {
            return await detailsRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Shipper_DetailsResponseModel>> GetAllDetails()
        {
            return mapper.Map<IEnumerable<Shipper_DetailsResponseModel>>( await detailsRepo.GetAllAsync());
        }

        public async Task<Shipper_DetailsResponseModel> GetDetailsById(int id)
        {
            return mapper.Map<Shipper_DetailsResponseModel>(await detailsRepo.GetByIdAsync(id));
        }

        public async Task<IEnumerable<Shipper_DetailsResponseModel>> GetDetailsByShipper(int id)
        {
            return mapper.Map<IEnumerable<Shipper_DetailsResponseModel>>(await detailsRepo.GetDetailsByShipper(id));
        }

        public async Task<int> SaveDetails(Shipper_DetailsRequestModel model)
        {
            return await detailsRepo.InsertAsync(mapper.Map<Shipping_Details>(model));
        }

        public async Task<int> UpdateDetails(Shipper_DetailsRequestModel model,int id)
        {
            if (id == model.Id)
            {
                return await detailsRepo.UpdateAsync(mapper.Map<Shipping_Details>(model));
            }
            throw new Exception("please try again");
        }
    }
}
