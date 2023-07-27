using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Model
{
    public class User : Entity<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool rememberMe { get; set; }

        public Role Role { get; set; }

    }
}
