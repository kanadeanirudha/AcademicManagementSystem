using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AccountBalancesheetMasterServiceAccess : IAccountBalancesheetMasterServiceAccess
    {
        IAccountBalancesheetMasterBA _accBalsheetMasterBA = null;

        public AccountBalancesheetMasterServiceAccess() 
        {
            _accBalsheetMasterBA = new AccountBalancesheetMasterBA();
        }

        /// <summary>
        /// Service access of create new record of account balance sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetMaster> InsertAccBalsheetMaster(AccountBalancesheetMaster item)
        {
            return _accBalsheetMasterBA.InsertAccBalsheetMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of account balance sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetMaster> UpdateAccBalsheetMaster(AccountBalancesheetMaster item)
        {
            return _accBalsheetMasterBA.UpdateAccBalsheetMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from account balance sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetMaster> DeleteAccBalsheetMaster(AccountBalancesheetMaster item)
        {
            return _accBalsheetMasterBA.DeleteAccBalsheetMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from account balance sheet master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBySearch(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            return _accBalsheetMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all balance sheet according to centre code from account balance sheet master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalanceSheetList(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            return _accBalsheetMasterBA.GetBalanceSheetList(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all balance sheet according to centre code from account balance sheet master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForAccountMasterSearchList(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            return _accBalsheetMasterBA.GetBalancesheetForAccountMasterSearchList(searchRequest);
        }
        
        /// <summary>
        /// /// Service access Method to select Balancesheet for Multiple Select List in Account Master Form.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForMultipleSelectList(AccountBalancesheetMasterSearchRequest searchRequest)
        {
            return _accBalsheetMasterBA.GetBalancesheetForMultipleSelectList(searchRequest);
        }


        /// <summary>
        /// Service access of select a record from account balance sheet master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetMaster> SelectByID(AccountBalancesheetMaster item)
        {
            return _accBalsheetMasterBA.SelectByID(item);
        }
    }
}
