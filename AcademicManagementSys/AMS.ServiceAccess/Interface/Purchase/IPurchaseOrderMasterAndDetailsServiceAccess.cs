﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IPurchaseOrderMasterAndDetailsServiceAccess
    {
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertPurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> UpdatePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> DeletePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetBySearch(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> SelectByID(PurchaseOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> SelectByPurchaseRequisitionMasterID(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetRecordForPurchaseOrderPDF(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertApprovedPurchaseOrderRecord(PurchaseOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderForApproval(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
    }
}
