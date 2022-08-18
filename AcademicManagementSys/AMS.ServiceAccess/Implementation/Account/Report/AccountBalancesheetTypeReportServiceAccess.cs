using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountBalancesheetTypeReportServiceAccess: IAccountBalancesheetTypeReportServiceAccess
    {
        IAccountBalancesheetTypeReportBA _accountBalancesheetTypeReportBA = null;
        public AccountBalancesheetTypeReportServiceAccess()
        {
            _accountBalancesheetTypeReportBA = new AccountBalancesheetTypeReportBA();
        }

        /// <summary>
        /// /// Service access of select all record from account balance sheet master type table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> GetBySearch(AccountBalancesheetTypeReportSearchRequest searchRequest)
        {
            return _accountBalancesheetTypeReportBA.GetBySearch(searchRequest);
        }



    }
}
