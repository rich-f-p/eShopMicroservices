using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repository;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repository
{
    public class Product_CategoryRepositoryAsync : BaseRepositoryAsync<Product_Category>, IProduct_CategoryRepositoryAsync
    {
        private readonly ProductMicroserviceDbContext context;

        public Product_CategoryRepositoryAsync(ProductMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product_Category>> GetCategoryByParentCategoryId(int id)
        {
            var result =  context.product_Categories.Where(x => x.Parent_Category_Id == id);
            return await result.ToListAsync();
        }
    }
}
