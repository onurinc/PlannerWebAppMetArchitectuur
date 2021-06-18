using DataAccesLayer.Data;
using DataAccesLayer.Data.Context;
using DataAccesLayer.Data.InterfaceContext;
using DataAccesLayer.Data.InterfaceRepository;
using LogicLayer.Container;
using LogicLayer.InterfaceContainer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccesLayer.Data.Repository;

namespace ProjectsOnlyCRUDWithoutEntityTemplate
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<IProjectsContext, ProjectsContext>();
            services.AddScoped<IProjectContainer, ProjectContainer>();

            services.AddScoped<INotesRepository, NotesRepository>();
            services.AddScoped<INotesContext, NotesContext>();
            services.AddScoped<INotesContainer, NotesContainer>();

            services.AddScoped<IRemindersRepository, RemindersRepository>();
            services.AddScoped<IRemindersContext, RemindersContext>();
            services.AddScoped<IRemindersContainer, RemindersContainer>();

            services.AddScoped<ISubtasksRepository, SubtasksRepository>();
            services.AddScoped<ISubtasksContext, SubtasksContext>();
            services.AddScoped<ISubtasksContainer, SubtasksContainer>();

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersContext, UsersContext>();
            services.AddScoped<IUsersContainer, UsersContainer>();

            return services;
        }
    }
}
