using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;

namespace FormulaOne.API.Utilities.MappingProfiles
{
    public class DomainToRes : Profile
    {
        public DomainToRes()
        {
            CreateMap<Achievement, DriverAchievementResponse>().
                ForMember(dest=>dest.DriverId,opts=>opts.MapFrom(src=>src.DriverId)).
               ForMember(dest => dest.RaceWins, opts => opts.MapFrom(src => src.RaceWins));
            CreateMap<Driver, GetDriverResponse>()
                .ForMember(dest=>dest.DriverId,opts=>opts.MapFrom(src=>src.Id))
                .ForMember(dest => dest.FullName, opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
