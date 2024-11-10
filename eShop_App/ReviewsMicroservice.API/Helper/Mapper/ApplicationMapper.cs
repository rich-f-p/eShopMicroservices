using AutoMapper;
using ReviewsMicroservice.ApplicationCore.Entities;
using ReviewsMicroservice.ApplicationCore.Models.Request;
using ReviewsMicroservice.ApplicationCore.Models.Response;

namespace ReviewsMicroservice.API.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Customer_Review, ReviewRequestModel>().ReverseMap();
            CreateMap<Customer_Review, ReviewResponseModel>().ReverseMap();
        }
    }
}
