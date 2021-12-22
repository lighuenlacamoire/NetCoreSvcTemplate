using GaliciaSeguros.IaaS.Service.Chassis.Storage.Implementation;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Contracts;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using GaliciaSeguros.IaaS.Service.Template.DDD.Application.Services.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Application.Services;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Application
{
    public static class StorageStartup
    {
        public static IStorageStartup CreateStorageStartup(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            return new EFStartup<DataContext, DataModelBuilderConfiguration>(
                new List<(Type DomainType, Type StorageType)>
                {
                    //(typeof(IUserRepository),typeof(UserRepository))
                });
        }
    }
}
