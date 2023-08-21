using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class ProdcutAddViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public IFormFile file { get; set; }
    }
}
