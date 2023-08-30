using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Model
{
    public class Slider : Entity<int>
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Content2 { get; set; }
        public string? Link1 { get; set; }
        public string? LinkName1 { get; set; }
        public string? Link2 { get; set; }
        public string? LinkName2 { get; set; }
        public  string? ImageName { get; set; }
    }
}
