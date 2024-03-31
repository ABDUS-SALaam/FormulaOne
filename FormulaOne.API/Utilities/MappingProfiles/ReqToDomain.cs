using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;

namespace FormulaOne.API.Utilities.MappingProfiles
{
    public class ReqToDomain : Profile
    {
        public ReqToDomain()
        {
            CreateMap<CreateDriverAchievementsRequest, Achievement>().
                ForMember(dest => dest.RaceWins, opts => opts.MapFrom(src => src.RaceWins))
                .ForMember(dest => dest.status, opts => opts.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate, src => src.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, src => src.MapFrom(src => DateTime.UtcNow));
            CreateMap<UpdateDriverAchievementsRequest, Achievement>().
                   ForMember(dest => dest.RaceWins, opts => opts.MapFrom(src => src.Wins))
                   .ForMember(dest => dest.UpdatedDate, src => src.MapFrom(src => DateTime.UtcNow));
            CreateMap<CreateDriverRequest, Driver>()
                .ForMember(dest => dest.status, opts => opts.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate, opts => opts.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opts => opts.MapFrom(src => DateTime.UtcNow));
            CreateMap<UpdateDriverRequest, Driver>()
                .ForMember(dest => dest.UpdatedDate, opts => opts.MapFrom(src => DateTime.UtcNow));
        }
    }
}
