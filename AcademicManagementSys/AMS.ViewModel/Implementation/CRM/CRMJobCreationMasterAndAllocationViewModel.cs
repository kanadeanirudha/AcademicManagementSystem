using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{  

    public class CRMJobCreationMasterAndAllocationViewModel : ICRMJobCreationMasterAndAllocationViewModel
    {
        public CRMJobCreationMasterAndAllocationViewModel()
        {
            CRMJobCreationMasterAndAllocationDTO = new CRMJobCreationMasterAndAllocation();
        }

        public CRMJobCreationMasterAndAllocation CRMJobCreationMasterAndAllocationDTO
        {
            get;
            set;
        }

        #region --------------CRMJobCreationMaster Fields--------------

        public int JobCreationMasterID
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.JobCreationMasterID : new int();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.JobCreationMasterID = value;
            }
        }

       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobNameRequired")]
        [Display(Name = "DisplayName_JobName", ResourceType = typeof(AMS.Common.Resources))]
        public string JobName
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.JobName : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.JobName = value;
            }
        }

        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobCodeRequired")]
        //[Display(Name = "DisplayName_JobCode", ResourceType = typeof(AMS.Common.Resources))]
          [Display(Name = "Job Code")]
        public string JobCode
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.JobCode : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.JobCode = value;
            }
        }

        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobStartDateRequired")]
        [Display(Name = "DisplayName_JobStartDate", ResourceType = typeof(AMS.Common.Resources))]
        public string JobStartDate
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.JobStartDate : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.JobStartDate = value;
            }
        }

        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobEndDateRequired")]
        [Display(Name = "DisplayName_JobEndDate", ResourceType = typeof(AMS.Common.Resources))]
        public string JobEndDate
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.JobEndDate : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.JobEndDate = value;
            }
        }

      //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CallTypeDescriptionRequired")]
        [Display(Name = "DisplayName_CallTypeDescription", ResourceType = typeof(AMS.Common.Resources))]
        public Int16 CallTypeID
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.CallTypeID : new Int16();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.CallTypeID = value;
            }
        }

        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CallTypeDescriptionRequired")]
          [Display(Name = "DisplayName_CallTypeDescription", ResourceType = typeof(AMS.Common.Resources))]
        public string CallTypeDescription
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.CallTypeDescription : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.CallTypeDescription = value;
            }
        }

        //[Display(Name = "DisplayName_IsNeededCaptureData", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsNeededCaptureData
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.IsNeededCaptureData : false;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.IsNeededCaptureData = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.IsActive : false;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.IsActive = value;
            }
        }

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.IsActive : false;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.IsActive = value;
            }
        }

        [Display(Name = "Created by")]
        public int CreatedBy
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.CreatedBy : new int();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created date")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified by")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.ModifiedBy : new int();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted by")]
        public int? DeletedBy
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.DeletedBy : new int();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted date")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.errorMessage : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.errorMessage = value;
            }
        }
        
        #endregion

        #region ----------------CRMJobAllocation Fields----------------
        public Int64 JobAllocationID
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.JobAllocationID : new Int64();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.JobAllocationID = value;
            }
        }

        public int CallEnquiryDetailID
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.CallEnquiryDetailID : new int();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.CallEnquiryDetailID = value;
            }
        }

        public int AdminRoleMasterID
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.AdminRoleMasterID : new int();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.AdminRoleMasterID = value;
            }
        }

        [Display(Name = "DisplayName_Employee", ResourceType = typeof(AMS.Common.Resources))]
        public int EmployeeID
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.EmployeeID : new int();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.EmployeeID = value;
            }
        }      
       
        public string TransactionaDate
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.TransactionaDate : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.TransactionaDate = value;
            }
        }

        public Int16 CallerJobStatus
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.CallerJobStatus : new Int16();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.CallerJobStatus = value;
            }
        }

         [Display(Name = "DisplayName_PerDayCallTarget", ResourceType = typeof(AMS.Common.Resources))]
        public Int16 PerDayCallTarget
        {
            get
            {
                return CRMJobCreationMasterAndAllocationDTO != null ? CRMJobCreationMasterAndAllocationDTO.PerDayCallTarget : new Int16();
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.PerDayCallTarget = value;
            }
        }

        [Display(Name = "DisplayName_Employee", ResourceType = typeof(AMS.Common.Resources))]
         public string EmployeeName
        {
            get
            {
                return (CRMJobCreationMasterAndAllocationDTO != null) ? CRMJobCreationMasterAndAllocationDTO.EmployeeName : string.Empty;
            }
            set
            {
                CRMJobCreationMasterAndAllocationDTO.EmployeeName = value;
            }
        }

        #endregion


         public List<CRMCallType> ListCallType { get; set; }
         public IEnumerable<SelectListItem> ListCallTypeItems
         {
             get
             {
                 return new SelectList(ListCallType, "ID", "CallTypeDescription");
             }
         }

         [Display(Name = "Pending Calls")]
         public int PendingCalls
         {
             get
             {
                 return (CRMJobCreationMasterAndAllocationDTO != null ) ? CRMJobCreationMasterAndAllocationDTO.PendingCalls : new int();
             }
             set
             {
                 CRMJobCreationMasterAndAllocationDTO.PendingCalls = value;
             }
         }

         public string JobAllocationDetailsXMLstring
         {
             get;
             set;
         }

         public List<CRMJobCreationMasterAndAllocation> CRMJobAllocationList { get; set; }
    }
}
