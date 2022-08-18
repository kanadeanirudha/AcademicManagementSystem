
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{ 
     public class InventoryItemCategoryMasterViewModel : IInventoryItemCategoryMasterViewModel
    {

        public InventoryItemCategoryMasterViewModel()
        {
            InventoryItemCategoryMasterDTO = new InventoryItemCategoryMaster();
        }

        public InventoryItemCategoryMaster InventoryItemCategoryMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null && InventoryItemCategoryMasterDTO.ID > 0) ? InventoryItemCategoryMasterDTO.ID : new int();
            }
            set
            {
                InventoryItemCategoryMasterDTO.ID = value;
            }
        }

       
       // [Display(Name = "DisplayName_CountryName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CountryNameRequired")]
        [Required(ErrorMessage = "Category Name should not be blank.")]
        [Display(Name = "Category Name")]
        public string CategoryDescription
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null) ? InventoryItemCategoryMasterDTO.CategoryDescription : string.Empty;
            }
            set
            {
                InventoryItemCategoryMasterDTO.CategoryDescription = value;
            }
        }

       // [Display(Name = "DisplayName_CountryCode", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ContryCodeRequired")]
        [Required(ErrorMessage = "Category Code should not be blank.")]
        [Display(Name = "Category Code")]
        public string CategoryCode
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null) ? InventoryItemCategoryMasterDTO.CategoryCode : string.Empty;
            }
            set
            {
                InventoryItemCategoryMasterDTO.CategoryCode = value;
            }
        }

        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null) ? InventoryItemCategoryMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryItemCategoryMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null && InventoryItemCategoryMasterDTO.CreatedBy > 0) ? InventoryItemCategoryMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryItemCategoryMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null) ? InventoryItemCategoryMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryItemCategoryMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null) ? InventoryItemCategoryMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryItemCategoryMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime  ModifiedDate
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null) ? InventoryItemCategoryMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryItemCategoryMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null ) ? InventoryItemCategoryMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryItemCategoryMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime  DeletedDate
        {
            get
            {
                return (InventoryItemCategoryMasterDTO != null )?  InventoryItemCategoryMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryItemCategoryMasterDTO.DeletedDate = value;
            }
        }

       
        public string errorMessage { get; set; }
    }
}

