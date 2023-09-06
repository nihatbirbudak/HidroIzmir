using HI.Model;
using HI.WebUI.Models.BaseClass;

namespace HI.WebUI.Models.AdminModel
{
    public class DealerListViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public List<Dealer> Dealers { get; set; }
        public Dealer Dealer { get; set; }
    }
}
