using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class AboutUpdateViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public About About { get; set; }
    }
}
