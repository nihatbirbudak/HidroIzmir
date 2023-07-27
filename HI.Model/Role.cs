using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Model
{
    public class Role : Entity<int>
    {
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
