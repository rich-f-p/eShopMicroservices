using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IProduct_Variation_ValuesRepositoryAsync : IRepositoryAsync<Product_Variation_Values>
    {
        Task<int> Save(Product_Variation_Values entity);
        Task<Product_Variation_Values> GetProductVariationById(int productId, int variationId);
    }
}
