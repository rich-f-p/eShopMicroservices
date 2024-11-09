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
    public class ProductRepositoryAsync : BaseRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly ProductMicroserviceDbContext context;

        public ProductRepositoryAsync(ProductMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(int id)
        {
            var result = await context.Products.Where(x=>x.CategoryId == id).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var result = await context.Products.Where(x=>x.Name == name).ToListAsync(); 
            return result;
        }

        public async Task<int> InActive(int id)
        {
            var result = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(result != null)
            {
                result.Description = "InActive...";
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
