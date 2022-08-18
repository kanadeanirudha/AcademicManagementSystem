using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IAccountProfitAndLossReportDataProvider
    {

        IBaseEntityCollectionResponse<AccountProfitAndLossReport> GetAccountProfitAndLossReportBySearch(AccountProfitAndLossReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountProfitAndLossReport> GetAccountProfitAndLossReportByID(AccountProfitAndLossReport item);
    }
}
 