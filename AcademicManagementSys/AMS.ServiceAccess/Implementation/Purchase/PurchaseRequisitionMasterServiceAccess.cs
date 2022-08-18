using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class PurchaseRequisitionMasterServiceAccess : IPurchaseRequisitionMasterServiceAccess
    {
        IPurchaseRequisitionMasterBA _PurchaseRequisitionMasterBA = null;
        public PurchaseRequisitionMasterServiceAccess()
        {
            _PurchaseRequisitionMasterBA = new PurchaseRequisitionMasterBA();
        }
        public IBaseEntityResponse<PurchaseRequisitionMaster> InsertPurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            return _PurchaseRequisitionMasterBA.InsertPurchaseRequisitionMaster(item);
        }
        public IBaseEntityResponse<PurchaseRequisitionMaster> InsertApprovedPurchaseRequisitionRecord(PurchaseRequisitionMaster item)
        {
            return _PurchaseRequisitionMasterBA.InsertApprovedPurchaseRequisitionRecord(item);
        }
        public IBaseEntityResponse<PurchaseRequisitionMaster> UpdatePurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            return _PurchaseRequisitionMasterBA.UpdatePurchaseRequisitionMaster(item);
        }
        public IBaseEntityResponse<PurchaseRequisitionMaster> DeletePurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            return _PurchaseRequisitionMasterBA.DeletePurchaseRequisitionMaster(item);
        }
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetBySearch(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterList(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetPurchaseRequisitionMasterList(searchRequest);
        }
        public IBaseEntityResponse<PurchaseRequisitionMaster> SelectByID(PurchaseRequisitionMaster item)
        {
            return _PurchaseRequisitionMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterListForBelowSafetyLevel(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetPurchaseRequisitionMasterListForBelowSafetyLevel(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterDetailLists(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetPurchaseRequisitionMasterDetailLists(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionForApproval(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetPurchaseRequisitionForApproval(searchRequest);
        }
        //Method For Get UoM details with Its Purchase Price 
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomDetailsForSTOWithPurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetUomDetailsForSTOWithPurchasePrice(searchRequest);
        }
        //Method For Get UoMWisePurchasePrice on change of UOM Drop down 
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomWisePurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetUomWisePurchasePrice(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemAndLocationWiseBatchQuantity(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            return _PurchaseRequisitionMasterBA.GetItemAndLocationWiseBatchQuantity(searchRequest);
        }
    }
}
