using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAccountGroupMasterReportDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountGroupMasterReport> GetAccountGroupMasterBySearch(AccountGroupMasterReportSearchRequest searchRequest);
        /// <summary>
        /// data provider interface of select all record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountGroupMasterReport> GetGroupList(AccountGroupMasterReportSearchRequest searchRequest);        
    }
}
