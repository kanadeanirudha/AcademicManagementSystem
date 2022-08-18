
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryCounterMasterViewModel : IInventoryCounterMasterViewModel
    {

        public InventoryCounterMasterViewModel()
        {
            InventoryCounterMasterDTO = new InventoryCounterMaster();
        }

        public InventoryCounterMaster InventoryCounterMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (InventoryCounterMasterDTO != null && InventoryCounterMasterDTO.ID > 0) ? InventoryCounterMasterDTO.ID : new int();
            }
            set
            {
                InventoryCounterMasterDTO.ID = value;
            }
        }


        // [Display(Name = "DisplayName_CountryName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CountryNameRequired")]
        [Required(ErrorMessage = "Counter Name should not be blank.")]
        [Display(Name = "Counter Name")]
        public string CounterName
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.CounterName : string.Empty;
            }
            set
            {
                InventoryCounterMasterDTO.CounterName = value;
            }
        }

        // [Display(Name = "DisplayName_CountryCode", ResourceType = typeof(Resources))]
        // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ContryCodeRequired")]
        [Required(ErrorMessage = "Counter Code should not be blank.")]
        [Display(Name = "Counter Code")]
        public string CounterCode
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.CounterCode : string.Empty;
            }
            set
            {
                InventoryCounterMasterDTO.CounterCode = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryCounterMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryCounterMasterDTO != null && InventoryCounterMasterDTO.CreatedBy > 0) ? InventoryCounterMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryCounterMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryCounterMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryCounterMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryCounterMasterDTO != null) ? InventoryCounterMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

