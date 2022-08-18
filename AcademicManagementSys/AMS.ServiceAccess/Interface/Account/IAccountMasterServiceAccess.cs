using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountMasterServiceAccess
    {
        IBaseEntityResponse<AccountMaster> InsertAccountMaster(AccountMaster item);

        IBaseEntityResponse<AccountMaster> UpdateAccountMaster(AccountMaster item);

        IBaseEntityResponse<AccountMaster> DeleteAccountMaster(AccountMaster item);

        IBaseEntityCollectionResponse<AccountMaster> GetBySearch(AccountMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AccountMaster> GetAccountList(AccountMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountMaster> GetAccountListForReport(AccountMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AccountMaster> GetSurplusDeficitList(AccountMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountMaster> GetAlternateGroupList(AccountMasterSearchRequest searchRequest);

        IBaseEntityResponse<AccountMaster> SelectByID(AccountMaster item);
    }

  
}
