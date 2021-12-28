using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Application.Services.Implementation
{
    public interface IUserService : IDisposable
    {
        bool Create(User user);
        void Delete(User user);
        IEnumerable<User> GetAll();
    }
}
