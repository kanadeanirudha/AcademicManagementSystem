using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryDailySaleReportBA
    {

        /// <summary>
        /// business action interface of update record of InventoryDailySaleReport.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<InventoryDailySaleReport> GetInventoryDailySaleReportBySearch(InventoryDailySaleReportSearchRequest searchRequest);
    }
}
