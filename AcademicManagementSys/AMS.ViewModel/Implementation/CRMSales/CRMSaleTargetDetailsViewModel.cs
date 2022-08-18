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
    public class CRMSaleTargetDetailsViewModel : ICRMSaleTargetDetailsViewModel
    {

        public CRMSaleTargetDetailsViewModel()
        {
            CRMSaleTargetDetailsDTO = new CRMSaleTargetDetails();
        }
        //CRMSaleTargetGroupWise
        public CRMSaleTargetDetails CRMSaleTargetDetailsDTO
        {
            get;
            set;
        }
        public Int16 CRMSaleTargetGroupWiseID
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.CRMSaleTargetGroupWiseID : new Int16();
            }
            set
            {
                CRMSaleTargetDetailsDTO.CRMSaleTargetGroupWiseID = value;
            }
        }
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Please select group")]
        public int CRMSaleGroupMasterID
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null && CRMSaleTargetDetailsDTO.CRMSaleGroupMasterID > 0) ? CRMSaleTargetDetailsDTO.CRMSaleGroupMasterID : new int();
            }
            set
            {
                CRMSaleTargetDetailsDTO.CRMSaleGroupMasterID = value;
            }
        }
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Group name should not be blank")]
        public string GroupName
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.GroupName : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.GroupName = value;
            }
        }
        [Display(Name = "Target Type")]
        [Required(ErrorMessage = "Please select target type")]
        public Int16 CRMSaleTargetTypeId
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.CRMSaleTargetTypeId : new Int16();
            }
            set
            {
                CRMSaleTargetDetailsDTO.CRMSaleTargetTypeId = value;
            }
        }
        [Display(Name = "Target Type")]
        public string TargetType
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.TargetType : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.TargetType = value;
            }
        }
        [Display(Name = "Target Value")]
        [Required(ErrorMessage = "Target Value should not be blank")]
        public Int64 TargetValue
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.TargetValue : new Int64();
            }
            set
            {
                CRMSaleTargetDetailsDTO.TargetValue = value;
            }
        }
        [Display(Name = "From Date")]
        [Required(ErrorMessage = "From Date should not be blank")]
        public string FromDate
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.FromDate : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.FromDate = value;
            }
        }

        //CRMSaleTargetException
        public Int16 CRMSaleTargetExceptionID
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.CRMSaleTargetExceptionID : new Int16();
            }
            set
            {
                CRMSaleTargetDetailsDTO.CRMSaleTargetExceptionID = value;
            }
        }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Please select Employee")]
        public int EmployeeId
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.EmployeeId : new int();
            }
            set
            {
                CRMSaleTargetDetailsDTO.EmployeeId = value;
            }
        }
        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.EmployeeName : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.EmployeeName = value;
            }
        }
        [Display(Name = "Department Name")]
        public string DepartmentName
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.DepartmentName : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.DepartmentName = value;
            }
        }
        [Display(Name = "Employee Designation")]
        public string EmployeeDesignation
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.EmployeeDesignation : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.EmployeeDesignation = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.TransactionDate : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.TransactionDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.UptoDate : String.Empty;
            }
            set
            {
                CRMSaleTargetDetailsDTO.UptoDate = value;
            }
        }
        public bool IsCurrent
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.IsCurrent : false;
            }
            set
            {
                CRMSaleTargetDetailsDTO.IsCurrent = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.IsDeleted : false;
            }
            set
            {
                CRMSaleTargetDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null && CRMSaleTargetDetailsDTO.CreatedBy > 0) ? CRMSaleTargetDetailsDTO.CreatedBy : new int();
            }
            set
            {
                CRMSaleTargetDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMSaleTargetDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null && CRMSaleTargetDetailsDTO.ModifiedBy.HasValue) ? CRMSaleTargetDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                CRMSaleTargetDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null && CRMSaleTargetDetailsDTO.ModifiedDate.HasValue) ? CRMSaleTargetDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMSaleTargetDetailsDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.DeletedBy : new int();
            }
            set
            {
                CRMSaleTargetDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null) ? CRMSaleTargetDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMSaleTargetDetailsDTO.DeletedDate = value;
            }
        }

      
        public string errorMessage { get; set; }

        [Display(Name = "Period Type")]
        [Required(ErrorMessage = "Please select period type")]
        public int GeneralPeriodTypeMasterID
        {
            get
            {
                return (CRMSaleTargetDetailsDTO != null && CRMSaleTargetDetailsDTO.GeneralPeriodTypeMasterID > 0) ? CRMSaleTargetDetailsDTO.GeneralPeriodTypeMasterID : new int();
            }
            set
            {
                CRMSaleTargetDetailsDTO.GeneralPeriodTypeMasterID = value;
            }
        }



    }
}

