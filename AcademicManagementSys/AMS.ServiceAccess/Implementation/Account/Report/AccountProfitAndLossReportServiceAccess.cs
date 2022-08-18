using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountProfitAndLossReportServiceAccess : IAccountProfitAndLossReportServiceAccess
    {
        IAccountProfitAndLossReportBA _accountProfitAndLossReportBA = null;
        public AccountProfitAndLossReportServiceAccess()
        {
            _accountProfitAndLossReportBA = new AccountProfitAndLossReportBA();
        }

        public IBaseEntityCollectionResponse<AccountProfitAndLossReport> GetBySearch(AccountProfitAndLossReportSearchRequest searchRequest)
        {
            return _accountProfitAndLossReportBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountProfitAndLossReport> SelectByID(AccountProfitAndLossReport item)
        {
            return _accountProfitAndLossReportBA.SelectByID(item);
        }
    }
}
