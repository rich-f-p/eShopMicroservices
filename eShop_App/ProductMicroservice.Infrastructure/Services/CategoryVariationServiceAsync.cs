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
    public class CategoryVariationServiceAsync : ICategoryVariationServiceAsync
    {
        private readonly ICategory_VariationRepositoryAsync categoryVariationRepo;
        private readonly IMapper mapper;

        public CategoryVariationServiceAsync(ICategory_VariationRepositoryAsync categoryVariationRepo,IMapper mapper)
        {
            this.categoryVariationRepo = categoryVariationRepo;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await categoryVariationRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category_VariationResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<Category_VariationResponseModel>>(await categoryVariationRepo.GetAllAsync());
        }

        public async Task<Category_VariationResponseModel> GetCategoryVariationByCategoryId(int id)
        {
            return mapper.Map<Category_VariationResponseModel>(await categoryVariationRepo.GetCategoryVariationByCategoryId(id));
        }

        public async Task<Category_VariationResponseModel> GetCategoryVariationById(int id)
        {
            return mapper.Map<Category_VariationResponseModel>(await categoryVariationRepo.GetByIdAsync(id));
        }

        public async Task<int> Save(Category_VariationRequestModel model)
        {
            var test = model.Category_Id;
            return await categoryVariationRepo.InsertAsync(mapper.Map<Category_Variation>(model));
        }
    }
}
