using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryLocationMaster_1ViewModel : IInventoryLocationMaster_1ViewModel
    {

        public InventoryLocationMaster_1ViewModel()
        {
            InventoryLocationMaster_1DTO = new InventoryLocationMaster_1();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
               ListInventoryLocationMaster = new List<InventoryLocationMaster_1>();
 
        }


        public InventoryLocationMaster_1 InventoryLocationMaster_1DTO
        {
            get;
            set;
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
         public List<InventoryLocationMaster_1> ListInventoryLocationMaster { get; set; }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
           

        public int ID
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null && InventoryLocationMaster_1DTO.ID > 0) ? InventoryLocationMaster_1DTO.ID : new int();
            }
            set
            {
                InventoryLocationMaster_1DTO.ID = value;
            }
        }
        public string CentreName
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {


            get;
            set;

        }
        [Required(ErrorMessage = "Location ID should not be blank.")]
        [Display(Name = " Location ID")]
        public int IssueFromLocationID
        {

            get
            {
                return (InventoryLocationMaster_1DTO != null && InventoryLocationMaster_1DTO.IssueFromLocationID > 0) ? InventoryLocationMaster_1DTO.IssueFromLocationID : new int();
            }
            set
            {
                InventoryLocationMaster_1DTO.IssueFromLocationID = value;
            }
        }

        [Display(Name = "Balancesheet ID")]
        public int AccBalanceSheetID
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null && InventoryLocationMaster_1DTO.AccBalanceSheetID > 0) ? InventoryLocationMaster_1DTO.AccBalanceSheetID : new int();
            }
            set
            {
                InventoryLocationMaster_1DTO.AccBalanceSheetID = value;
            }
        }

        [Required(ErrorMessage = "Sub Location Name Should Not be Blank")]
        [Display(Name = "Sub Location Name ")]
        public string LocationName
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null) ? InventoryLocationMaster_1DTO.LocationName : string.Empty;
            }
            set
            {
                InventoryLocationMaster_1DTO.LocationName = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null) ? InventoryLocationMaster_1DTO.IsDeleted : false;
            }
            set
            {
                InventoryLocationMaster_1DTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null && InventoryLocationMaster_1DTO.CreatedBy > 0) ? InventoryLocationMaster_1DTO.CreatedBy : new int();
            }
            set
            {
                InventoryLocationMaster_1DTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null) ? InventoryLocationMaster_1DTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryLocationMaster_1DTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null) ? InventoryLocationMaster_1DTO.ModifiedBy : new int();
            }
            set
            {
                InventoryLocationMaster_1DTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null) ? InventoryLocationMaster_1DTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryLocationMaster_1DTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null) ? InventoryLocationMaster_1DTO.DeletedBy : new int();
            }
            set
            {
                InventoryLocationMaster_1DTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryLocationMaster_1DTO != null) ? InventoryLocationMaster_1DTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryLocationMaster_1DTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

