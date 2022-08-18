using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IAccountTrialBalanceReportBA
    {

        IBaseEntityCollectionResponse<AccountTrialBalanceReport> GetBySearch(AccountTrialBalanceReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountTrialBalanceReport> SelectByID(AccountTrialBalanceReport item);
    }
}
