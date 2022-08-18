
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{ 
     public class InventoryCounterApplicableDetailsViewModel : IInventoryCounterApplicableDetailsViewModel
    {

        public InventoryCounterApplicableDetailsViewModel()
        {
            InventoryCounterApplicableDetailsDTO = new InventoryCounterApplicableDetails();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            InventoryCounterApplicableDetailsList = new List<InventoryCounterApplicableDetails>();
            //InventoryCounterApplicableMachineListList = new List<InventoryCounterApplicableDetails>();
            GetInventoryMachineCounterApplicableList= new List<InventoryMachineMaster>();
        }


        public List<InventoryCounterApplicableDetails> InventoryCounterApplicableDetailsList { get; set; }

        public List<InventoryMachineMaster> GetInventoryMachineCounterApplicableList { get; set; }

        public IEnumerable<SelectListItem> GetInventoryMachineCounterApplicableListItems   
        {
            get
            {
                return new SelectList(GetInventoryMachineCounterApplicableList, "ID", "MachineCode");
            }
        }


        public InventoryCounterApplicableDetails InventoryCounterApplicableDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null ) ? InventoryCounterApplicableDetailsDTO.ID : new int();
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.ID = value;
            }
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {


            get;
            set;

        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }


        [Display(Name = "Counter ID")]
        public int InvCounterMasterID
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null && InventoryCounterApplicableDetailsDTO.InvCounterMasterID> 0) ? InventoryCounterApplicableDetailsDTO.InvCounterMasterID : new int();
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.InvCounterMasterID = value;
            }
        }

        [Required(ErrorMessage = "Please select Machine Code")]
        [Display(Name = "Machine Code")]
        public int  InvMachineMasterID
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null && InventoryCounterApplicableDetailsDTO.InvMachineMasterID > 0) ? InventoryCounterApplicableDetailsDTO.InvMachineMasterID : new int();
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.InvMachineMasterID = value;
            }
           
        }
        [Display(Name = "Balancesheet ID")]
        public Int16 AccBalsheetMstID
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null && InventoryCounterApplicableDetailsDTO.AccBalsheetMstID > 0) ? InventoryCounterApplicableDetailsDTO.AccBalsheetMstID : new Int16(); ;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.AccBalsheetMstID = value;
            }

        }

        [Required(ErrorMessage = "Please select Machine Code")]
        [Display(Name = "Machine Code")]
        public string MachineCode
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null) ? InventoryCounterApplicableDetailsDTO.MachineCode : string.Empty;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.MachineCode = value;
            }
        }

      
        [Display(Name = "Machine Name")]
        public string MachineName
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null) ? InventoryCounterApplicableDetailsDTO.MachineName : string.Empty;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.MachineName = value;
            }
        }

     
        [Display(Name = "Counter name")]
        public string CounterName
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null) ? InventoryCounterApplicableDetailsDTO.CounterName : string.Empty;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.CounterName = value;
            }
        }

        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null) ? InventoryCounterApplicableDetailsDTO.IsDeleted : false;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null && InventoryCounterApplicableDetailsDTO.CreatedBy > 0) ? InventoryCounterApplicableDetailsDTO.CreatedBy : new int();
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null) ? InventoryCounterApplicableDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null) ? InventoryCounterApplicableDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime  ModifiedDate
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null) ? InventoryCounterApplicableDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null ) ? InventoryCounterApplicableDetailsDTO.DeletedBy : new int();
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime  DeletedDate
        {
            get
            {
                return (InventoryCounterApplicableDetailsDTO != null )?  InventoryCounterApplicableDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterApplicableDetailsDTO.DeletedDate = value;
            }
        }

        //public IEnumerable<SelectListItem> InventoryCounterApplicableDetailsListItems
        //{
        //    get
        //    {
        //        return new SelectList(InventoryCounterApplicableDetailsList, "MachineCode");
        //    }
        //}

       
        public string errorMessage { get; set; }
    }
}

