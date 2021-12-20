using GaliciaSeguros.IaaS.Service.Chassis.Storage.Mongo.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.Mongo.Implementation;

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
