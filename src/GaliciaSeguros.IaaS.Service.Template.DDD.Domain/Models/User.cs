using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models
{
    public class User
    {
        public User(Guid id, string name, string username)
        {
            Id = id;
            Name = name;
            UserName = username;
        }

        // Empty constructor for EF
        public User() { }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

    }
}
