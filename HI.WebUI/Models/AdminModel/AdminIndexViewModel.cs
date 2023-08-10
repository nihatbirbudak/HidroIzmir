using HI.Model;
using HI.WebUI.Models.BaseClass;
using X.PagedList;

namespace HI.WebUI.Models.AdminModel
{
    public class AdminIndexViewModel : IBaseViewModel
    {
        public User User { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public int PageNumber { get; set; }
        public IPagedList<Contact> Value { get; set; }
        public string filter { get; set; }
    }
}
