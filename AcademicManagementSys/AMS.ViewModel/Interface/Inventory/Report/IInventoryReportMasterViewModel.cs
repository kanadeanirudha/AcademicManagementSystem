using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryReportMasterViewModel
    {
        InventoryReportMaster InventoryReportMasterDTO { get; set; }

        //----------------------------------Properties of EntranceExamPaymentDetails table--------------------------------

        string FromDate { get; set; }
        string UptoDate { get; set; }
        string LocationName { get; set; }
        int LocationID { get; set; }
        string ItemName { get; set; }
        decimal CurrentRate { get; set; }
        decimal PreviousRate { get; set; }
        decimal DumpQuantity { get; set; }
        decimal ShrinkQuantity { get; set; }
        decimal TotalQuantity { get; set; }

        string ItemNameListXml { get; set; }
        string LocationNameListXml { get; set; }
        string XmlString3 { get; set; }

        string InventoryReportMasterSearchWord { get; set; }
        int AccountSessionID { get; set; }
        int ConsumptionCount { get; set; }

        //Common Property.
        bool? IsDeleted { get; set; }
        int? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        bool IsPosted { get; set; }

        decimal OpeningBalance { get; set; }
        decimal TotalInwardQuantity { get; set; }
        decimal TotalOutwardQuantity { get; set; }
        decimal TotalPurchaseQuantity { get; set; }
    }
}
