using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
	public interface IPurchaseRequirementMasterBA
	{
		IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMaster(PurchaseRequirementMaster item);
        IBaseEntityResponse<PurchaseRequirementMaster> InsertApprovedPurchaseRequirementRecord(PurchaseRequirementMaster item);
		IBaseEntityResponse<PurchaseRequirementMaster> UpdatePurchaseRequirementMaster(PurchaseRequirementMaster item);
		IBaseEntityResponse<PurchaseRequirementMaster> DeletePurchaseRequirementMaster(PurchaseRequirementMaster item);
		IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetBySearch(PurchaseRequirementMasterSearchRequest searchRequest);
		IBaseEntityResponse<PurchaseRequirementMaster> SelectByID(PurchaseRequirementMaster item);
        IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementMasterDetailList(PurchaseRequirementMasterSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMasterByExcel(PurchaseRequirementMaster item);
        IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementForApproval(PurchaseRequirementMasterSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseRequirementMaster> GetBlockForProcurementByLocationID(PurchaseRequirementMaster item);

	}
}
