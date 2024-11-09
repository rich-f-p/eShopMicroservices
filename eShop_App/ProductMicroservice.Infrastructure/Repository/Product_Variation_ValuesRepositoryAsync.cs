using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repository;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Response;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repository
{
    public class Product_Variation_ValuesRepositoryAsync : BaseRepositoryAsync<Product_Variation_Values>, IProduct_Variation_ValuesRepositoryAsync
    {
        private readonly ProductMicroserviceDbContext context;

        public Product_Variation_ValuesRepositoryAsync(ProductMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> Save(Product_Variation_Values entity)
        {
            await context.Set<Product_Variation_Values>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<Product_Variation_Values> GetProductVariationById(int productId,int variationId)
        {
            //var result = await context.product_Variation_Values.FirstOrDefaultAsync(x => x.Product_Id == productId && x.Variation_Value_Id==variationId);
            var result = await context.product_Variation_Values
                .FirstOrDefaultAsync(x => x.Product_Id == productId && x.Variation_Value_Id == variationId);

            if (result != null)
            {
                return result;
            }
            throw new Exception("no match");
        }
    }
}
