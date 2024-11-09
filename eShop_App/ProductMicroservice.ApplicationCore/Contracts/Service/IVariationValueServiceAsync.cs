using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Service
{
    public interface IVariationValueServiceAsync
    {
        Task<int> save(Variation_ValueRequestModel model);
        Task<Variation_ValuesResponseModel> GetVariationById(int id);
    }
}
