using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IProductRepositoryAsync : IRepositoryAsync<Product>
    {
        Task<int> InActive(int id);
        Task<IEnumerable<Product>> GetProductByCategoryId(int id);
        Task<IEnumerable<Product>> GetProductByName(string name);

    }
}
