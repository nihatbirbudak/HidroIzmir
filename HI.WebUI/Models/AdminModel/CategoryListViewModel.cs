using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class CategoryListViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public List<Category> Categories { get; set; }
        public List<MainCategory> MainCategories { get; set; }
        public MainCategory MainCategory { get; set; }
        public Category Category { get; set; }
    }
}
