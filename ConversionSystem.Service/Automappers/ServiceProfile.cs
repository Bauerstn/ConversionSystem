using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using ConversionSystem.Context.Contracts.Enums;
using ConversionSystem.Context.Contracts.Models;
using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.Models.Enums;

namespace ConversionSystem.Service.Automappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<PresentationTypes, PresentationTypesModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<Product, ProductModel>(MemberList.Destination);

            CreateMap<ProductPresentation, ProductPresentationModel>(MemberList.Destination)
                .ForMember(x => x.Product, next => next.Ignore());

            CreateMap<ReportResult, ReportResultModel>(MemberList.Destination)
                .ForMember(x => x.ProductPresentation, next => next.Ignore());
        }
    }
}
