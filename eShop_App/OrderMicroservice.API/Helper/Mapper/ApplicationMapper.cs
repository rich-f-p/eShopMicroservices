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

            CreateMap<Address, AddressResponseModel>().ReverseMap();
            CreateMap<Address, AddressRequestModel>().ReverseMap();

            CreateMap<Order_Details, Order_DetailsResponseModel>().ReverseMap();
            CreateMap<Order_Details, Order_DetailsRequestModel>().ReverseMap();

            CreateMap<Payment_Type,Payment_TypeResponseModel>().ReverseMap();
            CreateMap<Payment_Type,Payment_TypeRequestModel>().ReverseMap();

            CreateMap<PaymentMethod,PaymentMethodResponseModel>().ReverseMap();
            CreateMap<PaymentMethod,PaymentMethodRequestModel>().ReverseMap();

            CreateMap<Shopping_Cart_Item, Shopping_Cart_ItemResponseModel>().ReverseMap();
            CreateMap<Shopping_Cart_Item, Shopping_Cart_ItemRequestModel>().ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartResponseModel>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartRequestModel>().ReverseMap();

            CreateMap<User_Address, User_AddressResponseModel>().ReverseMap();
            CreateMap<User_Address, User_AddressRequestModel>().ReverseMap();

            CreateMap<Customer, CustomerResponseModel>().ReverseMap();


        }
    }
}
