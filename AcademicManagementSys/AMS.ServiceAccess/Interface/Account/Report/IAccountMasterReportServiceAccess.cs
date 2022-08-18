using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountMasterReportServiceAccess
    {
        IBaseEntityCollectionResponse<AccountMasterReport> GetBySearch(AccountMasterReportSearchRequest searchRequest);
    }
}
