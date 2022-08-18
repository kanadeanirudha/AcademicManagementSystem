using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IInventoryIssueMasterAndDetailsViewModel
    {
        InventoryIssueMasterAndDetails InventoryIssueMasterAndDetailsDTO { get; set; }
        //---------------------------------------IssueMaster-----------------------------
        int IssueMasterID
        {
            get;
            set;
        }
        int IssueFromLocationID
        {
            get;
            set;
        }
        int IssueToLocationID
        {
            get;
            set;
        }
        int AccountSessionID
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string UnitCode
        {
            get;
            set;
        }
        string ParameterXml
        {
            get;
            set;
        }
        int UnitID
        {
            get;
            set;
        }
        string ItemName
        {
            get;
            set;
        }
        string IssueFromLocationName
        {
            get;
            set;
        }
        string IssueToLocationName
        {
            get;
            set;
        }
        string TransactionDate
        {
            get;
            set;
        }
        string IssueNumber
        {
            get;
            set;
        }

        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }

        //--------------------------------------IssueDetails------------------------------
     
        int ItemID
        {
            get;
            set;
        }

        decimal Quantity
        {
            get;
            set;
        }
        decimal CurrentStockQuantity
        {
            get;
            set;
        }

        string errorMessage { get; set; }
        string SelectedBalanceSheet { get; set; }
    }
}
