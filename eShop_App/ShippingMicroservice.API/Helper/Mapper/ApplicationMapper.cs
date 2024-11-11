using AutoMapper;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;

namespace ShippingMicroservice.API.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Shipper, ShipperRequestModel>().ReverseMap();
            CreateMap<Shipper, ShipperResponseModel>().ReverseMap();

            CreateMap<Shipping_Details, Shipper_DetailsRequestModel>().ReverseMap();
            CreateMap<Shipping_Details, Shipper_DetailsResponseModel>().ReverseMap();
        }
    }
}
