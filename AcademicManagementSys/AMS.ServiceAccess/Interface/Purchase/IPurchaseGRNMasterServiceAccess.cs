using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IPurchaseGRNMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> InsertPurchaseGRNMaster(PurchaseGRNMaster item);

        /// <summary>
        /// Service access interface of update record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> UpdatePurchaseGRNMaster(PurchaseGRNMaster item);

        /// <summary>
        /// Service access interface of dalete record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> DeletePurchaseGRNMaster(PurchaseGRNMaster item);

        /// <summary>
        /// Service access interface of select all record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBySearch(PurchaseGRNMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBySearchList(PurchaseGRNMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> SelectByID(PurchaseGRNMaster item);
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseOrderMasterListForGRN(PurchaseGRNMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBatchList(PurchaseGRNMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNDetailsByID(PurchaseGRNMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGrnMasterListForPDF(PurchaseGRNMasterSearchRequest searchRequest);
    }
}
