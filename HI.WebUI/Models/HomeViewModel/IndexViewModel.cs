using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.HomeViewModel
{
    public class IndexViewModel : IMainViewModel
    {
        public ContactPage ContactPage { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Dealer> Dealers { get; set; }
        public List<Product> Products { get; set; }
        public Contact Contact { get; set; }
    }
}
