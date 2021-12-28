using GaliciaSeguros.IaaS.Service.Chassis.Storage.EF.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GaliciaSeguros.IaaS.Service.Template.DDD.Domain.Models
{
    [Table("Users")]
    public class User
    {
        public User(string name, string username)
        {
            Name = name;
            UserName = username;
        }

        // Empty constructor for EF
        protected User() { }
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

    }
}
