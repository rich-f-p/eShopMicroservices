using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Service
{
    public interface IProductServiceAsync
    {
        Task<IEnumerable<ProductResponseModel>> GetListProducts();
        Task<ProductResponseModel> GetProductById(int id);
        Task<int> Save(ProductRequestModel model);
        Task<int> Update(ProductRequestModel model,int id);
        Task<int> InActive(int id);
        Task<IEnumerable<ProductResponseModel>> GetProductByCategoryId(int id);
        Task<IEnumerable<ProductResponseModel>> GetProductByName(string name);
        Task<int> DeleteProduct(int id);

    }
}
