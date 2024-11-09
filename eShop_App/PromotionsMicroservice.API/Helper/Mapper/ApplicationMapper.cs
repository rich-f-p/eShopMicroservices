using AutoMapper;
using PromotionsMicroservice.API.Controllers;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models.Request;
using PromotionsMicroservice.ApplicationCore.Models.Response;

namespace PromotionsMicroservice.API.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<PromotionSale,PromotionRequestModel >().ReverseMap();
            CreateMap<PromotionSale,PromotionResponseModel >().ReverseMap();
        }
    }
}
