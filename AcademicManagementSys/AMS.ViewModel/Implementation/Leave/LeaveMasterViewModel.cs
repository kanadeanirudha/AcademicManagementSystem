using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class LeaveMasterViewModel : ILeaveMasterViewModel
    {
        public LeaveMasterViewModel()
        {
            LeaveMasterDTO = new LeaveMaster();
        }

        public LeaveMaster LeaveMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.ID > 0) ? LeaveMasterDTO.ID : new int();
            }
            set
            {
                LeaveMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string LeaveCode
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LeaveCode : string.Empty;
            }
            set
            {
                LeaveMasterDTO.LeaveCode = value;
            }
        }
        [Display(Name = "DisplayName_LeaveTypeDesc", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveTypeDescRequired")]
        public string LeaveDescription
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeaveMasterDTO.LeaveDescription = value;
            }
        }

        [Display(Name = "DisplayName_IsCarryForwardForNextYear", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsCarryForwardForNextYear
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsCarryForwardForNextYear : false;
            }
            set
            {
                LeaveMasterDTO.IsCarryForwardForNextYear = value;
            }
        }

        [Display(Name = "DisplayName_IsEnCash", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsEnCash
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsEnCash : false;
            }
            set
            {
                LeaveMasterDTO.IsEnCash = value;
            }
        }

        [Display(Name = "DisplayName_AttendanceNeeded", ResourceType = typeof(AMS.Common.Resources))]
        public bool AttendanceNeeded
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.AttendanceNeeded : false;
            }
            set
            {
                LeaveMasterDTO.AttendanceNeeded = value;
            }
        }

        [Display(Name = "DisplayName_DocumentsNeeded", ResourceType = typeof(AMS.Common.Resources))]
        public bool DocumentsNeeded
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.DocumentsNeeded : false;
            }
            set
            {
                LeaveMasterDTO.DocumentsNeeded = value;
            }
        }

        [Display(Name = "DisplayName_HalfDayFlag", ResourceType = typeof(AMS.Common.Resources))]
        public bool HalfDayFlag
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.HalfDayFlag : false;
            }
            set
            {
                LeaveMasterDTO.HalfDayFlag = value;
            }
        }

        [Display(Name = "DisplayName_LossOfPay", ResourceType = typeof(AMS.Common.Resources))]
        public bool LossOfPay
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LossOfPay : false;
            }
            set
            {
                LeaveMasterDTO.LossOfPay = value;
            }
        }

         [Display(Name = "DisplayName_NoCredit", ResourceType = typeof(AMS.Common.Resources))]
        public bool NoCredit
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.NoCredit : false;
            }
            set
            {
                LeaveMasterDTO.NoCredit = value;
            }
        }

         [Display(Name = "DisplayName_MinServiceRequire", ResourceType = typeof(AMS.Common.Resources))]
        public bool MinServiceRequire
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.MinServiceRequire : false;
            }
            set
            {
                LeaveMasterDTO.MinServiceRequire = value;
            }
        }

         [Display(Name = "DisplayName_OnDuty", ResourceType = typeof(AMS.Common.Resources))]
        public bool OnDuty
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.OnDuty : false;
            }
            set
            {
                LeaveMasterDTO.OnDuty = value;
            }
        }
         [Display(Name = "Is Posted Once?")]
         public bool IsPostedOnce
         {
             get
             {
                 return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsPostedOnce : false;
             }
             set
             {
                 LeaveMasterDTO.IsPostedOnce = value;
             }
         }


        [Display(Name = "DisplayName_LeaveType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveTypeRequired")]
        
        public string LeaveType
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.LeaveType : string.Empty;
            }
            set
            {
                LeaveMasterDTO.LeaveType = value;
            }
        }
        // [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsActive : false;
            }
            set
            {
                LeaveMasterDTO.IsActive = value;
            }
        }
        // [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.IsDeleted : false;
            }
            set
            {
                LeaveMasterDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.CreatedBy > 0) ? LeaveMasterDTO.CreatedBy : new int();
            }
            set
            {
                LeaveMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveMasterDTO != null) ? LeaveMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.ModifiedBy.HasValue) ? LeaveMasterDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.ModifiedDate.HasValue) ? LeaveMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.DeletedBy.HasValue) ? LeaveMasterDTO.DeletedBy : new int();
            }
            set
            {
                LeaveMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveMasterDTO != null && LeaveMasterDTO.DeletedDate.HasValue) ? LeaveMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}
