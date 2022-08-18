using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryDayEndJobViewModel : IInventoryDayEndJobViewModel
    {

        public InventoryDayEndJobViewModel()
        {
            InventoryDayEndJobDTO = new InventoryDayEndJob();
        }

        public InventoryDayEndJob InventoryDayEndJobDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (InventoryDayEndJobDTO != null && InventoryDayEndJobDTO.ID > 0) ? InventoryDayEndJobDTO.ID : new int();
            }
            set
            {
                InventoryDayEndJobDTO.ID = value;
            }
        }


        public Int16 AccBalsheetMstID
        {
            get
            {
                return (InventoryDayEndJobDTO != null && InventoryDayEndJobDTO.AccBalsheetMstID > 0) ? InventoryDayEndJobDTO.AccBalsheetMstID : new Int16();
            }
            set
            {
                InventoryDayEndJobDTO.AccBalsheetMstID = value;
            }
        }
        [Required(ErrorMessage = "Timezone should not be blank.")]
        [Display(Name = "Timezone")]
        public string Timezone
        {
            get
            {
                return (InventoryDayEndJobDTO != null) ? InventoryDayEndJobDTO.Timezone : string.Empty;
            }
            set
            {
                InventoryDayEndJobDTO.Timezone = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryDayEndJobDTO != null) ? InventoryDayEndJobDTO.IsDeleted : false;
            }
            set
            {
                InventoryDayEndJobDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryDayEndJobDTO != null && InventoryDayEndJobDTO.CreatedBy > 0) ? InventoryDayEndJobDTO.CreatedBy : new int();
            }
            set
            {
                InventoryDayEndJobDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryDayEndJobDTO != null) ? InventoryDayEndJobDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryDayEndJobDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryDayEndJobDTO != null) ? InventoryDayEndJobDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryDayEndJobDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryDayEndJobDTO != null) ? InventoryDayEndJobDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryDayEndJobDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryDayEndJobDTO != null) ? InventoryDayEndJobDTO.DeletedBy : new int();
            }
            set
            {
                InventoryDayEndJobDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryDayEndJobDTO != null) ? InventoryDayEndJobDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryDayEndJobDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        public int Status
        {
            get
            {
                return (InventoryDayEndJobDTO != null && InventoryDayEndJobDTO.Status > 0) ? InventoryDayEndJobDTO.Status : new int();
            }
            set
            {
                InventoryDayEndJobDTO.Status = value;
            }
        }
    }
}

