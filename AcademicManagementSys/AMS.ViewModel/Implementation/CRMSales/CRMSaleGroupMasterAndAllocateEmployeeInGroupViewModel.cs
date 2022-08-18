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
    public class CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel : ICRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel
    {

        public CRMSaleGroupMasterAndAllocateEmployeeInGroupViewModel()
        {
            CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO = new CRMSaleGroupMasterAndAllocateEmployeeInGroup();
        }

        public CRMSaleGroupMasterAndAllocateEmployeeInGroup CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO
        {
            get;
            set;
        }
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Please select group")]
        public int CRMSaleGroupMasterID
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null && CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleGroupMasterID > 0) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleGroupMasterID : new int();
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleGroupMasterID = value;
            }
        }
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Group name should not be blank")]
        public string GroupName
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GroupName : String.Empty;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GroupName = value;
            }
        }
        //CRMSaleAllocateEmployeeInGroup

        public int CRMSaleAllocateEmployeeInGroupID
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleAllocateEmployeeInGroupID : new int();
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CRMSaleAllocateEmployeeInGroupID = value;
            }
        }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Please select Employee")]
        public int EmployeeId
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeId : new int();
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeId = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeName : String.Empty;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeName = value;
            }
        }
        [Display(Name = "Department Name")]
        public string DepartmentName
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.DepartmentName : String.Empty;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.DepartmentName = value;
            }
        }
        [Display(Name = "Employee Designation")]
        public string EmployeeDesignation
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeDesignation : String.Empty;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.EmployeeDesignation = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.TransactionDate : String.Empty;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.TransactionDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.UptoDate : String.Empty;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.UptoDate = value;
            }
        }
        public bool IsCurrent
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.IsCurrent : false;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.IsCurrent = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.IsDeleted : false;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null && CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CreatedBy > 0) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CreatedBy : new int();
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null && CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ModifiedBy.HasValue) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ModifiedBy : new int();
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null && CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ModifiedDate.HasValue) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.DeletedBy : new int();
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.DeletedDate = value;
            }
        }

        public string SelectedRMSaleGroupMasterID
        {
            get;
            set;
        }

        public string errorMessage { get; set; }

        public int GeneralGroupTypeAttributesId
        {
            get
            {
                return (CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO != null && CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GeneralGroupTypeAttributesId > 0) ? CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GeneralGroupTypeAttributesId : new int();
            }
            set
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupDTO.GeneralGroupTypeAttributesId = value;
            }
        }


    }
}

