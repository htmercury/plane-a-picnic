using AutoMapper;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Settings.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<RunwayModel, RunwayResourceModel>();
            CreateMap<AirportModel, AirportBasicResourceModel>();
            CreateMap<AirportModel, AirportResourceModel>();
            CreateMap<RegionModel, RegionResourceModel>();
            CreateMap<RegionModel, RegionBasicResourceModel>();
            CreateMap<CountryModel, CountryResourceModel>();
            CreateMap<CountryModel, CountryBasicResourceModel>();
        }
    }
}