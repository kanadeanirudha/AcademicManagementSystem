using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountGeneralLedgerReportServiceAccess : IAccountGeneralLedgerReportServiceAccess
    {
        IAccountGeneralLedgerReportBA _accountGeneralLedgerReportBA = null;
        public AccountGeneralLedgerReportServiceAccess()
        {
            _accountGeneralLedgerReportBA = new AccountGeneralLedgerReportBA();
        }
      
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetBySearch(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            return _accountGeneralLedgerReportBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetOtherLedgerBySearch(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            return _accountGeneralLedgerReportBA.GetOtherLedgerBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            return _accountGeneralLedgerReportBA.GetPersonNameListByPersonTypeAndAccountId(searchRequest);
        }
        public IBaseEntityResponse<AccountGeneralLedgerReport> SelectByID(AccountGeneralLedgerReport item)
        {
            return _accountGeneralLedgerReportBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetByIndividualBalanceReportSearch(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            return _accountGeneralLedgerReportBA.GetByIndividualBalanceReportSearch(searchRequest);
        }
    }
}
