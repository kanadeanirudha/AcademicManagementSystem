using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountSupplierMasterReportServiceAccess : IAccountSupplierMasterReportServiceAccess
    {
        IAccountSupplierMasterReportBA _accountSupplierMasterReportBA = null;
        public AccountSupplierMasterReportServiceAccess()
        {
            _accountSupplierMasterReportBA = new AccountSupplierMasterReportBA();
        }

        public IBaseEntityCollectionResponse<AccountSupplierMasterReport> GetBySearch(AccountSupplierMasterReportSearchRequest searchRequest)
        {
            return _accountSupplierMasterReportBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountSupplierMasterReport> SelectByID(AccountSupplierMasterReport item)
        {
            return _accountSupplierMasterReportBA.SelectByID(item);
        }
    }
}
