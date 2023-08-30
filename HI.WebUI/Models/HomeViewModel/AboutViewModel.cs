using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.HomeViewModel
{
    public class AboutViewModel : IMainViewModel
    {
        public ContactPage ContactPage { get; set; }
        public About About { get; set; }
        public string Name { get; set; } 
    }
}
