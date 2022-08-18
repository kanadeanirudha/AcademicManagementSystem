using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{ 
     public class InventoryWeighingDataViewModel : IInventoryWeighingDataViewModel
    {

        public InventoryWeighingDataViewModel()
        {
            InventoryWeighingDataDTO = new InventoryWeighingData();
        }

        public InventoryWeighingData InventoryWeighingDataDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (InventoryWeighingDataDTO != null && InventoryWeighingDataDTO.ID > 0) ? InventoryWeighingDataDTO.ID : new int();
            }
            set
            {
                InventoryWeighingDataDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Center Code should not be blank.")]
        [Display(Name = "Center Code")]
        public string CentreCode
        {
            get
            {
                return (InventoryWeighingDataDTO != null) ? InventoryWeighingDataDTO.CentreCode : string.Empty;
            }
            set
            {
                InventoryWeighingDataDTO.CentreCode = value;
            }
        }

        [Required(ErrorMessage = "Machine Code should not be blank.")]
        [Display(Name = "Machine Code")]
        public string MachineCode
        {
            get
            {
                return (InventoryWeighingDataDTO != null) ? InventoryWeighingDataDTO.MachineCode : string.Empty;
            }
            set
            {
                InventoryWeighingDataDTO.MachineCode = value;
            }
        }
        
        [Required(ErrorMessage = "Weight should not be blank.")]
        [Display(Name = "Weight")]
        public decimal Weight
        {
            get
            {
                
                     return (InventoryWeighingDataDTO != null && InventoryWeighingDataDTO.Weight > 0) ? InventoryWeighingDataDTO.Weight : new decimal();
            }
            set
            {
                InventoryWeighingDataDTO.Weight = value;
            }
        }
        [Display(Name = "IsActive")]
        public bool IsActive  
        {
            get
            {
                return (InventoryWeighingDataDTO != null) ? InventoryWeighingDataDTO.IsActive : false;
            }
            set
            {
                InventoryWeighingDataDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryWeighingDataDTO != null) ? InventoryWeighingDataDTO.IsDeleted : false;
            }
            set
            {
                InventoryWeighingDataDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryWeighingDataDTO != null && InventoryWeighingDataDTO.CreatedBy > 0) ? InventoryWeighingDataDTO.CreatedBy : new int();
            }
            set
            {
                InventoryWeighingDataDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryWeighingDataDTO != null) ? InventoryWeighingDataDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryWeighingDataDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryWeighingDataDTO != null) ? InventoryWeighingDataDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryWeighingDataDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime  ModifiedDate
        {
            get
            {
                return (InventoryWeighingDataDTO != null) ? InventoryWeighingDataDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryWeighingDataDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryWeighingDataDTO != null ) ? InventoryWeighingDataDTO.DeletedBy : new int();
            }
            set
            {
                InventoryWeighingDataDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime  DeletedDate
        {
            get
            {
                return (InventoryWeighingDataDTO != null )?  InventoryWeighingDataDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryWeighingDataDTO.DeletedDate = value;
            }
        }

       
        public string errorMessage { get; set; }
    }
}

