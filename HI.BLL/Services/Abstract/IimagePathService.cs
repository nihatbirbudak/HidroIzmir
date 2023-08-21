using HI.Core.Services;
using HI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.BLL.Services.Abstract
{
    public interface IimagePathService : IServiceBase<ImagePath>
    {
        public List<ImagePath> getImagePathtoProdcutId(int id);
        
    }
}
