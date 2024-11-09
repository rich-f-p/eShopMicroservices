using AutoMapper;
using PromotionsMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.ApplicationCore.Contracts.Service;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models.Request;
using PromotionsMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Services
{
    public class PromotionServiceAsync : IPromotionServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IPromotionSaleRepositoryAsync saleRepo;

        public PromotionServiceAsync(IMapper mapper, IPromotionSaleRepositoryAsync saleRepo)
        {
            this.mapper = mapper;
            this.saleRepo = saleRepo;
        }

        public async Task<int> DeletePromotionById(int id)
        {
            return await saleRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetActivePromotions()
        {
            return mapper.Map<IEnumerable<PromotionResponseModel>>( await saleRepo.GetActivePromotionsAsync());
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetAllPromotions()
        {
            return mapper.Map<IEnumerable<PromotionResponseModel>>( await saleRepo.GetAllAsync());
        }

        public async Task<PromotionResponseModel> GetPromotionById(int id)
        {
            return mapper.Map<PromotionResponseModel>(await saleRepo.GetByIdAsync(id));
        }

        public async Task<PromotionResponseModel> GetPromotionByProductName(string name)
        {
            return mapper.Map<PromotionResponseModel>(await saleRepo.PromotionByProductNameAsync(name));
        }

        public Task<int> SavePromotion(PromotionRequestModel model)
        {
            return saleRepo.InsertAsync(mapper.Map<PromotionSale>(model));
        }

        public Task<int> UpdatePromotion(PromotionRequestModel model)
        {
            return saleRepo.UpdateAsync(mapper.Map<PromotionSale>(model));
        }
    }
}
