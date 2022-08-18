using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IRegisterPOSAPIDataProvider
    {
        IBaseEntityResponse<RegisterPOSAPI> RegisterPOS(RegisterPOSAPI item);
    }
}
