using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using ConversionSystem.API.Models;
using ConversionSystem.API.Models.Enums;
using ConversionSystem.API.ModelsRequest.Product;
using ConversionSystem.API.ModelsRequest.ProductPresentation;
using ConversionSystem.API.ModelsRequest.ReportResult;
using ConversionSystem.Service.Contracts.Models;
using ConversionSystem.Service.Contracts.Models.Enums;
using ConversionSystem.Service.Contracts.RequestModels;

namespace ConversionSystem.API.Infrastructures
{
    /// <summary>
    /// Профиль маппера API
    /// </summary>
    public class ApiAutoMapperProfile : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApiAutoMapperProfile"/>
        /// </summary>
        public ApiAutoMapperProfile()
        {
            CreateMap<PresentationTypesModel, PresentationTypesResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<ProductModel, ProductResponse>(MemberList.Destination);
            CreateMap<CreateProductRequest, ProductRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ProductRequest, ProductRequestModel>(MemberList.Destination);

            CreateMap<ProductPresentationModel, ProductPresentationResponse>(MemberList.Destination);
            CreateMap<CreateProductPresentationRequest, ProductPresentationRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ProductPresentationRequest, ProductPresentationRequestModel>(MemberList.Destination);

            CreateMap<ReportResultModel, ReportResultResponse>(MemberList.Destination);
            CreateMap<CreateReportResultRequest, ReportResultRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ReportResultRequest, ReportResultRequestModel>(MemberList.Destination);
        }
    }
}
