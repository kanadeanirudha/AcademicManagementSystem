
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{ 
     public class InventoryRateMarkDownMasterAndDetailsViewModel : IInventoryRateMarkDownMasterAndDetailsViewModel
    {

        public InventoryRateMarkDownMasterAndDetailsViewModel()
        {
            InventoryRateMarkDownMasterAndDetailsDTO = new InventoryRateMarkDownMasterAndDetails();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetCategoryCode = new List<InventoryItemCategoryMaster>();
 
        }

        public InventoryRateMarkDownMasterAndDetails InventoryRateMarkDownMasterAndDetailsDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.ID > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.ID : new Int64();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.ID = value;
            }
        }

        public string ItemName
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.ItemName = value;
            }
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }


       
        public string CentreName
        {
            get;
            set;
        }
        [Required(ErrorMessage = " Selected Centre Code should not be blank.")]
        [Display(Name = "Selected Centre Code ")]
        public string SelectedCentreCode
        {


            get;
            set;

        }
        [Required(ErrorMessage = "Center Code  should not be blank.")]
        [Display(Name = "Center Code")]
        public string CenterCode
        {


            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.CentreCode = value;
            }

        }
       
        [Required(ErrorMessage = "Transaction Date  should not be blank.")]
        [Display(Name = "Transaction Date")]
        public string  TransactionDate
        {


           get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.TransactionDate = value;
            }

        }

        [Required(ErrorMessage = "Rate MarkDown Amount should not be blank.")]
        [Display(Name = "Rate MarkDown Amount")]
        public decimal RateMarkDownAmount
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownAmount > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownAmount : new decimal();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownAmount = value;
            }
        }

        [Required(ErrorMessage = "BalanceSheet ID should not be blank.")]
        [Display(Name = "BalanceSheet ID")]
        public Int16 BalanceSheetID
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.BalanceSheetID > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.BalanceSheetID : new Int16();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.BalanceSheetID = value;
            }
        }
        [Required(ErrorMessage = "Rate MarkDown Detail ID should not be blank.")]
        [Display(Name = "Rate MarkDown Detail ID")]
        public Int64 RateMarkDownDetailID
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownDetailID > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownDetailID : new Int64();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownDetailID = value;
            }
        }
        [Required(ErrorMessage = "Rate MarkDown Master ID should not be blank.")]
        [Display(Name = "Rate MarkDown Master ID")]
        public Int64 RateMarkDownMasterID
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownMasterID > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownMasterID : new Int64();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.RateMarkDownMasterID = value;
            }
        }
        [Required(ErrorMessage = "Item ID should not be blank.")]
        [Display(Name = "Item ID")]
        public int ItemID
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.ItemID > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.ItemID : new int();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.ItemID = value;
            }
        }
        [Required(ErrorMessage = "Rate Decrease By Percentage should not be blank.")]
        [Display(Name = "Rate Decrease By Percentage")]
        public decimal RateDecreaseByPercentage
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.RateDecreaseByPercentage > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.RateDecreaseByPercentage : new decimal();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.RateDecreaseByPercentage = value;
            }
        }
        public string CategoryDescription
        {
            get;
            set;
        }
        public string CategoryCode
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetCategoryCodeItems
        {
            get
            {
                return new SelectList(ListGetCategoryCode, "CategoryCode", "CategoryDescription");
            }
        }
        public List<InventoryItemCategoryMaster> ListGetCategoryCode
        {
            get;
            set;
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null && InventoryRateMarkDownMasterAndDetailsDTO.CreatedBy > 0) ? InventoryRateMarkDownMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime  ModifiedDate
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null ) ? InventoryRateMarkDownMasterAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime  DeletedDate
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null )?  InventoryRateMarkDownMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.DeletedDate = value;
            }
        }

       
        public string errorMessage { get; set; }
        public string SelectedXml
        {
            get
            {
                return (InventoryRateMarkDownMasterAndDetailsDTO != null) ? InventoryRateMarkDownMasterAndDetailsDTO.SelectedXml : string.Empty;
            }
            set
            {
                InventoryRateMarkDownMasterAndDetailsDTO.SelectedXml = value;
            }
        }

    }
}

