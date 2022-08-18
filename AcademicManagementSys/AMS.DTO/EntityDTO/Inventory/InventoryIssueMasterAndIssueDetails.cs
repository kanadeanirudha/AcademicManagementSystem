using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryIssueMasterAndIssueDetails : BaseDTO
    {
        //---------------------------------------InventoryIssueMasterAndIssueDetails-----------------------------

        public int InventoryIssueMasterID { get; set; }
        public string TransactionDate { get; set; }
        public string IssueNumber { get; set; }
        public int IssueFromLocationID { get; set; }
        public int IssueToLocationID { get; set; }


        public int InventoryIssueDetailID { get; set; }
        public int ItemID { get; set; }
        public decimal AvailbleQuantity { get; set; }


        //-------------------------Common Property----------------------------------------------------------------

        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }

        //Extra Property.
        public string IssueFromLocationName { get; set; }
        public string IssueToLocationName { get; set; }
        public string ItemName { get; set; }
        public decimal IssueQuantity { get; set; }
        public int BalanceSheetID { get; set; }
        public string IssueDetails { get; set; }
        public string CentreCode { get; set; }
        public int AccountSessionID { get; set; }
    }
}
