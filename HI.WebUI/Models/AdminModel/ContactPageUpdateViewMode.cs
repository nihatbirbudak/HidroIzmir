using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class ContactPageUpdateViewMode : IBaseViewModel
    {
        public User User { get; set; }
        public ContactPage ContactPage { get; set; }
    }
}
