using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountExclusiveToCentreReportServiceAccess : IAccountExclusiveToCentreReportServiceAccess
    {
        IAccountExclusiveToCentreReportBA _accountExclusiveToCentreReporttBA = null;
        public AccountExclusiveToCentreReportServiceAccess()
        {
            _accountExclusiveToCentreReporttBA = new AccountExclusiveToCentreReportBA();
        }

        public IBaseEntityCollectionResponse<AccountExclusiveToCentreReport> GetBySearch(AccountExclusiveToCentreReportSearchRequest searchRequest)
        {
            return _accountExclusiveToCentreReporttBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountExclusiveToCentreReport> SelectByID(AccountExclusiveToCentreReport item)
        {
            return _accountExclusiveToCentreReporttBA.SelectByID(item);
        }
    }
}
