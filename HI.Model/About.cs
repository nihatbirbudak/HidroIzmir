using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Model
{
    public class About : Entity<int>
    {
        public string Abouts { get; set; }
        public string Mission { get; set; }
        public string Vission { get; set; }
    }
}
