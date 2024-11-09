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
    public class VariationValueServiceAsync : IVariationValueServiceAsync
    {
        private readonly IMapper mapper;
        private readonly IVariation_ValuesRepositoryAsync variationValueRepo;

        public VariationValueServiceAsync(IMapper mapper, IVariation_ValuesRepositoryAsync variationValueRepo)
        {
            this.mapper = mapper;
            this.variationValueRepo = variationValueRepo;
        }

        public async Task<Variation_ValuesResponseModel> GetVariationById(int id)
        {
            return mapper.Map<Variation_ValuesResponseModel>(await variationValueRepo.GetByIdAsync(id));
        }

        public async Task<int> save(Variation_ValueRequestModel model)
        {
            return await variationValueRepo.InsertAsync(mapper.Map<Variation_Value>(model));
        }
    }
}
