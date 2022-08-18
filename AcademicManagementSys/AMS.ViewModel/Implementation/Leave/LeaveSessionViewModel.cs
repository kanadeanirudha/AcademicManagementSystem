using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class LeaveSessionViewModel : ILeaveSessionViewModel
    {
        public LeaveSessionViewModel()
        {
            LeaveSessionDTO = new LeaveSession();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public LeaveSession LeaveSessionDTO
        {
            get;
            set;
        }

        public int LeaveSessionID
        {
            get
            {
                return (LeaveSessionDTO != null && LeaveSessionDTO.LeaveSessionID > 0) ? LeaveSessionDTO.LeaveSessionID : new int();
            }
            set
            {
                LeaveSessionDTO.LeaveSessionID = value;
            }
        }

        [Display(Name = "DisplayName_LeaveSessionName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSessionNameRequired")]
        public string LeaveSessionName
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.LeaveSessionName : string.Empty;
            }
            set
            {
                LeaveSessionDTO.LeaveSessionName = value;
            }
        }

        [Display(Name = "DisplayName_LeaveSessionFromDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSessionFromDateRequired")]
        public string LeaveSessionFromDate
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.LeaveSessionFromDate : string.Empty;
            }
            set
            {
                LeaveSessionDTO.LeaveSessionFromDate = value;
            }
        }

        [Display(Name = "DisplayName_LeaveSessionUptoDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSessionUptoDateRequired")]
        public string LeaveSessionUptoDate
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.LeaveSessionUptoDate : string.Empty;
            }
            set
            {
                LeaveSessionDTO.LeaveSessionUptoDate = value;
            }
        }

        [Display(Name = "DisplayName_IsSessionLocked", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsSessionLocked
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.IsSessionLocked : false;
            }
            set
            {
                LeaveSessionDTO.IsSessionLocked = value;
            }
        }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveSessionDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveSessionDTO.CentreName = value;
            }
        }

        [Display(Name = "DisplayName_IsCurrentLeaveSession", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsCurrentLeaveSession
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.IsCurrentLeaveSession : false;
            }
            set
            {
                LeaveSessionDTO.IsCurrentLeaveSession = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.IsActive : false;
            }
            set
            {
                LeaveSessionDTO.IsActive = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.IsDeleted : false;
            }
            set
            {
                LeaveSessionDTO.IsDeleted = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (LeaveSessionDTO != null && LeaveSessionDTO.CreatedBy > 0) ? LeaveSessionDTO.CreatedBy : new int();
            }
            set
            {
                LeaveSessionDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveSessionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveSessionDTO != null && LeaveSessionDTO.ModifiedBy.HasValue) ? LeaveSessionDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveSessionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveSessionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveSessionDTO != null && LeaveSessionDTO.DeletedBy.HasValue) ? LeaveSessionDTO.DeletedBy : new int();
            }
            set
            {
                LeaveSessionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveSessionDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }


        public int LeaveSessionDetailsID
        {
            get
            {
                return (LeaveSessionDTO != null && LeaveSessionDTO.LeaveSessionDetailsID > 0) ? LeaveSessionDTO.LeaveSessionDetailsID : new int();
            }
            set
            {
                LeaveSessionDTO.LeaveSessionDetailsID = value;
            }
        }

        public int JobProfileID
        {
            get
            {
                return (LeaveSessionDTO != null && LeaveSessionDTO.JobProfileID > 0) ? LeaveSessionDTO.JobProfileID : new int();
            }
            set
            {
                LeaveSessionDTO.JobProfileID = value;
            }
        }

      //  [Display(Name = "DisplayName_JobProfileDescription", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobProfileDescriptionRequired")]
        public string JobProfileDescription
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.JobProfileDescription : string.Empty;
            }
            set
            {
                LeaveSessionDTO.JobProfileDescription = value;
            }
        }

       // [Display(Name = "DisplayName_JobStatusCode", ResourceType = typeof(AMS.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobStatusCodeRequired")]
        public string JobStatusCode
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.JobStatusCode : string.Empty;
            }
            set
            {
                LeaveSessionDTO.JobStatusCode = value;
            }
        }

       // [Display(Name = "DisplayName_JobStatusDescription", ResourceType = typeof(AMS.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobStatusCodeRequired")]
        public string JobStatusDescription
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.JobStatusDescription : string.Empty;
            }
            set
            {
                LeaveSessionDTO.JobStatusDescription = value;
            }
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

        [Display(Name = "DisplayName_EntityLevel", ResourceType = typeof(AMS.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EntityLevelRequired")]
        public string EntityLevel
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.EntityLevel : string.Empty;
            }
            set
            {
                LeaveSessionDTO.EntityLevel = value;
            }
        }
   
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EntityLevelRequired")]
        public int Mode
        {
            get
            {
                return (LeaveSessionDTO != null && LeaveSessionDTO.Mode > 0) ? LeaveSessionDTO.Mode : new int();
            }
            set
            {
                LeaveSessionDTO.Mode = value;
            }
        }
        
        public string SelectedIDs
        {
            get
            {
                return (LeaveSessionDTO != null) ? LeaveSessionDTO.SelectedIDs : string.Empty;
            }
            set
            {
                LeaveSessionDTO.SelectedIDs = value;
            }
        }
        
    }
}
