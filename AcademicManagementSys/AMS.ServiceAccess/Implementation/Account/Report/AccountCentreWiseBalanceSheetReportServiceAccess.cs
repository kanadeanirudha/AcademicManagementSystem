using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountCentreWiseBalanceSheetReportServiceAccess : IAccountCentreWiseBalanceSheetReportServiceAccess
    {
        IAccountCentreWiseBalanceSheetReportBA _accountCentreWiseBalanceSheetReportBA = null;
        public AccountCentreWiseBalanceSheetReportServiceAccess()
        {
            _accountCentreWiseBalanceSheetReportBA = new AccountCentreWiseBalanceSheetReportBA();
        }

        public IBaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport> GetBySearch(AccountCentreWiseBalanceSheetReportSearchRequest searchRequest)
        {
            return _accountCentreWiseBalanceSheetReportBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountCentreWiseBalanceSheetReport> SelectByID(AccountCentreWiseBalanceSheetReport item)
        {
            return _accountCentreWiseBalanceSheetReportBA.SelectByID(item);
        }
    }
}
