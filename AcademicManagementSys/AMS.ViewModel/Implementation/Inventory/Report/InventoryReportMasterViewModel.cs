using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryReportMasterViewModel : IInventoryReportMasterViewModel
    {
        public InventoryReportMasterViewModel()
        {
            InventoryReportMasterDTO = new InventoryReportMaster();
           
            ListInventoryItemMaster = new List<InventoryItemMaster>();
            ListInventoryItemwiseConsumption = new List<InventoryReportMaster>();
            ListInventoryLocationMaster = new List<InventoryLocationMaster>();
            ListInventoryDumpAndShrink = new List<InventoryReportMaster>();
            ListInventoryBelowIndentReport = new List<InventoryReportMaster>();
            ListInventoryDailyItemRateChangeReport = new List<InventoryReportMaster>();
            ListInventoryItemwiseConsumptionReport = new List<InventoryReportMaster>();           
        }

        public InventoryReportMaster InventoryReportMasterDTO { get; set; }
       
        public List<InventoryItemMaster> ListInventoryItemMaster { get; set; }

        public List<InventoryReportMaster> ListInventoryItemwiseConsumption { get; set; }

        public List<InventoryLocationMaster> ListInventoryLocationMaster { get; set; }

        public List<InventoryReportMaster> ListInventoryDumpAndShrink { get; set; }

        public List<InventoryReportMaster> ListInventoryBelowIndentReport { get; set; }

        public List<InventoryReportMaster> ListInventoryDailyItemRateChangeReport { get; set; }

        public List<InventoryReportMaster> ListInventoryItemwiseConsumptionReport { get; set; }

        //For Html Report Header.
        public List<OrganisationStudyCentreMaster> ListInventoryReportHeader { get; set; }


//---------------------------------------------------------------------------------------------------------------------------//

        //public IEnumerable<SelectListItem> InventoryLocationMasterListItems
        //{
        //    get
        //    {
        //        return new SelectList(ListInventoryLocationMaster, "LocationID", "LocationName");
        //    }
        //}


 //--------------------------------------------------------------------------------------------------------------------------//
        

        [Display(Name = "From Date")]
       //[Required(ErrorMessage = "From Date should not be blank.")]
        public string FromDate
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.FromDate : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.FromDate = value;
            }
        }

        [Display(Name = "Upto Date")]
        //[Required(ErrorMessage = "Upto Date should not be blank.")]
        public string UptoDate
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.UptoDate : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.UptoDate = value;
            }
        }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name should not be blank.")]
        public string LocationName
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.LocationName : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.LocationName = value;
            }
        }

       [Display(Name="Location")]
        public int LocationID
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.LocationID > 0 )? InventoryReportMasterDTO.LocationID : new int();
            }
            set
            {
                InventoryReportMasterDTO.LocationID = value;
            }
        }

        [Display(Name = "Item Name")]
        [Required(ErrorMessage = "Item name should not be blank.")]
        public string ItemName
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.ItemName = value;
            }
        }
        [Display(Name = "Item Code")]
        [Required(ErrorMessage = "Item Code should not be blank.")]
        public string ItemCode
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.ItemCode : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.ItemCode = value;
            }
        }

        [Display(Name = "Current Rate")]
        [Required(ErrorMessage = "Current rate should not be blank.")]
        public decimal CurrentRate
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.CurrentRate > 0) ? InventoryReportMasterDTO.CurrentRate : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.CurrentRate = value;
            }
        }

        [Display(Name = "Previous Rate")]
        [Required(ErrorMessage = "Previous rate should not be blank.")]
        public decimal PreviousRate
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.PreviousRate > 0) ? InventoryReportMasterDTO.PreviousRate : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.PreviousRate = value;
            }
        }

        [Display(Name = "Dump Quantity")]
        [Required(ErrorMessage = "Dump quantity should not be blank.")]
        public decimal DumpQuantity
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.DumpQuantity > 0) ? InventoryReportMasterDTO.DumpQuantity : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.DumpQuantity = value;
            }
        }

        [Display(Name = "Shrink quantity")]
        [Required(ErrorMessage = "Shrink quantity should not be blank.")]
        public decimal ShrinkQuantity
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.ShrinkQuantity > 0) ? InventoryReportMasterDTO.ShrinkQuantity : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.ShrinkQuantity = value;
            }
        }


        [Display(Name = "Total Quantity")]
        [Required(ErrorMessage = "Total quantity should not be blank.")]
        public decimal TotalQuantity
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.TotalQuantity > 0) ? InventoryReportMasterDTO.TotalQuantity : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.TotalQuantity = value;
            }
        }
        [AllowHtml]
        public string ItemNameListXml
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.ItemNameListXml : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.ItemNameListXml = value;
            }
        }

        [AllowHtml]
        public string LocationNameListXml
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.LocationNameListXml : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.LocationNameListXml = value;
            }
        }

        [AllowHtml]
        public string XmlString3
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.XmlString3 : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.XmlString3 = value;
            }
        }

        public string InventoryReportMasterSearchWord
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.InventoryReportMasterSearchWord : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.InventoryReportMasterSearchWord = value;
            }
        }

        [Display(Name = "Account Session ")]
        [Required(ErrorMessage = "Account session should not be blank.")]
        public int AccountSessionID
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.AccountSessionID > 0) ? InventoryReportMasterDTO.AccountSessionID : new int();
            }
            set
            {
                InventoryReportMasterDTO.AccountSessionID = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool? IsDeleted
        {
            get
            {
                return InventoryReportMasterDTO.IsDeleted != null ? InventoryReportMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryReportMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int? CreatedBy
        {
            get
            {
                return (InventoryReportMasterDTO.CreatedBy != null && InventoryReportMasterDTO.CreatedBy > 0) ? InventoryReportMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryReportMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate
        {
            get
            {
                return (InventoryReportMasterDTO.CreatedDate != null) ? InventoryReportMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryReportMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return InventoryReportMasterDTO.ModifiedBy != null ? InventoryReportMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryReportMasterDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (InventoryReportMasterDTO.ModifiedDate != null && InventoryReportMasterDTO.ModifiedDate.HasValue) ? InventoryReportMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryReportMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.DeletedBy > 0) ? InventoryReportMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryReportMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (InventoryReportMasterDTO.DeletedDate != null && InventoryReportMasterDTO.DeletedDate.HasValue) ? InventoryReportMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryReportMasterDTO.DeletedDate = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.ErrorMessage != "") ? InventoryReportMasterDTO.ErrorMessage : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.ErrorMessage = value;
            }
        }

        public int AccountBalsheetMstID
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.AccountBalsheetMstID > 0) ? InventoryReportMasterDTO.AccountBalsheetMstID : new int();
            }
            set
            {
                InventoryReportMasterDTO.AccountBalsheetMstID = value;   
            }
        }


        public int ConsumptionCount
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.ConsumptionCount > 0) ? InventoryReportMasterDTO.ConsumptionCount : new int();
            }
            set
            {
                InventoryReportMasterDTO.ConsumptionCount = value;   
            }
        }
        public bool IsPosted
        {
            get
            {
                return (InventoryReportMasterDTO != null) ? InventoryReportMasterDTO.IsPosted : false;
            }
            set
            {
                InventoryReportMasterDTO.IsPosted = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.TransactionDate != "") ? InventoryReportMasterDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.TransactionDate = value;
            }

        }
        public decimal Quantity { get; set; }
        
        [Display(Name = "ItemID ")]
        public int ItemID
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.ItemID > 0) ? InventoryReportMasterDTO.ItemID : new int();
            }
            set
            {
                InventoryReportMasterDTO.ItemID = value;
            }
        }

        public string CategoryCode
        {
            get
            {
                return InventoryReportMasterDTO != null ? InventoryReportMasterDTO.CategoryCode : string.Empty;
            }
            set
            {
                InventoryReportMasterDTO.CategoryCode = value;
            }
        }

        public decimal PreviousSaleRate
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.PreviousSaleRate > 0) ? InventoryReportMasterDTO.PreviousSaleRate : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.PreviousSaleRate = value;
            }
        }

        public decimal TotalInwardQuantity
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.TotalInwardQuantity > 0) ? InventoryReportMasterDTO.TotalInwardQuantity : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.TotalInwardQuantity = value;
            }
        }

        public decimal TotalOutwardQuantity
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.TotalOutwardQuantity > 0) ? InventoryReportMasterDTO.TotalOutwardQuantity : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.TotalOutwardQuantity = value;
            }
        }

        public decimal TotalPurchaseQuantity
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.TotalPurchaseQuantity > 0) ? InventoryReportMasterDTO.TotalPurchaseQuantity : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.TotalPurchaseQuantity = value;
            }
        }

        public decimal OpeningBalance
        {
            get
            {
                return (InventoryReportMasterDTO != null && InventoryReportMasterDTO.OpeningBalance > 0) ? InventoryReportMasterDTO.OpeningBalance : new decimal();
            }
            set
            {
                InventoryReportMasterDTO.OpeningBalance = value;
            }
        }
    }
}
