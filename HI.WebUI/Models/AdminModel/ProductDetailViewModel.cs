using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class ProductDetailViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
    }
}
