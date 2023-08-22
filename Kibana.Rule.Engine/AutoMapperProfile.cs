using AutoMapper;
using Kibana.Rule.Engine.Models;
using Kibana.Rule.Engine.Models.RequestDto;

namespace Kibana.Rule.Engine
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RequestDto, Rules>();
            CreateMap<Rules, RequestDto>();

        }
    }
}
