using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models
{
    public class ProductListViewModel
    {
       public List<Product> Products { get; set; }
       public List<Category> Categories { get; set; }
       public List<MainCategory> MainCategories { get; set; }


    }
}
