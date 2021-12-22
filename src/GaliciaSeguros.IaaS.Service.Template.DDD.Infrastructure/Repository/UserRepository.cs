using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Contracts;
using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Context;
using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository
{

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public User GetByName(string name)
        {
            return DbSet.AsEnumerable().FirstOrDefault(c => c.Name == name);
        }
    }
}
