using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountVoucherSettingMasterServiceAccess : IAccountVoucherSettingMasterServiceAccess
    {
        IAccountVoucherSettingMasterBA accountVoucherSettingMasterBA = null;
        public AccountVoucherSettingMasterServiceAccess()
        {
            accountVoucherSettingMasterBA = new AccountVoucherSettingMasterBA();
        }
        public IBaseEntityResponse<AccountVoucherSettingMaster> InsertAccountVoucherSettingMaster(AccountVoucherSettingMaster item)
        {
            return accountVoucherSettingMasterBA.InsertAccountVoucherSettingMaster(item);
        }
        public IBaseEntityResponse<AccountVoucherSettingMaster> UpdateAccountVoucherSettingMaster(AccountVoucherSettingMaster item)
        {
            return accountVoucherSettingMasterBA.UpdateAccountVoucherSettingMaster(item);
        }
        public IBaseEntityResponse<AccountVoucherSettingMaster> DeleteAccountVoucherSettingMaster(AccountVoucherSettingMaster item)
        {
            return accountVoucherSettingMasterBA.DeleteAccountVoucherSettingMaster(item);
        }
        public IBaseEntityCollectionResponse<AccountVoucherSettingMaster> GetBySearch(AccountVoucherSettingMasterSearchRequest searchRequest)
        {
            return accountVoucherSettingMasterBA.GetBySearch(searchRequest);
        }
       
        public IBaseEntityResponse<AccountVoucherSettingMaster> SelectByID(AccountVoucherSettingMaster item)
        {
            return accountVoucherSettingMasterBA.SelectByID(item);
        }
    }
}
