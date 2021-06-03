using DataAccesLayer.Data;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.InterfaceContainer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services, IConfiguration configuration)
            {
                services.AddScoped<IProjectsRepository, ProjectsRepository>();
                services.AddScoped<IProjectsContext, ProjectsContext>();
                services.AddScoped<IProjectContainer, ProjectContainer>();

                return services;
            }
            

    }
}
