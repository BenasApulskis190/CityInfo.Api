using AutoMapper;

namespace CityInfo.Api.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
            CreateMap<Models.PointOfInterestsForCreatingDto, Entities.PointOfInterest>();
            CreateMap<Models.PointOfInterestsForUpdateDto, Entities.PointOfInterest>();
            CreateMap<Entities.PointOfInterest, Models.PointOfInterestsForUpdateDto>();
        }
    }
}