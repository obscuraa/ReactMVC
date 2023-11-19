using AutoMapper;
using ReactMVC.Models;

namespace ReactMVC.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<APIUser, UserDto>().ReverseMap();
        }
    }
}
