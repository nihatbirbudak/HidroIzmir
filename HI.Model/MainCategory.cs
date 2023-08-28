using HI.Core.Entities;

namespace HI.Model
{
    public class MainCategory : Entity<int>
    {
        public string? Name { get; set; }
        public virtual ICollection<Category> Categories { get; set;}
    }
}
