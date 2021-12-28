using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Implementation;
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
        private readonly IEFUnitOfWork _efUnitOfWork;
        private readonly IUserRepository _userRepository;
        public UserService(
            IEFUnitOfWork efUnitOfWork,
            IUserRepository userRepository
            )
        {
            _efUnitOfWork = efUnitOfWork;
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public bool Create(User user)
        {
            var newUser = _efUnitOfWork.dbContext.Add(user);
            var saved = _efUnitOfWork.Commit();
            return saved > 0;
        }

        public void Delete(User user)
        {
            // _userRepository.Delete(user);
            _efUnitOfWork.dbContext.Remove(user);
            var deleted = _efUnitOfWork.Commit();
            //_efUnitOfWork.GetRepository<User>().Delete(user);
            // _userRepository.Delete(user);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
