using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models.Request;
using AutoMapper;

namespace Authentication.API.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User,CustomerRegisterModel>().ReverseMap();
            CreateMap<User,RegisterModel>().ReverseMap();
            CreateMap<User,UpdateModel>().ReverseMap();
        }
    }
}
