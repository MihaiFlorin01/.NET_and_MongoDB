using AutoMapper;

namespace TestProject.API.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Models.LocationForUpdate, Entities.Location>().ReverseMap();
            CreateMap<Models.LocationForCreation, Entities.Location>().ReverseMap();
        }  
    }
}
