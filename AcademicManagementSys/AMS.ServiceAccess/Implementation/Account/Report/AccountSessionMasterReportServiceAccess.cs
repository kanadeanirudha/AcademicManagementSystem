using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountSessionMasterReportServiceAccess : IAccountSessionMasterReportServiceAccess
    {
        IAccountSessionMasterReportBA _accountSessionMasterReportBA = null;
        public AccountSessionMasterReportServiceAccess()
        {
            _accountSessionMasterReportBA = new AccountSessionMasterReportBA();
        }
     
        public IBaseEntityCollectionResponse<AccountSessionMasterReport> GetBySearch(AccountSessionMasterReportSearchRequest searchRequest)
        {
            return _accountSessionMasterReportBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountSessionMasterReport> SelectByID(AccountSessionMasterReport item)
        {
            return _accountSessionMasterReportBA.SelectByID(item);
        }
    }
}
