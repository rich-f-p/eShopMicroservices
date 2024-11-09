using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IProduct_CategoryRepositoryAsync : IRepositoryAsync<Product_Category>
    {
        Task<IEnumerable<Product_Category>> GetCategoryByParentCategoryId(int id);
    }
}
