using AutoMapper;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;

namespace OrderMicroservice.API.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Order,OrderResponseModel>().ReverseMap();
            CreateMap<Order, OrderRequestModel>().ReverseMap();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();

            //CreateMap<Order, OrderResponseModel>();
            //CreateMap<Address, OrderResponseModel>();


        }
    }
}
