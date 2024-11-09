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
    public class Promotion_DetailsRepositoryAsync : BaseRepositoryAsync<Promotion_Details>, IPromotion_DetailsRepositoryAsync
    {
        public Promotion_DetailsRepositoryAsync(PromotionMicroserviceDbContext context) : base(context)
        {
        }
    }
}
