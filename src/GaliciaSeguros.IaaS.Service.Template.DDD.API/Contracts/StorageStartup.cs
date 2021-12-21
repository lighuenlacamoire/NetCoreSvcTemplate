using GaliciaSeguros.IaaS.Service.Chassis.Storage.Implementation;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.Mongo.Contracts;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.API.Contracts
{
    public static class StorageStartup
    {
        public static IStorageStartup CreateStorageStartup(this IServiceCollection serviceCollection)
        {
            return new MongoStartup(
                new List<(Type DomainType, Type StorageType)>
                {
                });
        }
    }
}
