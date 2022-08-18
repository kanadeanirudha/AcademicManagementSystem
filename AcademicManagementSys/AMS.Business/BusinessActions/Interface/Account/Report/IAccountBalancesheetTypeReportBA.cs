using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IAccountBalancesheetTypeReportBA
    {
 

        /// <summary>
        /// business action interface of update record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> GetBySearch(AccountBalancesheetTypeReportSearchRequest searchRequest);


    }
}
