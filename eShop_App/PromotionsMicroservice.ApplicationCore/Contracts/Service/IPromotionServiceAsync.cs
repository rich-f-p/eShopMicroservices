using PromotionsMicroservice.ApplicationCore.Models.Request;
using PromotionsMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Contracts.Service
{
    public interface IPromotionServiceAsync
    {
        Task<IEnumerable<PromotionResponseModel>> GetAllPromotions();
        Task<int> SavePromotion(PromotionRequestModel model);
        Task<int> UpdatePromotion(PromotionRequestModel model);
        Task<PromotionResponseModel> GetPromotionById(int id);
        Task<int> DeletePromotionById(int id);
        Task<PromotionResponseModel> GetPromotionByProductName(string name);
        Task<IEnumerable<PromotionResponseModel>> GetActivePromotions();
    }
}
