using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Model
{
    public class Contact : Entity<int>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Context { get; set; }
        public DateTime UploadTime { get; set; }
        public bool IsRead { get; set; }
        
    }
}
