using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AccountMasterReportServiceAccess: IAccountMasterReportServiceAccess
    {
        IAccountMasterReportBA _AccountMasterBA = null;

        public AccountMasterReportServiceAccess() 
        {
            _AccountMasterBA = new AccountMasterReportBA();
        }

        /// <summary>
        /// /// Service access of select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMasterReport> GetBySearch(AccountMasterReportSearchRequest searchRequest)
        {
            return _AccountMasterBA.GetBySearch(searchRequest);
        }
    }
}
