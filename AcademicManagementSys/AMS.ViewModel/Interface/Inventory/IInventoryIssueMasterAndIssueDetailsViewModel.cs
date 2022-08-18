using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryIssueMasterAndIssueDetailsViewModel
    {
        InventoryIssueMasterAndIssueDetails InventoryIssueMasterAndIssueDetailsDTO { get; set; }

        int InventoryIssueMasterID { get; set; }
        string TransactionDate { get; set; }
        string IssueNumber { get; set; }
        int IssueFromLocationID { get; set; }
        int IssueToLocationID { get; set; }

        int InventoryIssueDetailID { get; set; }
        int ItemID { get; set; }
        decimal AvailbleQuantity { get; set; }


        //-------------------------Common Property----------------------------------------------------------------

        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }

    }
}
