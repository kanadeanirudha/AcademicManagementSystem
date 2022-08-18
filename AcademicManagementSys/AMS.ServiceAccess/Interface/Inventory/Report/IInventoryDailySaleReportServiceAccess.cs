using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryDailySaleReportServiceAccess
    {
        /// <summary>
        /// Service access interface of select all record of InventoryDailySaleReport.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<InventoryDailySaleReport> GetBySearch(InventoryDailySaleReportSearchRequest searchRequest);
    }
}
