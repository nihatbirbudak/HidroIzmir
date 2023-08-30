using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Model
{
    public class Dealer : Entity<int>
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
    }
}
