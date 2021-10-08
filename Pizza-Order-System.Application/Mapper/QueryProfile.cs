using AutoMapper;
using Pizza_Order_System.Application.Contract;
using DataModel = Pizza_Order_System.Persistence;

namespace Pizza_Order_System.Application.Mapper
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public QueryProfile()
        {
            CreateMap<DataModel.Pizza, Pizza>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<DataModel.Ingredients, Ingredients>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
