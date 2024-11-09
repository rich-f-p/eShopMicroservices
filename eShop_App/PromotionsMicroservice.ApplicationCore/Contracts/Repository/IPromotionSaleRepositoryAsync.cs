using ProductMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IPromotionSaleRepositoryAsync : IRepositoryAsync<PromotionSale>
    {
        Task<PromotionSale> PromotionByProductNameAsync(string name);
        Task<IEnumerable<PromotionSale>> GetActivePromotionsAsync();
    }
}
