using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountBalancesheetMasterServiceAccess
    {

        /// <summary>
        /// Service access interface of insert new record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> InsertAccBalsheetMaster(AccountBalancesheetMaster item);

        /// <summary>
        /// Service access interface of update record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> UpdateAccBalsheetMaster(AccountBalancesheetMaster item);

        /// <summary>
        /// Service access interface of dalete record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> DeleteAccBalsheetMaster(AccountBalancesheetMaster item);

        /// <summary>
        /// Service access interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBySearch(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalanceSheetList(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForAccountMasterSearchList(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface to select Balancesheet List for Multiple Select List in Account Master Form.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetMaster> GetBalancesheetForMultipleSelectList(AccountBalancesheetMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of account balace sheet master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetMaster> SelectByID(AccountBalancesheetMaster item);
    }
}
