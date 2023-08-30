using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.HomeViewModel
{
    public class ContactViewModel : IMainViewModel
    {
        public ContactPage ContactPage { get; set; }
        public Contact Contact { get; set; }
    }
}
