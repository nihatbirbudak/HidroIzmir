using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class ProductChangeViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<ImagePath> ImagePaths { get; set; }
    }
}
