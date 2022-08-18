using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeShiftMasterViewModel : IEmployeeShiftMasterViewModel
    {

        public EmployeeShiftMasterViewModel()
        {
            EmployeeShiftMasterDTO = new EmployeeShiftMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public EmployeeShiftMaster EmployeeShiftMasterDTO
        {
            get;
            set;
        }


        #region ----------EmployeeShiftMaster ViewModel properties----------

        public int EmployeeShiftMasterID
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.EmployeeShiftMasterID > 0) ? EmployeeShiftMasterDTO.EmployeeShiftMasterID : new int();
            }
            set
            {
                EmployeeShiftMasterDTO.EmployeeShiftMasterID = value;
            }
        }


        [Display(Name = "DisplayName_EmployeeShiftDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeShiftDescriptionRequired")]
        public string EmployeeShiftDescription
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.EmployeeShiftDescription : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.EmployeeShiftDescription = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeShiftCode", ResourceType = typeof(AMS.Common.Resources))]             
        public string EmployeeShiftCode
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.EmployeeShiftCode : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.EmployeeShiftCode = value;
            }
        }


        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]      
        public string CentreCode
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreNameForShift", ResourceType = typeof(AMS.Common.Resources))] 
        public string CentreName
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.CentreName : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.CentreName = value;
            }
        }


        //[Display(Name = "DisplayName_IsShiftLocked", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsShiftLocked
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.IsShiftLocked : false;
            }
            set
            {
                EmployeeShiftMasterDTO.IsShiftLocked = value;
            }
        }

        //[Display(Name = "DisplayName_ShiftLockedDate", ResourceType = typeof(AMS.Common.Resources))]
        public string ShiftLockedDate
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.ShiftLockedDate : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.ShiftLockedDate = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.IsActive : false;
            }
            set
            {
                EmployeeShiftMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.IsDeleted : false;
            }
            set
            {
                EmployeeShiftMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.CreatedBy > 0) ? EmployeeShiftMasterDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeShiftMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeShiftMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.ModifiedBy.HasValue) ? EmployeeShiftMasterDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeShiftMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.ModifiedDate.HasValue) ? EmployeeShiftMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeShiftMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.DeletedBy.HasValue) ? EmployeeShiftMasterDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeShiftMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.DeletedDate.HasValue) ? EmployeeShiftMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeShiftMasterDTO.DeletedDate = value;
            }
        }

        public string SelectedCountryID
        {
            get;
            set;
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
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

        public string errorMessage { get; set; }
        #endregion

        #region ----------EmployeeShiftMasterDetails ViewModel properties----------

        public int EmployeeShiftMasterDetailsID
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.EmployeeShiftMasterDetailsID > 0) ? EmployeeShiftMasterDTO.EmployeeShiftMasterDetailsID : new int();
            }
            set
            {
                EmployeeShiftMasterDTO.EmployeeShiftMasterDetailsID = value;
            }
        }

        public int GeneralWeekDaysID
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.GeneralWeekDaysID > 0) ? EmployeeShiftMasterDTO.GeneralWeekDaysID : new int();
            }
            set
            {
                EmployeeShiftMasterDTO.GeneralWeekDaysID = value;
            }
        }

        [Display(Name = "DisplayName_WeekDay", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_WeekDayRequired")]
        public string WeekDay
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.WeekDay : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.WeekDay = value;
            }
        }


        [Display(Name = "DisplayName_WeeklyOffStatus", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_WeeklyOffStatusRequired")]
        public string WeeklyOffStatus
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.WeeklyOffStatus : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.WeeklyOffStatus = value;
            }
        }

        [Display(Name = "DisplayName_ShiftTimeFrom", ResourceType = typeof(AMS.Common.Resources))]
      //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ShiftTimeFromRequired")]      
        public TimeSpan ShiftTimeFrom
        {
            get
            {               
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.ShiftTimeFrom : TimeSpan.Zero;
            }
            set
            {
                EmployeeShiftMasterDTO.ShiftTimeFrom = value;
            }
        }

        [Display(Name = "DisplayName_ShiftTimeUpto", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ShiftTimeUptoRequired")]       
        public TimeSpan ShiftTimeUpto
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.ShiftTimeUpto : TimeSpan.Zero;
            }
            set
            {
                EmployeeShiftMasterDTO.ShiftTimeUpto = value;
            }
        }

        [Display(Name = "DisplayName_ShiftTimeMargin", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessage = "Margine should not be blank.")]
        public Int16 ShiftTimeMargin
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.ShiftTimeMargin > 0) ? EmployeeShiftMasterDTO.ShiftTimeMargin : new Int16();
            }
            set
            {
                EmployeeShiftMasterDTO.ShiftTimeMargin = value;
            }
        }

        [Display(Name = "DisplayName_ShiftEndBuffer", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessage = "Buffer should not be blank.")]
        public Int16 ShiftEndBuffer
        {
            get
            {
                return (EmployeeShiftMasterDTO != null && EmployeeShiftMasterDTO.ShiftEndBuffer > 0) ? EmployeeShiftMasterDTO.ShiftEndBuffer : new Int16();
            }
            set
            {
                EmployeeShiftMasterDTO.ShiftEndBuffer = value;
            }
        }

        [Display(Name = "DisplayName_ConsiderLateMarkUpto", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ConsiderLateMarkUptoRequired")]       
        public TimeSpan ConsiderLateMarkUpto
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.ConsiderLateMarkUpto : TimeSpan.Zero;
            }
            set
            {
                EmployeeShiftMasterDTO.ConsiderLateMarkUpto = value;
            }
        }

        [Display(Name = "DisplayName_SecondHalfFrom", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SecondHalfFromRequired")]       
        public TimeSpan SecondHalfFrom
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.SecondHalfFrom : TimeSpan.Zero;
            }
            set
            {
                EmployeeShiftMasterDTO.SecondHalfFrom = value;
            }
        }

        [Display(Name = "DisplayName_FirstHalfUpto", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FirstHalfUptoRequired")]       
        public TimeSpan FirstHalfUpto
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.FirstHalfUpto : TimeSpan.Zero;
            }
            set
            {
                EmployeeShiftMasterDTO.FirstHalfUpto = value;
            }
        }

        [Display(Name = "DisplayName_LunchTimeFrom", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LunchTimeFromRequired")]       
        public TimeSpan LunchTimeFrom
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.LunchTimeFrom : TimeSpan.Zero;
            }
            set
            {
                EmployeeShiftMasterDTO.LunchTimeFrom = value;
            }
        }

        [Display(Name = "DisplayName_LunchTimeUpto", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LunchTimeUptoRequired")]       
        public TimeSpan LunchTimeUpto
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.LunchTimeUpto : TimeSpan.Zero;
            }
            set
            {
                EmployeeShiftMasterDTO.LunchTimeUpto = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeShiftMasterDetailsCentreCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeShiftMasterDetailsCentreCodeRequired")]       
        public string EmployeeShiftMasterDetailsCentreCode
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.EmployeeShiftMasterDetailsCentreCode : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.EmployeeShiftMasterDetailsCentreCode = value;
            }
        }

        [Display(Name = "DisplayName_WeeklyOffType", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_WeeklyOffTypeRequired")]       
        public string WeeklyOffType
        {
            get
            {
                return (EmployeeShiftMasterDTO != null) ? EmployeeShiftMasterDTO.WeeklyOffType : string.Empty;
            }
            set
            {
                EmployeeShiftMasterDTO.WeeklyOffType = value;
            }
        }
        #endregion
    }
}
