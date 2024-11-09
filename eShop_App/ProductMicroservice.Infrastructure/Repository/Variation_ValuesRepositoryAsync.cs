using ProductMicroservice.ApplicationCore.Contracts.Repository;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repository
{
    public class Variation_ValuesRepositoryAsync : BaseRepositoryAsync<Variation_Value>, IVariation_ValuesRepositoryAsync
    {
        private readonly ProductMicroserviceDbContext context;

        public Variation_ValuesRepositoryAsync(ProductMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
