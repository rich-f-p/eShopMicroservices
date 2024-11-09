using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductMicroservice.ApplicationCore.Contracts.Repository;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Services
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IProductRepositoryAsync productRepo;

        public ProductServiceAsync(IMapper mapper, IProductRepositoryAsync productRepo)
        {
            this.mapper = mapper;
            this.productRepo = productRepo;
        }

        public async Task<int> DeleteProduct(int id)
        {
            return await productRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetListProducts()
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await productRepo.GetAllAsync());
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByCategoryId(int id)
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await productRepo.GetProductByCategoryId(id));
        }

        public async Task<ProductResponseModel> GetProductById(int id)
        {
            return mapper.Map<ProductResponseModel>(await productRepo.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByName(string name)
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await productRepo.GetProductByName(name));
        }

        public Task<int> InActive(int id)
        {
            return productRepo.InActive(id);
        }

        public async Task<int> Save(ProductRequestModel model)
        {
            return await productRepo.InsertAsync(mapper.Map<Product>(model));
        }

        public async Task<int> Update(ProductRequestModel model, int id)
        {
            if(model.Id == id)
            {
                return await productRepo.UpdateAsync(mapper.Map<Product>(model));
            }
            return 0;
        }
    }
}
