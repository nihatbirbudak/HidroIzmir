using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class ContactDeailViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public Contact Contact { get; set; }
    }
}
