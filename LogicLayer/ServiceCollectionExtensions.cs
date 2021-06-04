using DataAccesLayer.Data;
using DataAccesLayer.Data.Context;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.InterfaceContainer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccesLayer.Data.Repository;

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

                services.AddScoped<INotesRepository, NotesRepository>();
                services.AddScoped<INotesContext, NotesContext>();
                services.AddScoped<INotesContainer, NotesContainer>();

            return services;
            }
            

    }
}
