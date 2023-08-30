using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.HomeViewModel
{
    public class ProdcutDetailHomeViewModel : IMainViewModel
    {
        public ContactPage ContactPage { get; set; }
        public Product Product { get; set; }
        public List<ImagePath> ImagePaths { get; set; }
    }
}
