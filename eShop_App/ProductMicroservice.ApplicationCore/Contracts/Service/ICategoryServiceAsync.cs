using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Service
{
    public interface ICategoryServiceAsync
    {
        Task<int> saveCategory(Product_CategoryRequestModel model);
        Task<IEnumerable<Product_CategoryResponseModel>> GetAllCategory();
        Task<Product_CategoryResponseModel> GetCategoryById(int id);
        Task<int> Delete(int id);
        Task<IEnumerable<Product_CategoryResponseModel>> GetCategoryByParentCategoryId(int id);
    }
}
