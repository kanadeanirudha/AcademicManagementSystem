using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountTradingReportServiceAccess : IAccountTradingReportServiceAccess
    {
        IAccountTradingReportBA _AccountTradingReportBA = null;
        public AccountTradingReportServiceAccess()
        {
            _AccountTradingReportBA = new AccountTradingReportBA();
        }

        public IBaseEntityCollectionResponse<AccountTradingReport> GetBySearch(AccountTradingReportSearchRequest searchRequest)
        {
            return _AccountTradingReportBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountTradingReport> SelectByID(AccountTradingReport item)
        {
            return _AccountTradingReportBA.SelectByID(item);
        }
    }
}
