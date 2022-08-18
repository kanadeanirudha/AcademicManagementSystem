using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{ 
     public class InventoryOpeningBalanceViewModel : IInventoryOpeningBalanceViewModel
    {

        public InventoryOpeningBalanceViewModel()
        {
            InventoryOpeningBalanceDTO = new InventoryOpeningBalance();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetCategoryCode = new List<InventoryItemCategoryMaster>();
 
        }

        public InventoryOpeningBalance InventoryOpeningBalanceDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public AccountSessionMaster AccountSessionMasterDTO { get; set; }
        public int ID
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.ID > 0) ? InventoryOpeningBalanceDTO.ID : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.ID = value;
            }
        }

        public string ItemName
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null) ? InventoryOpeningBalanceDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryOpeningBalanceDTO.ItemName = value;
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
        //[Required(ErrorMessage = "Center Code  should not be blank.")]
        //[Display(Name = "Center Code")]
        //public string CenterCode
        //{


        //    get
        //    {
        //        return (InventoryOpeningBalanceDTO != null) ? InventoryOpeningBalanceDTO.CentreCode : string.Empty;
        //    }
        //    set
        //    {
        //        InventoryOpeningBalanceDTO.CentreCode = value;
        //    }

        //}
       
        [Required(ErrorMessage = "Transaction Date  should not be blank.")]
        [Display(Name = "Transaction Date")]
        public string  TransactionDate
        {


           get
            {
                return (InventoryOpeningBalanceDTO != null) ? InventoryOpeningBalanceDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryOpeningBalanceDTO.TransactionDate = value;
            }

        }
        public decimal OpeningAmount
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.OpeningAmount > 0) ? InventoryOpeningBalanceDTO.OpeningAmount : new decimal();
            }
            set
            {
                InventoryOpeningBalanceDTO.OpeningAmount = value;
            }
        }
        [Required(ErrorMessage = "BalanceSheet ID should not be blank.")]
        [Display(Name = "BalanceSheet ID")]
        public Int16 BalanceSheetID
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.BalanceSheetID > 0) ? InventoryOpeningBalanceDTO.BalanceSheetID : new Int16();
            }
            set
            {
                InventoryOpeningBalanceDTO.BalanceSheetID = value;
            }
        }
       
        
        [Required(ErrorMessage = "Item ID should not be blank.")]
        [Display(Name = "Item ID")]
        public int ItemID
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.ItemID > 0) ? InventoryOpeningBalanceDTO.ItemID : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.ItemID = value;
            }
        }
        public int StockMasterID
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.StockMasterID > 0) ? InventoryOpeningBalanceDTO.StockMasterID : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.StockMasterID = value;
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
                return (InventoryOpeningBalanceDTO != null) ? InventoryOpeningBalanceDTO.IsDeleted : false;
            }
            set
            {
                InventoryOpeningBalanceDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.CreatedBy > 0) ? InventoryOpeningBalanceDTO.CreatedBy : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null) ? InventoryOpeningBalanceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryOpeningBalanceDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null) ? InventoryOpeningBalanceDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime  ModifiedDate
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null) ? InventoryOpeningBalanceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryOpeningBalanceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null ) ? InventoryOpeningBalanceDTO.DeletedBy : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime  DeletedDate
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null )?  InventoryOpeningBalanceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryOpeningBalanceDTO.DeletedDate = value;
            }
        }
        public string SelectedXml { get; set; }
        public string errorMessage { get; set; }
        public string SessionName { get; set; }
        public string LocationName { get; set; }
        public bool StatusFlag
        {
            get;
            set;
        }
        public int SessionID
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.SessionID > 0) ? InventoryOpeningBalanceDTO.SessionID : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.SessionID = value;
            }
        }
        public int LocationID
        {
            get
            {
                return (InventoryOpeningBalanceDTO != null && InventoryOpeningBalanceDTO.LocationID > 0) ? InventoryOpeningBalanceDTO.LocationID : new int();
            }
            set
            {
                InventoryOpeningBalanceDTO.LocationID = value;
            }
        }
    }
}

