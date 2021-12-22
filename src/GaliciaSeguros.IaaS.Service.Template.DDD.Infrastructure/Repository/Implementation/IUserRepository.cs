using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository.Implementation
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string name);
    }
}
