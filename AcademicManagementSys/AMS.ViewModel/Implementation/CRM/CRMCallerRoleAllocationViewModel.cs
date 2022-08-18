using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AMS.ViewModel
{
    public class CRMCallerRoleAllocationViewModel : ICRMCallerRoleAllocationViewModel
    {

        public CRMCallerRoleAllocationViewModel()
        {
            CRMCallerRoleAllocationDTO = new CRMCallerRoleAllocation();
            CRMAdmineRoleCodelist = new List<CRMCallerRoleAllocation>();
        }
        public List<CRMCallerRoleAllocation> CRMAdmineRoleCodelist
        {
            get;
            set;
        }
       
        public CRMCallerRoleAllocation CRMCallerRoleAllocationDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null && CRMCallerRoleAllocationDTO.ID > 0) ? CRMCallerRoleAllocationDTO.ID : new Int16();
            }
            set
            {
                CRMCallerRoleAllocationDTO.ID = value;
            }
        }

        [Display(Name="Role Code")]
        [Required(ErrorMessage="Role code should be specified")]
        public int AdminRoleMasterID
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null && CRMCallerRoleAllocationDTO.AdminRoleMasterID > 0) ? CRMCallerRoleAllocationDTO.AdminRoleMasterID : new int();
            }
            set
            {
                CRMCallerRoleAllocationDTO.AdminRoleMasterID = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null) ? CRMCallerRoleAllocationDTO.IsActive : false;
            }
            set
            {
                CRMCallerRoleAllocationDTO.IsActive = value;
            }
        }

          [Display(Name = "Role Code")]
        public string AdminRoleCode
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null) ? CRMCallerRoleAllocationDTO.AdminRoleCode : String.Empty;
            }
            set
            {
                CRMCallerRoleAllocationDTO.AdminRoleCode = value;
            }
        }
       
     
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null) ? CRMCallerRoleAllocationDTO.IsDeleted : false;
            }
            set
            {
                CRMCallerRoleAllocationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null && CRMCallerRoleAllocationDTO.CreatedBy > 0) ? CRMCallerRoleAllocationDTO.CreatedBy : new int();
            }
            set
            {
                CRMCallerRoleAllocationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null) ? CRMCallerRoleAllocationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMCallerRoleAllocationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null && CRMCallerRoleAllocationDTO.ModifiedBy.HasValue) ? CRMCallerRoleAllocationDTO.ModifiedBy : new int();
            }
            set
            {
                CRMCallerRoleAllocationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null && CRMCallerRoleAllocationDTO.ModifiedDate.HasValue) ? CRMCallerRoleAllocationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMCallerRoleAllocationDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null) ? CRMCallerRoleAllocationDTO.DeletedBy : new int();
            }
            set
            {
                CRMCallerRoleAllocationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMCallerRoleAllocationDTO != null) ? CRMCallerRoleAllocationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMCallerRoleAllocationDTO.DeletedDate = value;
            }
        }

        [Required(ErrorMessage = "Select Call Type")]
        public string CallType
        {
            get;
            set;
        }
       

        public string errorMessage { get; set; }
      
        
       
        
    }
}

