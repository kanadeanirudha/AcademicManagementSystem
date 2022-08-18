
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AMS.ViewModel
{
    public class InventoryMachineMasterViewModel : IInventoryMachineMasterViewModel
    {

        public InventoryMachineMasterViewModel()
        {
            InventoryMachineMasterDTO = new InventoryMachineMaster();
            GetInventoryMachineCounterApplicableList = new List<InventoryMachineMaster>();
            
        }
        public List<InventoryMachineMaster> GetInventoryMachineCounterApplicableList { get; set; }

        public IEnumerable<SelectListItem> GetInventoryMachineCounterApplicableListitems
        {
            get
            {
                return new SelectList(GetInventoryMachineCounterApplicableList, "MachineCode","MachineCode");
            }
        }
        public InventoryMachineMaster InventoryMachineMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (InventoryMachineMasterDTO != null && InventoryMachineMasterDTO.ID > 0) ? InventoryMachineMasterDTO.ID : new int();
            }
            set
            {
                InventoryMachineMasterDTO.ID = value;
            }
        }


        // [Display(Name = "DisplayName_CountryName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CountryNameRequired")]
        [Required(ErrorMessage = "Machine Name should not be blank.")]
        [Display(Name = "Machine Name")]
        public string MachineName
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.MachineName : string.Empty;
            }
            set
            {
                InventoryMachineMasterDTO.MachineName = value;
            }
        }

        // [Display(Name = "DisplayName_CountryCode", ResourceType = typeof(Resources))]
        // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ContryCodeRequired")]
        [Required(ErrorMessage = "Machine Code should not be blank.")]
        [Display(Name = "Machine Code")]
        public string MachineCode
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.MachineCode : string.Empty;
            }
            set
            {
                InventoryMachineMasterDTO.MachineCode = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryMachineMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryMachineMasterDTO != null && InventoryMachineMasterDTO.CreatedBy > 0) ? InventoryMachineMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryMachineMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryMachineMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryMachineMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryMachineMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryMachineMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryMachineMasterDTO != null) ? InventoryMachineMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryMachineMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

