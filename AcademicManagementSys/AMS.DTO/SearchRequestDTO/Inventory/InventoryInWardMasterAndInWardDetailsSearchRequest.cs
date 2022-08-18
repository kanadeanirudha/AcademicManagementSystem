using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class InventoryInWardMasterAndInWardDetailsSearchRequest : Request
    {
        //---------------------------------------InventoryWardMaster-----------------------------
        public int InventoryInWardMasterID { get; set; }
        public DateTime InWordDate { get; set; }
        public string InWordNumber { get; set; }
        public string InwordType { get; set; }
        public int IssueOrPurchaseID { get; set; }

        //-------------------------------InvInwardDetails------------------------------------------
        public int InventoryInWardDetailsID { get; set; }
        public decimal Quantity { get; set; }
        public int ItemID { get; set; }

        //-------------------------Common Property----------------------------------------------------------------

        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int RowLength { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string SearchWord { get; set; }
        public int PersonID { get; set; }
        public int TaskNotificationMasterID { get; set; }

        public int BalanceSheetID
        {
            get;
            set;
        }
    }
}
