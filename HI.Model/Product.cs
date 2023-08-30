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
        public string? Title { get; set; }
        public ICollection<ImagePath> ImagePaths { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string? Tags { get; set; }
        public bool ShowHomePage { get; set; }
        public string HomePageImageName { get; set; }

        public string Description { get; set; }
        public string? Content1 { get; set; }
        public string? Content2 { get; set; }
        public string? Content3 { get; set; }
        public string? ContentName1 { get; set; }
        public string? ContentName2 { get; set; }
        public string? ContentName3 { get; set;}
    }
}
