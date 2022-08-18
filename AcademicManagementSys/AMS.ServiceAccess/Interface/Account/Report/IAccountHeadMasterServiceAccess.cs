using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountHeadMasterReportServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> InsertAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// Service access interface of update record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> UpdateAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// Service access interface of dalete record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> DeleteAccountHeadMasterReport(AccountHeadMasterReport item);

        /// <summary>
        /// Service access interface of select all record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMasterReport> GetBySearch(AccountHeadMasterReportSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all head name list from account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMasterReport> GetHeadNameList(AccountHeadMasterReportSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMasterReport> SelectByID(AccountHeadMasterReport item);
    }
}
