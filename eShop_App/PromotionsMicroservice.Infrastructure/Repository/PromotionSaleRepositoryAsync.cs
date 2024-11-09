using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Repository
{
    public class PromotionSaleRepositoryAsync : BaseRepositoryAsync<PromotionSale>, IPromotionSaleRepositoryAsync
    {
        private readonly PromotionMicroserviceDbContext context;

        public PromotionSaleRepositoryAsync(PromotionMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PromotionSale>> GetActivePromotionsAsync()
        {
            DateTime today = DateTime.Now;
            return context.Promotion.Where(x => DateTime.Parse(x.Start_Date) < today && today < DateTime.Parse(x.End_Date));
        }

        public async Task<PromotionSale> PromotionByProductNameAsync(string name)
        {
            var result = await context.Promotion.FirstOrDefaultAsync(x => x.Name == name);
            if (result != null)
            {
                return result;
            }
            throw new Exception("no match");
        }
    }
}
