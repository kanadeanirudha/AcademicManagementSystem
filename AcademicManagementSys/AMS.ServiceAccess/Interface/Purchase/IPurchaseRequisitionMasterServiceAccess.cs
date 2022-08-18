using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IPurchaseRequisitionMasterServiceAccess
    {
        IBaseEntityResponse<PurchaseRequisitionMaster> InsertPurchaseRequisitionMaster(PurchaseRequisitionMaster item);
        IBaseEntityResponse<PurchaseRequisitionMaster> InsertApprovedPurchaseRequisitionRecord(PurchaseRequisitionMaster item);
        IBaseEntityResponse<PurchaseRequisitionMaster> UpdatePurchaseRequisitionMaster(PurchaseRequisitionMaster item);
        IBaseEntityResponse<PurchaseRequisitionMaster> DeletePurchaseRequisitionMaster(PurchaseRequisitionMaster item);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetBySearch(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseRequisitionMaster> SelectByID(PurchaseRequisitionMaster item);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterList(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterListForBelowSafetyLevel(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterDetailLists(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionForApproval(PurchaseRequisitionMasterSearchRequest searchRequest);

        //Method For Get UoM details with Its Purchase Price 
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomDetailsForSTOWithPurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest);

        //Method For Get UoMWisePurchasePrice on change of UOM Drop down 
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomWisePurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemAndLocationWiseBatchQuantity(PurchaseRequisitionMasterSearchRequest searchRequest);
    }
}
