using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Service
{
    public interface ICategoryVariationServiceAsync
    {
        Task<int> Save(Category_VariationRequestModel model);
        Task<IEnumerable<Category_VariationResponseModel>> GetAll();
        Task<Category_VariationResponseModel> GetCategoryVariationById(int id);
        Task<Category_VariationResponseModel> GetCategoryVariationByCategoryId(int id);
        Task<int> Delete(int id);
    }
}
