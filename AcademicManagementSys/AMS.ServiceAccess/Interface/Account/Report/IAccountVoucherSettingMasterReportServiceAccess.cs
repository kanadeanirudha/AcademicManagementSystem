using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IAccountVoucherSettingMasterReportServiceAccess
    {

        IBaseEntityCollectionResponse<AccountVoucherSettingMasterReport> GetBySearch(AccountVoucherSettingMasterReportSearchRequest searchRequest);
        IBaseEntityResponse<AccountVoucherSettingMasterReport> SelectByID(AccountVoucherSettingMasterReport item);
    }
}
