using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.Services
{
    public interface IShippingDetailsServiceAsync
    {
        Task<IEnumerable<Shipper_DetailsResponseModel>> GetAllDetails();
        Task<int> SaveDetails(Shipper_DetailsRequestModel model);
        Task<int> UpdateDetails(Shipper_DetailsRequestModel model,int id);
        Task<Shipper_DetailsResponseModel> GetDetailsById(int id);
        Task<int> DeleteDetails(int id);
        Task<IEnumerable<Shipper_DetailsResponseModel>> GetDetailsByShipper(int id);
    }
}
