using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class InventoryDailySaleReportServiceAccess: IInventoryDailySaleReportServiceAccess
    {
        IInventoryDailySaleReportBA _InventoryDailySaleReportBA = null;
        public InventoryDailySaleReportServiceAccess()
        {
            _InventoryDailySaleReportBA = new InventoryDailySaleReportBA();
        }

        /// <summary>
        /// /// Service access of select all record from InventoryDailySaleReport table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDailySaleReport> GetBySearch(InventoryDailySaleReportSearchRequest searchRequest)
        {
            return _InventoryDailySaleReportBA.GetInventoryDailySaleReportBySearch(searchRequest);
        }
    }
}
