using HI.Core.Services;
using HI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.BLL.Services.Abstract
{
    public interface IUserService : IServiceBase<User>
    {
        User FindwithUsernameandMail(string mailorUserName, string Password);
        List<User> getAllUserinRole(int UserId);
        void changeRememberMe(User user);
    }
}
