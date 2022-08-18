using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountGroupMasterReportServiceAccess : IAccountGroupMasterReportServiceAccess
    {
        IAccountGroupMasterReportBA _accountGroupMasterBA = null;
        public AccountGroupMasterReportServiceAccess()
        {
            _accountGroupMasterBA = new AccountGroupMasterReportBA();
        }

        /// <summary>
        /// /// Service access of select all record from account Group master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMasterReport> GetBySearch(AccountGroupMasterReportSearchRequest searchRequest)
        {
            return _accountGroupMasterBA.GetBySearch(searchRequest);
        }

                /// <summary>
        /// /// Service access of select all record from account Group master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMasterReport> GetGroupList(AccountGroupMasterReportSearchRequest searchRequest)
        {
            return _accountGroupMasterBA.GetGroupList(searchRequest);
        }
    }
}
