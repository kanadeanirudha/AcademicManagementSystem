using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IAccountTransactionMasterServiceAccess
    {
        IBaseEntityResponse<AccountTransactionMaster> InsertAccountTransactionMaster(AccountTransactionMaster item);
        IBaseEntityResponse<AccountTransactionMaster> UpdateAccountTransactionMaster(AccountTransactionMaster item);
        IBaseEntityResponse<AccountTransactionMaster> DeleteAccountTransactionMaster(AccountTransactionMaster item);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearch(AccountTransactionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearchForEditView(AccountTransactionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountList(AccountTransactionMasterSearchRequest searchRequest);
        IBaseEntityResponse<AccountTransactionMaster> SelectByID(AccountTransactionMaster item);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetVoucherDetailsForApproval(AccountTransactionMasterSearchRequest searchRequest);
        IBaseEntityResponse<AccountTransactionMaster> InsertAccountVoucherRequest(AccountTransactionMaster item);   
    }
}
