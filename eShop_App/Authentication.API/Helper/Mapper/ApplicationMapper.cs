using Authentication.API.Models;
using AutoMapper;

namespace Authentication.API.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<AuthUser,CustomerRegisterModel>().ReverseMap();
            CreateMap<AuthUser,RegisterModel>().ReverseMap();
            CreateMap<AuthUser,LoginResponseModel>().ReverseMap();
            CreateMap<UpdateModel,AuthUser>().ReverseMap();
        }
    }
}
