using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountBalancesheetReportServiceAccess : IAccountBalancesheetReportServiceAccess
    {
        IAccountBalancesheetReportBA _accountBalancesheetReportBA = null;
        public AccountBalancesheetReportServiceAccess()
        {
            _accountBalancesheetReportBA = new AccountBalancesheetReportBA();
        }

         public IBaseEntityCollectionResponse<AccountBalancesheetReport> GetBySearch(AccountBalancesheetReportSearchRequest searchRequest)
         {
             return _accountBalancesheetReportBA.GetBySearch(searchRequest);
         }
    }
}
