using AutoMapper;
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
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly IProduct_CategoryRepositoryAsync productCategoryRepo;
        private readonly IMapper mapper;

        public CategoryServiceAsync(IProduct_CategoryRepositoryAsync productCategoryRepo, IMapper mapper)
        {
            this.productCategoryRepo = productCategoryRepo;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await productCategoryRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product_CategoryResponseModel>> GetAllCategory()
        {
            return mapper.Map<IEnumerable<Product_CategoryResponseModel>>(await productCategoryRepo.GetAllAsync());
        }

        public async Task<Product_CategoryResponseModel> GetCategoryById(int id)
        {
            return mapper.Map<Product_CategoryResponseModel>(await productCategoryRepo.GetByIdAsync(id));
        }

        public async Task<IEnumerable<Product_CategoryResponseModel>> GetCategoryByParentCategoryId(int id)
        {
            return mapper.Map<IEnumerable<Product_CategoryResponseModel>>(await productCategoryRepo.GetCategoryByParentCategoryId(id));
        }

        public async Task<int> saveCategory(Product_CategoryRequestModel model)
        {
            return await productCategoryRepo.InsertAsync(mapper.Map<Product_Category>(model));
        }
    }
}
