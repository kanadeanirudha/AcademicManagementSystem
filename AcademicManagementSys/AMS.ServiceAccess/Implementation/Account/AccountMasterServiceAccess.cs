using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AccountMasterServiceAccess: IAccountMasterServiceAccess
    {
        IAccountMasterBA _AccountMasterBA = null;

        public AccountMasterServiceAccess() 
        {
            _AccountMasterBA = new AccountMasterBA();
        }

        /// <summary>
        /// Service access of create new record of Account Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> InsertAccountMaster(AccountMaster item)
        {
            return _AccountMasterBA.InsertAccountMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of Account Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> UpdateAccountMaster(AccountMaster item)
        {
            return _AccountMasterBA.UpdateAccountMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from Account Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> DeleteAccountMaster(AccountMaster item)
        {
            return _AccountMasterBA.DeleteAccountMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetBySearch(AccountMasterSearchRequest searchRequest)
        {
            return _AccountMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAccountList(AccountMasterSearchRequest searchRequest)
        {
            return _AccountMasterBA.GetAccountList(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAccountListForReport(AccountMasterSearchRequest searchRequest)
        {
            return _AccountMasterBA.GetAccountListForReport(searchRequest);
        }        

        /// <summary>
        /// /// Service access method to select Surplus Deficit List.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetSurplusDeficitList(AccountMasterSearchRequest searchRequest)
        {
            return _AccountMasterBA.GetSurplusDeficitList(searchRequest);
        }

        
        /// <summary>
        /// /// Service access method to select Surplus Deficit List.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMaster> GetAlternateGroupList(AccountMasterSearchRequest searchRequest)
        {
            return _AccountMasterBA.GetAlternateGroupList(searchRequest);
        }        
        /// <summary>
        /// Service access of select a record from Account Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountMaster> SelectByID(AccountMaster item)
        {
            return _AccountMasterBA.SelectByID(item);
        }
    }

  
}
