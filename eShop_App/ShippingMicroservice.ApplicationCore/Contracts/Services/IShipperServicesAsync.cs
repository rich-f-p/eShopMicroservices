using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.Services
{
    public interface IShipperServicesAsync
    {
        Task<IEnumerable<ShipperResponseModel>> GetAllShipppers();
        Task<int> SaveShipper(ShipperRequestModel model);
        Task<int> UpdateShippper(ShipperRequestModel model, int id);
        Task<ShipperResponseModel> GetShipperById(int id);
        Task<int> DeleteShipper(int id);
        Task<IEnumerable<ShipperResponseModel>> GetShippersByRegion(string region);
    }
}
