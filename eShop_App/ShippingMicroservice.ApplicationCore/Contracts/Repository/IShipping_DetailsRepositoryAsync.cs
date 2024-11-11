using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IShipping_DetailsRepositoryAsync : IRepositoryAsync<Shipping_Details>
    {
        Task<IEnumerable<Shipping_Details>> GetDetailsByShipper(int id);
    }
}
