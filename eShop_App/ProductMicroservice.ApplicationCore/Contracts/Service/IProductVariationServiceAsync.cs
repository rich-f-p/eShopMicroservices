using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Service
{
    public interface IProductVariationServiceAsync
    {
        Task<int> Save(Product_Variation_ValuesRequestModel model);
        Task<Product_Variation_ValuesResponseModel> GetProductVariationById(int productId, int variationId);
    }
}
