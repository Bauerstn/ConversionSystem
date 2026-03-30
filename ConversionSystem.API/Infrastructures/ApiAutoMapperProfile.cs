using AutoMapper;
using ConversionSystem.Context.Contracts.Enums;
using ConversionSystem.Service.Contracts.Models.Enums;

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
        }
    }
}
