using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IAccountVoucherSettingMasterServiceAccess
    {
        IBaseEntityResponse<AccountVoucherSettingMaster> InsertAccountVoucherSettingMaster(AccountVoucherSettingMaster item);
        IBaseEntityResponse<AccountVoucherSettingMaster> UpdateAccountVoucherSettingMaster(AccountVoucherSettingMaster item);
        IBaseEntityResponse<AccountVoucherSettingMaster> DeleteAccountVoucherSettingMaster(AccountVoucherSettingMaster item);
        IBaseEntityCollectionResponse<AccountVoucherSettingMaster> GetBySearch(AccountVoucherSettingMasterSearchRequest searchRequest);
        IBaseEntityResponse<AccountVoucherSettingMaster> SelectByID(AccountVoucherSettingMaster item);
    }
}
