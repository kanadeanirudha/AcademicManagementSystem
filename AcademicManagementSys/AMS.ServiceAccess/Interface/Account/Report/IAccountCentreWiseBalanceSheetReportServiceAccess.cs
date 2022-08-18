using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IAccountCentreWiseBalanceSheetReportServiceAccess
    {

        IBaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport> GetBySearch(AccountCentreWiseBalanceSheetReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountCentreWiseBalanceSheetReport> SelectByID(AccountCentreWiseBalanceSheetReport item);
    }
}
