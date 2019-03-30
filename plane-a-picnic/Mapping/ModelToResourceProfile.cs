using AutoMapper;
using plane_a_picnic.Domain.Models;
using plane_a_picnic.ResourceModels;

namespace plane_a_picnic.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<RunwayModel, RunwayResourceModel>();
            CreateMap<AirportModel, AirportBasicResourceModel>();
            CreateMap<AirportModel, AirportResourceModel>();
        }
    }
}