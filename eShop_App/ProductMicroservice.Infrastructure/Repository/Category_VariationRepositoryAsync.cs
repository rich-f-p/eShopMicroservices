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
    public class Category_VariationRepositoryAsync : BaseRepositoryAsync<Category_Variation>, ICategory_VariationRepositoryAsync
    {
        private readonly ProductMicroserviceDbContext context;

        public Category_VariationRepositoryAsync(ProductMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Category_Variation> GetCategoryVariationByCategoryId(int id)
        {
            var category = await context.Category_Variations.FirstOrDefaultAsync(x => x.Category_Id == id);
            if (category == null)
            {
                throw new Exception("No category variation with match to Category Id!");
            }
            return category;
        }
    }
}
