using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sport.Business.Mappings;

namespace Sport.API.Extentions
{
    public static class MappingManager
    {
        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<UserMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
