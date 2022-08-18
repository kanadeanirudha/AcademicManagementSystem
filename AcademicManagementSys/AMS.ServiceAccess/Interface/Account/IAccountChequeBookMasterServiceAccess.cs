using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountChequeBookMasterServiceAccess
    {

        /// <summary>
        /// Service access interface of insert new record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> InsertAccountChequeBookMaster(AccountChequeBookMaster item);

        /// <summary>
        /// Service access interface of update record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> UpdateAccountChequeBookMaster(AccountChequeBookMaster item);

        /// <summary>
        /// Service access interface of dalete record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> DeleteAccountChequeBookMaster(AccountChequeBookMaster item);

        /// <summary>
        /// Service access interface of select all record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountChequeBookMaster> GetBySearch(AccountChequeBookMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> SelectByID(AccountChequeBookMaster item);

        /// <summary>
        /// Service access interface of select one record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookMaster> SelectByAccountID(AccountChequeBookMaster item);
    }
}
