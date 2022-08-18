using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
	public class PurchaseRequirementMasterServiceAccess : IPurchaseRequirementMasterServiceAccess
	{
		IPurchaseRequirementMasterBA _purchaseRequirementMasterBA = null;
		public PurchaseRequirementMasterServiceAccess()
		{
			_purchaseRequirementMasterBA = new PurchaseRequirementMasterBA();
		}
		public IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMaster(PurchaseRequirementMaster item)
		{
			return _purchaseRequirementMasterBA.InsertPurchaseRequirementMaster(item);
		}
        public IBaseEntityResponse<PurchaseRequirementMaster> InsertApprovedPurchaseRequirementRecord(PurchaseRequirementMaster item)
        {
            return _purchaseRequirementMasterBA.InsertApprovedPurchaseRequirementRecord(item);
        }
		public IBaseEntityResponse<PurchaseRequirementMaster> UpdatePurchaseRequirementMaster(PurchaseRequirementMaster item)
		{
			return _purchaseRequirementMasterBA.UpdatePurchaseRequirementMaster(item);
		}
		public IBaseEntityResponse<PurchaseRequirementMaster> DeletePurchaseRequirementMaster(PurchaseRequirementMaster item)
		{
			return _purchaseRequirementMasterBA.DeletePurchaseRequirementMaster(item);
		}
		public IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetBySearch(PurchaseRequirementMasterSearchRequest searchRequest)
		{
			return _purchaseRequirementMasterBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<PurchaseRequirementMaster> SelectByID(PurchaseRequirementMaster item)
		{
			return _purchaseRequirementMasterBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementMasterDetailList(PurchaseRequirementMasterSearchRequest searchRequest)
        {
            return _purchaseRequirementMasterBA.GetPurchaseRequirementMasterDetailList(searchRequest);
        }
        public IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMasterByExcel(PurchaseRequirementMaster item)
        {
            return _purchaseRequirementMasterBA.InsertPurchaseRequirementMasterByExcel(item);
        }
        public IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementForApproval(PurchaseRequirementMasterSearchRequest searchRequest)
        {
            return _purchaseRequirementMasterBA.GetPurchaseRequirementForApproval(searchRequest);
        }
        public IBaseEntityResponse<PurchaseRequirementMaster> GetBlockForProcurementByLocationID(PurchaseRequirementMaster item)
        {
            return _purchaseRequirementMasterBA.GetBlockForProcurementByLocationID(item);
        }
	}
}
