using GaliciaSeguros.IaaS.Service.Chassis.Storage.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Mappings;
using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Context
{
    public class DataContext : EFContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(IEnumerable<IModelBuilderConfiguration> modelBuilderConfigurations, StorageSettings storageSettings) :
            base(modelBuilderConfigurations, storageSettings)
        {
            Console.WriteLine(storageSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
