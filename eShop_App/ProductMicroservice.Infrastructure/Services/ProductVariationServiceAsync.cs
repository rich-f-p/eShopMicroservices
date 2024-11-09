using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repository;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Services
{
    public class ProductVariationServiceAsync : IProductVariationServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IProduct_Variation_ValuesRepositoryAsync productVariationValuesRepo;

        public ProductVariationServiceAsync(IMapper mapper,IProduct_Variation_ValuesRepositoryAsync productVariationValuesRepo)
        {
            this.mapper = mapper;
            this.productVariationValuesRepo = productVariationValuesRepo;
        }

        public async Task<Product_Variation_ValuesResponseModel> GetProductVariationById(int productId,int variationId)
        {
            return mapper.Map<Product_Variation_ValuesResponseModel>(await productVariationValuesRepo.GetProductVariationById(productId,variationId));
        }

        public async Task<int> Save(Product_Variation_ValuesRequestModel model)
        {
            var result = mapper.Map<Product_Variation_Values>(model);
            return await productVariationValuesRepo.Save(result);
        }
    }
}
