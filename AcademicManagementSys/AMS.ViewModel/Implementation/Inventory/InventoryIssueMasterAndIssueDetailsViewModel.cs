using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryIssueMasterAndIssueDetailsViewModel : IInventoryIssueMasterAndIssueDetailsViewModel
    {
        public InventoryIssueMasterAndIssueDetailsViewModel()
        {
            InventoryIssueMasterAndIssueDetailsDTO = new InventoryIssueMasterAndIssueDetails();
            InventoryIssueItemAndDetailsList = new List<InventoryIssueMasterAndIssueDetails>();
        }
        public InventoryIssueMasterAndIssueDetails InventoryIssueMasterAndIssueDetailsDTO { get; set; }
        public List<InventoryIssueMasterAndIssueDetails> InventoryIssueItemAndDetailsList { get; set; }

        //-----------------------------------EntranceExamAvailableCentres Table Property-------------------------------//
        public int InventoryIssueMasterID
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.InventoryIssueMasterID > 0) ? InventoryIssueMasterAndIssueDetailsDTO.InventoryIssueMasterID : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.InventoryIssueMasterID = value;
            }
        }

        [Display(Name = "Transaction Date")]
        [Required(ErrorMessage = "Transaction date should not blank.")]
        public string TransactionDate
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.TransactionDate != "") ? InventoryIssueMasterAndIssueDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.TransactionDate = value;
            }
        }

        [Display(Name = "Issue number")]
        [Required(ErrorMessage = "Issue number should not blank.")]
        public string IssueNumber
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.IssueNumber != "") ? InventoryIssueMasterAndIssueDetailsDTO.IssueNumber : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IssueNumber = value;
            }
        }

        public int IssueFromLocationID
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.IssueFromLocationID > 0) ? InventoryIssueMasterAndIssueDetailsDTO.IssueFromLocationID : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IssueFromLocationID = value;
            }
        }

        public int IssueToLocationID
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.IssueToLocationID > 0) ? InventoryIssueMasterAndIssueDetailsDTO.IssueToLocationID : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IssueToLocationID = value;
            }
        }


        public int InventoryIssueDetailID
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.InventoryIssueDetailID > 0) ? InventoryIssueMasterAndIssueDetailsDTO.InventoryIssueDetailID : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.InventoryIssueDetailID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.ItemID > 0) ? InventoryIssueMasterAndIssueDetailsDTO.ItemID : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.ItemID = value;
            }
        }

        [Display(Name = "Available Quantity")]
        public decimal AvailbleQuantity
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.AvailbleQuantity > 0) ? InventoryIssueMasterAndIssueDetailsDTO.AvailbleQuantity : new decimal();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.AvailbleQuantity = value;
            }
        }


        //---------------------------------------------Comman Property.-----------------------------------------------------------------

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return InventoryIssueMasterAndIssueDetailsDTO.IsDeleted != null ? InventoryIssueMasterAndIssueDetailsDTO.IsDeleted : false;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO.CreatedBy != null && InventoryIssueMasterAndIssueDetailsDTO.CreatedBy > 0) ? InventoryIssueMasterAndIssueDetailsDTO.CreatedBy : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO.CreatedDate != null) ? InventoryIssueMasterAndIssueDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return InventoryIssueMasterAndIssueDetailsDTO.ModifiedBy != null ? InventoryIssueMasterAndIssueDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO.ModifiedDate != null && InventoryIssueMasterAndIssueDetailsDTO.ModifiedDate.HasValue) ? InventoryIssueMasterAndIssueDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.DeletedBy > 0) ? InventoryIssueMasterAndIssueDetailsDTO.DeletedBy : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO.DeletedDate != null && InventoryIssueMasterAndIssueDetailsDTO.DeletedDate.HasValue) ? InventoryIssueMasterAndIssueDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.DeletedDate = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.ErrorMessage != "") ? InventoryIssueMasterAndIssueDetailsDTO.ErrorMessage : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.ErrorMessage = value;
            }
        }


        //-------------------Extra Property--------------------------
        [Display(Name = "From Location ")]
        public string IssueFromLocationName
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.IssueFromLocationName != "") ? InventoryIssueMasterAndIssueDetailsDTO.IssueFromLocationName : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IssueFromLocationName = value;
            }
        }

        [Display(Name = "To Location ")]
        public string IssueToLocationName
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.IssueToLocationName != "") ? InventoryIssueMasterAndIssueDetailsDTO.IssueToLocationName : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IssueToLocationName = value;
            }
        }

        [Display(Name = "Item Name ")]
        public string ItemName
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.ItemName != "") ? InventoryIssueMasterAndIssueDetailsDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.ItemName = value;
            }
        }

        [Display(Name="Issue Quantity")]
        public decimal IssueQuantity
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.IssueQuantity > 0) ? InventoryIssueMasterAndIssueDetailsDTO.IssueQuantity : new decimal();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IssueQuantity = value;
            }
        }

        public int BalanceSheetID
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.BalanceSheetID > 0) ? InventoryIssueMasterAndIssueDetailsDTO.BalanceSheetID : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.BalanceSheetID = value;
            }
        }

        public string IssueDetails
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.IssueDetails != "") ? InventoryIssueMasterAndIssueDetailsDTO.IssueDetails : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.IssueDetails = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.CentreCode != "") ? InventoryIssueMasterAndIssueDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.CentreCode = value;
            }
        }
        public int AccountSessionID
        {
            get
            {
                return (InventoryIssueMasterAndIssueDetailsDTO != null && InventoryIssueMasterAndIssueDetailsDTO.AccountSessionID > 0) ? InventoryIssueMasterAndIssueDetailsDTO.AccountSessionID : new int();
            }
            set
            {
                InventoryIssueMasterAndIssueDetailsDTO.AccountSessionID = value;
            }
        }
    }
}
