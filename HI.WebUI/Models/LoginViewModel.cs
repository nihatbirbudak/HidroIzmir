using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models
{
    public class LoginViewModel : IBaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public User User { get; set; }
    }
}
