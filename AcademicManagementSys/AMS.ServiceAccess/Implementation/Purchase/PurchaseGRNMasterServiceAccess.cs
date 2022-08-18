using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class PurchaseGRNMasterServiceAccess : IPurchaseGRNMasterServiceAccess
    {
        IPurchaseGRNMasterBA _PurchaseGRNMasterBA = null;

        public PurchaseGRNMasterServiceAccess()
        {
            _PurchaseGRNMasterBA = new PurchaseGRNMasterBA();
        }
        /// <summary>
        /// Service access of create new record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> InsertPurchaseGRNMaster(PurchaseGRNMaster item)
        {
            return _PurchaseGRNMasterBA.InsertPurchaseGRNMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> UpdatePurchaseGRNMaster(PurchaseGRNMaster item)
        {
            return _PurchaseGRNMasterBA.UpdatePurchaseGRNMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> DeletePurchaseGRNMaster(PurchaseGRNMaster item)
        {
            return _PurchaseGRNMasterBA.DeletePurchaseGRNMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from PurchaseGRNMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBySearch(PurchaseGRNMasterSearchRequest searchRequest)
        {
            return _PurchaseGRNMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from PurchaseGRNMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBySearchList(PurchaseGRNMasterSearchRequest searchRequest)
        {
            return _PurchaseGRNMasterBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from PurchaseGRNMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> SelectByID(PurchaseGRNMaster item)
        {
            return _PurchaseGRNMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseOrderMasterListForGRN(PurchaseGRNMasterSearchRequest searchRequest)
        {
            return _PurchaseGRNMasterBA.GetPurchaseOrderMasterListForGRN(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBatchList(PurchaseGRNMasterSearchRequest searchRequest)
        {
            return _PurchaseGRNMasterBA.GetBatchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNDetailsByID(PurchaseGRNMasterSearchRequest searchRequest)
        {
            return _PurchaseGRNMasterBA.GetPurchaseGRNDetailsByID(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGrnMasterListForPDF(PurchaseGRNMasterSearchRequest searchRequest)
        {
            return _PurchaseGRNMasterBA.GetPurchaseGrnMasterListForPDF(searchRequest);
        }

    }
}

