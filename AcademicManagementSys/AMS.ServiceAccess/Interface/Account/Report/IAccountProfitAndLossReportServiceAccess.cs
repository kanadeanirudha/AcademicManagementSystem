using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IAccountProfitAndLossReportServiceAccess
    {

        IBaseEntityCollectionResponse<AccountProfitAndLossReport> GetBySearch(AccountProfitAndLossReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountProfitAndLossReport> SelectByID(AccountProfitAndLossReport item);
    }
}
