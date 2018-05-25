using AutoMapper;
using KeyboardAPI.APIs;
using KeyboardAPI.Interops.Enums;

namespace KeyboardAPI
{
    public static class Mapping
    {
        public static IMapper GetConfiguredMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<VIRTUAL_KEY_CODE, Key>());
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}