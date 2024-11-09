using AutoMapper;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;

namespace ProductMicroservice.API.Helper.Mapper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Category_Variation,Category_VariationRequestModel>().ReverseMap();
            CreateMap<Category_Variation,Category_VariationResponseModel>().ReverseMap();

            CreateMap<Product,ProductRequestModel>().ReverseMap();
            CreateMap<Product,ProductResponseModel>().ReverseMap();

            CreateMap<Product_Category,Product_CategoryRequestModel>().ReverseMap();
            CreateMap<Product_Category,Product_CategoryResponseModel>().ReverseMap();

            CreateMap<Product_Variation_Values,Product_Variation_ValuesRequestModel>().ReverseMap();
            CreateMap<Product_Variation_Values,Product_Variation_ValuesResponseModel>().ReverseMap();

            CreateMap<Variation_Value,Variation_ValueRequestModel>().ReverseMap();
            CreateMap<Variation_Value,Variation_ValuesResponseModel>().ReverseMap();
        }
    }
}
