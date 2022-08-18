using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAccountBalancesheetTypeReportDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> GetAccountBalancesheetTypeReportBySearch(AccountBalancesheetTypeReportSearchRequest searchRequest);


    }
}
