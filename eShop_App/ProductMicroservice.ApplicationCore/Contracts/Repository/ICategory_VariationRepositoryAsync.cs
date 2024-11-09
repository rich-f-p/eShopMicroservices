using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Repository
{
    public interface ICategory_VariationRepositoryAsync : IRepositoryAsync<Category_Variation>
    {
        //GetCategoryVariationByCategoryId
        Task<Category_Variation> GetCategoryVariationByCategoryId(int id);
    }
}
