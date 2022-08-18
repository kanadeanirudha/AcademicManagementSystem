using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountTrialBalanceReportServiceAccess : IAccountTrialBalanceReportServiceAccess
    {
        IAccountTrialBalanceReportBA _accountTrialBalanceReportBA = null;
        public AccountTrialBalanceReportServiceAccess()
        {
            _accountTrialBalanceReportBA = new AccountTrialBalanceReportBA();
        }

        public IBaseEntityCollectionResponse<AccountTrialBalanceReport> GetBySearch(AccountTrialBalanceReportSearchRequest searchRequest)
        {
            return _accountTrialBalanceReportBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountTrialBalanceReport> SelectByID(AccountTrialBalanceReport item)
        {
            return _accountTrialBalanceReportBA.SelectByID(item);
        }
    }
}
