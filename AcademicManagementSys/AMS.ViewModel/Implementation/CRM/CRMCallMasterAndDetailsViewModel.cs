using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class CRMCallMasterAndDetailsViewModel : ICRMCallMasterAndDetailsViewModel
    {

        public CRMCallMasterAndDetailsViewModel()
        {
            CRMCallMasterAndDetailsDTO = new CRMCallMasterAndDetails();
        }

        public CRMCallMasterAndDetails CRMCallMasterAndDetailsDTO
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrgStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrgStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
        public List<CRMCallMasterAndDetails> ListCRMCalleeCallDetails
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "UniversityID", "UniversityName");
            }

        }

        public Int64 ID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.ID > 0) ? CRMCallMasterAndDetailsDTO.ID : new Int64();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.ID = value;
            }
        }

        public int JobID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.JobID > 0) ? CRMCallMasterAndDetailsDTO.JobID : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.JobID = value;
            }
        }
        public Int64 JobAllocationID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.JobAllocationID > 0) ? CRMCallMasterAndDetailsDTO.JobAllocationID : new Int64();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.JobAllocationID = value;
            }
        }
        [Display(Name = "Job Name")]
        public string JobName
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.JobName : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.JobName = value;
            }
        }
        [Display(Name = "Call Job Status")]
        public Int16 CallerJobStatus
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.CallerJobStatus > 0) ? CRMCallMasterAndDetailsDTO.CallerJobStatus : new Int16();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallerJobStatus = value;
            }
        }

        public string MenuLink
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.MenuLink : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.MenuLink = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string CenterCode
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CenterCode : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CenterCode = value;
            }
        }
        [Display(Name = "University Name")]
        public int UniversityID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.UniversityID > 0) ? CRMCallMasterAndDetailsDTO.UniversityID : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.UniversityID = value;
            }
        }

        [Display(Name = "DisplayName_BranchDetailID", ResourceType = typeof(Resources))]
        public int BranchDetailID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.BranchDetailID : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.BranchDetailID = value;
            }
        }

        [Display(Name = "Standard")]
        public int StandardNumber
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.StandardNumber : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.StandardNumber = value;
            }
        }
        [Display(Name = "DisplayName_AdmissionPattern", ResourceType = typeof(Resources))]
        public int AdmissionPattern
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.AdmissionPattern : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.AdmissionPattern = value;
            }
        }

        //Call Type New Admission
        #region
        [Display(Name = "Name")]
        public string CalleeFullName
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeFullName : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeFullName = value;
            }
        }

        public string CalleeTitle
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeTitle : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeTitle = value;
            }
        }
        [Display(Name = "First Name")]
        public string CalleeFirstName
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeFirstName : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeFirstName = value;
            }
        }
        [Display(Name = "Middel Name")]
        public string CalleeMiddelName
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeMiddelName : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeMiddelName = value;
            }
        }
        [Display(Name = "Last Name")]
        public string CalleeLastName
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeLastName : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeLastName = value;
            }
        }
        [Display(Name = "Mobile Number")]
        public string CalleeMobileNo
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeMobileNo : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeMobileNo = value;
            }
        }
        [Display(Name = "Email")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,15})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string CalleeEmailID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeEmailID : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeEmailID = value;
            }
        }
        [Display(Name = "DisplayName_GenderCode", ResourceType = typeof(Resources))]
        public string CalleeGender
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeGender : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeGender = value;
            }
        }

        public int CalleeLocationID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeLocationID : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeLocationID = value;
            }
        }

        [Display(Name = "Location")]
        public string CalleeLocation
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeLocation : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeLocation = value;
            }
        }
        [Display(Name = "Qualification")]
        public string CalleeQualification
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeQualification : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeQualification = value;
            }
        }
        [Display(Name = "Nationality")]
        public int CalleeNationalityID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.CalleeNationalityID > 0) ? CRMCallMasterAndDetailsDTO.CalleeNationalityID : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeNationalityID = value;
            }
        }
        public string CalleeNationality
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeNationality : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeNationality = value;
            }
        }
        [Display(Name = "Occupation")]
        public string CalleeOccupation
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeOccupation : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeOccupation = value;
            }
        }
        [Display(Name = "Designation")]
        public string CalleeDesignation
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeDesignation : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeDesignation = value;
            }
        }
        [Display(Name = "Department")]
        public string CalleeDepartment
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeDepartment : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeDepartment = value;
            }
        }
        [Display(Name = "Experience")]
        public string CalleeExperience
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeExperience : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeExperience = value;
            }
        }
        [Display(Name = "English Fluency")]
        public string EnglishFluency
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.EnglishFluency : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.EnglishFluency = value;
            }
        }
        public string Source
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.Source : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.Source = value;
            }
        }
        #endregion

        //Call Details
        #region
        [Display(Name = "Remark")]
        public string CallerRemark
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CallerRemark : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallerRemark = value;
            }
        }
        [Display(Name = "Call Status")]
        public Int16 CallStatus
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.CallStatus > 0) ? CRMCallMasterAndDetailsDTO.CallStatus : new Int16();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallStatus = value;
            }
        }

        public int CallEnquiryDetailID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.CallEnquiryDetailID > 0) ? CRMCallMasterAndDetailsDTO.CallEnquiryDetailID : new Int16();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallEnquiryDetailID = value;
            }
        }
        [Display(Name = "Next Call Date")]
        public string NextCallDate
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.NextCallDate : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.NextCallDate = value;
            }
        }
        public string CallDate
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CallDate : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallDate = value;
            }
        }
        [Display(Name = "Interest Level")]
        public Int16 Interestlevel
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.Interestlevel > 0) ? CRMCallMasterAndDetailsDTO.Interestlevel : new Int16();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.Interestlevel = value;
            }
        }

        [Display(Name = "Interested Program")]
        public string CalleeInterestedProgram
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CalleeInterestedProgram : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CalleeInterestedProgram = value;
            }
        }
        [Display(Name = "Concern Area")]
        public Int16 ConcernArea
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.ConcernArea > 0) ? CRMCallMasterAndDetailsDTO.ConcernArea : new Int16();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.ConcernArea = value;
            }
        }
        [Display(Name = "Other Concern Area")]
        public string OtherConcernArea
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.OtherConcernArea : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.OtherConcernArea = value;
            }
        }
        public string CallAnswerXML
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CallAnswerXML : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallAnswerXML = value;
            }
        }

        #endregion

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.CreatedBy > 0) ? CRMCallMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.ModifiedBy.HasValue) ? CRMCallMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.ModifiedDate.HasValue) ? CRMCallMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.DeletedBy.HasValue) ? CRMCallMasterAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.DeletedDate.HasValue) ? CRMCallMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }
        public string SelectedJobID
        {
            get;
            set;
        }
        public string SelectedCallerJobStatus
        {
            get;
            set;
        }
        public Int16 SelectedJobCallerStatus
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null && CRMCallMasterAndDetailsDTO.SelectedJobCallerStatus > 0) ? CRMCallMasterAndDetailsDTO.SelectedJobCallerStatus : new Int16();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.SelectedJobCallerStatus = value;
            }
        }
        public List<GeneralTimeSlotMaster> ListGeneralTimeSlot { get; set; }
        public IEnumerable<SelectListItem> ListGeneralTimeSlotItems
        {
            get
            {
                return new SelectList(ListGeneralTimeSlot, "ID", "TimeSlot");
            }
        }

        [Display(Name = "Call Time")]
        public Int16 CallTimeID
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null ) ? CRMCallMasterAndDetailsDTO.CallTimeID : new Int16();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallTimeID = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.FromDate : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.UptoDate : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.UptoDate = value;
            }
        }
        public string TimeSlot
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.TimeSlot : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.TimeSlot = value;
            }
        }

        public string CallerFullName
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CallerFullName : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CallerFullName = value;
            }
        }
        public int TotalCallCount
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.TotalCallCount : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.TotalCallCount = value;
            }
        }
        public int PendingCount
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.PendingCount : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.PendingCount = value;
            }
        }
        public int InprogressCount
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.InprogressCount : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.InprogressCount = value;
            }
        }
        public int CompletedCount
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.CompletedCount : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.CompletedCount = value;
            }
        }
        public int ConvertedCount
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.ConvertedCount : new int();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.ConvertedCount = value;
            }
        }
        public double ConvertedCallPercentage
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.ConvertedCallPercentage : new double();
            }
            set
            {
                CRMCallMasterAndDetailsDTO.ConvertedCallPercentage = value;
            }
        }
        public string UniversityName
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.UniversityName : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.UniversityName = value;
            }
        }
        public string BranchDescription
        {
            get
            {
                return (CRMCallMasterAndDetailsDTO != null) ? CRMCallMasterAndDetailsDTO.BranchDescription : string.Empty;
            }
            set
            {
                CRMCallMasterAndDetailsDTO.BranchDescription = value;
            }
        }
    }
}

