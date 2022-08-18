using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountDayBookReportServiceAccess : IAccountDayBookReportServiceAccess
    {
        IAccountDayBookReportBA _accountDayBookReportBA = null;
         public AccountDayBookReportServiceAccess()
        {
            _accountDayBookReportBA = new AccountDayBookReportBA();
        }

         public IBaseEntityCollectionResponse<AccountDayBookReport> GetBySearch(AccountDayBookReportSearchRequest searchRequest)
         {
             return _accountDayBookReportBA.GetBySearch(searchRequest);
         }
    }
}
