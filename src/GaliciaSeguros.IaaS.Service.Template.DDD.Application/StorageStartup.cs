using GaliciaSeguros.IaaS.Service.Chassis.Storage.Implementation;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Contracts;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using GaliciaSeguros.IaaS.Service.Template.DDD.Application.Services.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Application.Services;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Application
{
    public static class StorageStartup
    {
        public static IStorageStartup CreateStorageStartup(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IUserService, UserService>();
            return new EFStartup<DataContext>();
        }
        public static void MigrationInitialization(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Takes all of our migrations files and apply them against the database in case they are not implemented
                serviceScope.ServiceProvider.GetService<DataContext>().Database.Migrate();
            }
        }
    }
}
