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
    public class ShipperServicesAsync : IShipperServicesAsync
    {
        private readonly IMapper mapper;
        private readonly IShipperRepositoryAsync shipperRepo;

        public ShipperServicesAsync(IMapper mapper, IShipperRepositoryAsync shipperRepo)
        {
            this.mapper = mapper;
            this.shipperRepo = shipperRepo;
        }
        public async Task<int> DeleteShipper(int id)
        {
            return await shipperRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetAllShipppers()
        {
            return mapper.Map<IEnumerable<ShipperResponseModel>>(await shipperRepo.GetAllAsync());
        }

        public async Task<ShipperResponseModel> GetShipperById(int id)
        {
            return mapper.Map<ShipperResponseModel>(await shipperRepo.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetShippersByRegion(string region)
        {
            return mapper.Map<IEnumerable<ShipperResponseModel>>(await shipperRepo.GetShippersByRegion(region));
        }

        public Task<int> SaveShipper(ShipperRequestModel model)
        {
            return shipperRepo.InsertAsync(mapper.Map<Shipper>(model));
        }

        public Task<int> UpdateShippper(ShipperRequestModel model, int id)
        {
            if(model.Id == id)
            {
                return shipperRepo.UpdateAsync(mapper.Map<Shipper>(model));
            }
            throw new Exception("invalid Id, try again.");
        }
    }
}
