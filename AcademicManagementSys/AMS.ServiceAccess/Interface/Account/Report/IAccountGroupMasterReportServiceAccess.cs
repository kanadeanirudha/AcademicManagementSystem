using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountGroupMasterReportServiceAccess
    {

        /// <summary>
        /// Service access interface of select all record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountGroupMasterReport> GetBySearch(AccountGroupMasterReportSearchRequest searchRequest);

         /// <summary>
        /// Service access interface of select all record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountGroupMasterReport> GetGroupList(AccountGroupMasterReportSearchRequest searchRequest);

    }
}
