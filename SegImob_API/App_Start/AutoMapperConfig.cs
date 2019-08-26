using AutoMapper;
using SegImob_API.Mappers;

namespace SegImob_API
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
           {
               cfg.AddProfile(new DomainToViewModelMappingsProfile());
           });
        }

    }
}