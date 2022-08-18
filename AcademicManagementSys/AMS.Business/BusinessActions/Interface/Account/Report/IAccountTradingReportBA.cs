using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IAccountTradingReportBA
    {

        IBaseEntityCollectionResponse<AccountTradingReport> GetBySearch(AccountTradingReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountTradingReport> SelectByID(AccountTradingReport item);
    }
}
