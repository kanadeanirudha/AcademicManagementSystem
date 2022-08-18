using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class InventoryReportMaster : BaseDTO
    {
        public string FromDate { get; set; }
        public string UptoDate { get; set; }         
        public decimal CurrentRate { get; set; }
        public decimal PreviousRate { get; set; }       
        public decimal TotalQuantity { get; set; }
        public string ItemNameListXml { get; set; }
        public string LocationNameListXml { get; set; }
        public string XmlString3 { get; set; }
        public int AccountSessionID { get; set; }
        
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }

        public string InventoryReportMasterSearchWord { get; set; }
        public int AccountBalsheetMstID { get; set; }
        public int ConsumptionCount { get; set; }
        public bool IsPosted { get; set; }        
        public decimal Quantity { get; set; }
        public string CategoryCode { get; set; }        
        public decimal PreviousSaleRate { get; set; }
        public int OpeningPurchase { get; set; }       
        public int TotalBalance { get; set; }        
        public string Category { get; set; }
        public decimal MinIndentLevel { get; set; }

        public int ItemID { get; set; }
        public int LocationID { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public string TransactionDate { get; set; }
        public decimal TotalInwardQuantity { get; set; }
        public decimal TotalOutwardQuantity { get; set; }
        public decimal DumpQuantity { get; set; }
        public decimal ShrinkQuantity { get; set; }
        public decimal TotalPurchaseQuantity { get; set; }
        public decimal TotalSaleQuantity { get; set; }
        public string LocationName { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }

        public decimal CurrentQuantity { get; set; }
        public decimal IndendQuantity { get; set; }   
        
        
        
    }
}