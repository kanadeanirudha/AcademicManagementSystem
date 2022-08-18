using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryIssueMasterAndDetailsViewModel : IInventoryIssueMasterAndDetailsViewModel
    {
        public InventoryIssueMasterAndDetailsViewModel()
        {
            InventoryIssueMasterAndDetailsDTO = new InventoryIssueMasterAndDetails();
            InventoryLocationMasterFromList = new List<InventoryLocationMaster>();
            InventoryLocationMasterToList = new List<InventoryLocationMaster>();
        }
        public InventoryIssueMasterAndDetails InventoryIssueMasterAndDetailsDTO { get; set; }
        //---------------------------------------InventorySalesMaster-----------------------------
        public List<InventoryLocationMaster> InventoryLocationMasterFromList { get; set; }
        public List<InventoryLocationMaster> InventoryLocationMasterToList { get; set; }

        public IEnumerable<SelectListItem> InventoryLocationMasterFromListItems
        {
            get
            {
                return new SelectList(InventoryLocationMasterFromList, "ID", "LocationName");
            }
        }

        public IEnumerable<SelectListItem> InventoryLocationMasterToListItems
        {
            get
            {
                return new SelectList(InventoryLocationMasterToList, "ID", "LocationName");
            }
        }
        public int IssueMasterID
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.IssueMasterID > 0) ? InventoryIssueMasterAndDetailsDTO.IssueMasterID : new int();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.IssueMasterID = value;
            }
        }
        public int IssueFromLocationID
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.IssueFromLocationID > 0) ? InventoryIssueMasterAndDetailsDTO.IssueFromLocationID : new int();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.IssueFromLocationID = value;
            }
        }
        public int AccountSessionID
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.AccountSessionID > 0) ? InventoryIssueMasterAndDetailsDTO.AccountSessionID : new int();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.AccountSessionID = value;
            }
        }
        public int UnitID
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.UnitID > 0) ? InventoryIssueMasterAndDetailsDTO.UnitID : new int();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.UnitID = value;
            }
        }

        public int IssueToLocationID
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.IssueToLocationID > 0) ? InventoryIssueMasterAndDetailsDTO.IssueToLocationID : new int();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.IssueToLocationID = value;
            }
        }
        public string IssueFromLocationName
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.IssueFromLocationName : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.IssueFromLocationName = value;
            }
        }
        public string IssueToLocationName
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.IssueToLocationName : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.IssueToLocationName = value;
            }
        }
        public string ParameterXml
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.ParameterXml : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.ParameterXml = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.TransactionDate = value;
            }
        }
        public string IssueNumber
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.IssueNumber : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.IssueNumber = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.CentreCode = value;
            }
        }


        //public int BalanceSheetID
        //{
        //    get
        //    {
        //        return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.BalanceSheetID > 0) ? InventoryIssueMasterAndDetailsDTO.BalanceSheetID : new int();
        //    }
        //    set
        //    {
        //        InventoryIssueMasterAndDetailsDTO.BalanceSheetID = value;
        //    }
        //}

        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.CreatedBy > 0) ? InventoryIssueMasterAndDetailsDTO.CreatedBy : new short();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.ModifiedBy > 0) ? InventoryIssueMasterAndDetailsDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.DeletedBy > 0) ? InventoryIssueMasterAndDetailsDTO.DeletedBy : new short();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.DeletedDate = value;
            }
        }
        //--------------------------------------InventorySalesTransaction------------------------------
      
        [Display(Name = "Item Name")]
        public int ItemID
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.ItemID > 0) ? InventoryIssueMasterAndDetailsDTO.ItemID : new int();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.ItemID = value;
            }
        }
        [Display(Name = "Item Name")]
        public string ItemName
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.ItemName = value;
            }
        }
        [Display(Name = "Quantity")]
        public decimal Quantity
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.Quantity > 0) ? InventoryIssueMasterAndDetailsDTO.Quantity : new decimal();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.Quantity = value;
            }
        }
        [Display(Name = "Current Stock")]
        public decimal CurrentStockQuantity
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null && InventoryIssueMasterAndDetailsDTO.CurrentStockQuantity > 0) ? InventoryIssueMasterAndDetailsDTO.CurrentStockQuantity : new decimal();
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.CurrentStockQuantity = value;
            }
        }
        [Display(Name = "Unit Code")]
        public string UnitCode
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.UnitCode : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.UnitCode = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.errorMessage : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.errorMessage = value;
            }
        }
        public string SelectedBalanceSheet
        {
            get
            {
                return (InventoryIssueMasterAndDetailsDTO != null) ? InventoryIssueMasterAndDetailsDTO.SelectedBalanceSheet : string.Empty;
            }
            set
            {
                InventoryIssueMasterAndDetailsDTO.SelectedBalanceSheet = value;
            }
        }
    }
}
