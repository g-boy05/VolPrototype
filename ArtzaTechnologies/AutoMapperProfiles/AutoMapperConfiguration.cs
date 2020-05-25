using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtzaTechnologies.AutoMapperProfiles
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(
                x =>
                {
                    var profileTypes = typeof(AutoMapperConfiguration).Assembly.GetTypes().Where(type => type.Namespace != null &&
                                                                                                         type.Namespace.StartsWith("ArtzaTechnologies.AutoMapperProfiles") && !type.IsAbstract && typeof(Profile).IsAssignableFrom(type));

                    foreach (var type in profileTypes)
                    {
                        x.AddProfile((Profile)Activator.CreateInstance(type));
                    }
                });

            Mapper.AssertConfigurationIsValid();
        }
    }
}
