using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryIssueMasterAndIssueDetailsSearchRequest : Request
    {
        public int InventoryIssueMasterID { get; set; }
        public string TransactionDate { get; set; }
        public string IssueNumber { get; set; }
        public int IssueFromLocationID { get; set; }
        public int IssueToLocationID { get; set; }


        public int InventoryIssueDetailID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }

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

        //Extra Proprty.
        public int BalanceSheetID { get; set; }
    }
}
