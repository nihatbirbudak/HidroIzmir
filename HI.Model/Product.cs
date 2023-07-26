using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HI.Model
{
    public class Product : Entity<int>
    {
        public string? Name { get; set; }
        public int MyProperty { get; set; }
        public virtual Category Category { get; set; }
    }
}
