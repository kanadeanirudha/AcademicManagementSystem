using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class InventoryReportMasterSearchRequest : Request
    {
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public string LocationName { get; set; }
        public int LocationID { get; set; }
        public string ItemName { get; set; }
        public decimal CurrentRate { get; set; }
        public decimal PreviousRate { get; set; }
        public int DumpQuantity { get; set; }
        public int ShrinkQuantity { get; set; }
        public int TotalQuantity { get; set; }
        

        public string ItemNameListXml { get; set; }
        public string LocationNameListXml { get; set; }
        public string XmlString3 { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

        public string InventoryReportMasterSearchWord { get; set; }
        public int AccountBalsheetMstID { get; set; }
        public int ConsumptionCount { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal TotalInwardQuantity { get; set; }
        public decimal TotalOutwardQuantity { get; set; }
        public decimal TotalPurchaseQuantity { get; set; }
    }
}
