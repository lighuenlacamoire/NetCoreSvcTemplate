using GaliciaSeguros.IaaS.Service.Template.DDD.Application.Services.Implementation;
using GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models;
using GaliciaSeguros.IaaS.Service.Template.DDD.Infrastructure.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
