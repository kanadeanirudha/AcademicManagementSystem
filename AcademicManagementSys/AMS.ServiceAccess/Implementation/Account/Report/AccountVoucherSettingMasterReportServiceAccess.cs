using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountVoucherSettingMasterReportServiceAccess : IAccountVoucherSettingMasterReportServiceAccess
    {
        IAccountVoucherSettingMasterReportBA _accVoucherSettingMasterBA = null;
        public AccountVoucherSettingMasterReportServiceAccess()
        {
            _accVoucherSettingMasterBA = new AccountVoucherSettingMasterReportBA();
        }
   
        public IBaseEntityCollectionResponse<AccountVoucherSettingMasterReport> GetBySearch(AccountVoucherSettingMasterReportSearchRequest searchRequest)
        {
            return _accVoucherSettingMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountVoucherSettingMasterReport> SelectByID(AccountVoucherSettingMasterReport item)
        {
            return _accVoucherSettingMasterBA.SelectByID(item);
        }
    }
}
