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
    public class CRMSaleJobUserJobScheduleSheetViewModel : ICRMSaleJobUserJobScheduleSheetViewModel
    {
        public CRMSaleJobUserJobScheduleSheetViewModel()
        {
            CRMSaleJobUserJobScheduleSheetDTO = new CRMSaleJobUserJobScheduleSheet();
            ListEmployeeJobs = new List<CRMSaleJobCreationMasterAndJobAllocationDetails>();
            ListEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            ListCRMSaleJobUserJobScheduleSheet = new List<CRMSaleJobUserJobScheduleSheet>();

        }

        //CRMSaleJobUserJobScheduleSheet
        public CRMSaleJobUserJobScheduleSheet CRMSaleJobUserJobScheduleSheetDTO { get; set; }
        public List<CRMSaleJobCreationMasterAndJobAllocationDetails> ListEmployeeJobs { get; set; }
        public List<EmpEmployeeMaster> ListEmpEmployeeMaster { get; set; }
        public List<CRMSaleJobUserJobScheduleSheet> ListCRMSaleJobUserJobScheduleSheet { get; set; }


        public IEnumerable<SelectListItem> ListEmployeeJobsItems
        {
            get
            {
                return new SelectList(ListEmployeeJobs, "ID", "JobName");
            }
        }

        public IEnumerable<SelectListItem> ListEmpEmployeeMasterItems
        {
            get
            {
                return new SelectList(ListEmpEmployeeMaster, "ID", "EmployeeFullName");
            }
        }


        public Int64 ID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.ID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.ID : new Int64();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ID = value;
            }
        }
        public Int64 JobCreationAllocationID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.JobCreationAllocationID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.JobCreationAllocationID : new Int64();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.JobCreationAllocationID = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.EmployeeID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.EmployeeID : new int();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.EmployeeID = value;
            }
        }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Transaction date should not be blank")]
        public string TransactionDate
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.TransactionDate != "") ? CRMSaleJobUserJobScheduleSheetDTO.TransactionDate : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.TransactionDate = value;
            }
        }

        [Display(Name = "From Time")]
        [Required(ErrorMessage = "From time should not be blank")]
        public string FromTime
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.FromTime != "") ? CRMSaleJobUserJobScheduleSheetDTO.FromTime : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.FromTime = value;
            }
        }

        [Display(Name = "UpTo Time")]
        [Required(ErrorMessage = "Upto time should not be blank")]
        public string UpToTime
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.UpToTime != "") ? CRMSaleJobUserJobScheduleSheetDTO.UpToTime : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.UpToTime = value;
            }
        }

        [Display(Name = "Schedule")]
        [Required(ErrorMessage = "Schedule type should not be blank")]
        public Int16 ScheduleType
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.ScheduleType > 0) ? CRMSaleJobUserJobScheduleSheetDTO.ScheduleType : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ScheduleType = value;
            }
        }

        [Display(Name = "Meeting Type")]
        public Int16 SubScheduleType
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.SubScheduleType > 0) ? CRMSaleJobUserJobScheduleSheetDTO.SubScheduleType : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.SubScheduleType = value;
            }
        }

        [Display(Name = "To be attended with employees")]
        public bool IsAttendOther
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.IsAttendOther : false;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.IsAttendOther = value;
            }
        }
        public string OtherListEmployeId
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.OtherListEmployeId != "") ? CRMSaleJobUserJobScheduleSheetDTO.OtherListEmployeId : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.OtherListEmployeId = value;
            }
        }

        public decimal VisitedLat
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.VisitedLat > 0) ? CRMSaleJobUserJobScheduleSheetDTO.VisitedLat : new decimal();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.VisitedLat = value;
            }
        }

        public decimal VisitedLang
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.VisitedLang > 0) ? CRMSaleJobUserJobScheduleSheetDTO.VisitedLang : new decimal();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.VisitedLang = value;
            }
        }

        [Display(Name = "Caller Job Status")]
        [Required(ErrorMessage = "Caller job status should not be blank")]
        public Int16 CallerJobStatus
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CallerJobStatus > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CallerJobStatus : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CallerJobStatus = value;
            }
        }
        [Display(Name = "Schedule Status")]
        public Int16 MeetingStatus
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.MeetingStatus > 0) ? CRMSaleJobUserJobScheduleSheetDTO.MeetingStatus : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.MeetingStatus = value;
            }
        }
        [Display(Name = "Schedule Description")]
        [Required(ErrorMessage = "Schedule description should not be blank")]
        public string ScheduleDescription
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.ScheduleDescription : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ScheduleDescription = value;
            }
        }
        [Display(Name = "Next Date")]
        [Required(ErrorMessage = "Next date should not be blank")]
        public string NextDate
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.NextDate : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.NextDate = value;
            }
        }

        [Display(Name = "From Time")]
        [Required(ErrorMessage = "From time should not be blank")]
        public string NextFromTime
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.NextFromTime : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.NextFromTime = value;
            }
        }

        [Display(Name = "UpTo Time")]
        [Required(ErrorMessage = "UpTo time should not be blank")]
        public string NextUpToTime
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.NextUpToTime : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.NextUpToTime = value;
            }
        }

        [Display(Name = "Interest Level")]
        [Required(ErrorMessage = "Interest level should not be blank")]
        public Int16 Interestlevel
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.Interestlevel : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.Interestlevel = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.IsDeleted : false;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CreatedBy > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CreatedBy : new int();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.ModifiedBy.HasValue) ? CRMSaleJobUserJobScheduleSheetDTO.ModifiedBy : new int();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.ModifiedDate.HasValue) ? CRMSaleJobUserJobScheduleSheetDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.DeletedBy : new int();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        //---------------------------------Extra PRoperty---------------------------------
        [Display(Name = "Job Type")]
        [Required(ErrorMessage = "Job type should not be blank")]
        public string JobType
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.JobType : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.JobType = value;
            }
        }

        //---------------------------------Extra PRoperty---------------------------------
        [Display(Name = "Job")]
        [Required(ErrorMessage = "Job should not be blank")]
        public string Job
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.Job : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.Job = value;
            }
        }


        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.EmployeeName : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.EmployeeName = value;
            }
        }
        [Display(Name = "Remark")]
        [Required(ErrorMessage = "Remark should not be blank")]
        public string Remark
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.Remark : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.Remark = value;
            }
        }

        [Display(Name = "Contact Person")]
        public string ContactPerson
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.ContactPerson : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ContactPerson = value;
            }
        }

        [Display(Name = "Account Name")]
        public string AccountName
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.AccountName : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.AccountName = value;
            }
        }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Transaction date should not be blank")]
        public string SelectedDate
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.SelectedDate : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.SelectedDate = value;
            }
        }

        //---------------Survey Details---------------

        [Display(Name = "From Address")]
        [Required(ErrorMessage = "From Address should not be blank")]
        public string FromAddress
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.FromAddress : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.FromAddress = value;
            }
        }

        [Display(Name = "To Address")]
        [Required(ErrorMessage = "To Address should not be blank")]
        public string ToAddress
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.ToAddress : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ToAddress = value;
            }
        }
        [Display(Name = "Follow Up Type")]
        [Required(ErrorMessage = "Follow up type should not be blank")]
        public string FollowUpType
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.FollowUpType : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.FollowUpType = value;
            }
        }


        public Int64 CRMSaleCallMasterID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CRMSaleCallMasterID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CRMSaleCallMasterID : new Int64();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CRMSaleCallMasterID = value;
            }
        }
        public HttpPostedFileBase VisitingCard { get; set; }
        public string ActionName { get; set; }
        public string VisitingCardName { get; set; }

        public Int64 CallEnquiryMasterID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CallEnquiryMasterID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CallEnquiryMasterID : new Int64();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CallEnquiryMasterID = value;
            }
        }

        public Int16 ScheduleStatus
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.ScheduleStatus > 0) ? CRMSaleJobUserJobScheduleSheetDTO.ScheduleStatus : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ScheduleStatus = value;
            }
        }

        [Display(Name = "Status")]
        public Int16 EnquiryStatus
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.EnquiryStatus : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.EnquiryStatus = value;
            }
        }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Call status should not be blank")]
        public Int16 CallStatus
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CallStatus > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CallStatus : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CallStatus = value;
            }
        }

        [Display(Name = "To")]
        [Required(ErrorMessage = "To mail should not be blank")]
        public string ToMail
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.ToMail : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ToMail = value;
            }
        }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Subject should not be blank")]
        public string ToSubject
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.ToSubject : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ToSubject = value;
            }
        }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description should not be blank")]
        public string Description
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.Description : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.Description = value;
            }
        }

        [Display(Name = "Survey Date")]
        [Required(ErrorMessage = "Servey date should not be blank")]
        public string ServeyDate
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.ServeyDate : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ServeyDate = value;
            }
        }

        [Display(Name = "Survey Time")]
        [Required(ErrorMessage = "Servey time should not be blank")]
        public string ServeyTime
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.ServeyTime : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.ServeyTime = value;
            }
        }

        public int JobCreationMasterID
        {
            get
            {
                return CRMSaleJobUserJobScheduleSheetDTO != null ? CRMSaleJobUserJobScheduleSheetDTO.JobCreationMasterID : new int();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.JobCreationMasterID = value;
            }
        }

        public string OtherListEmployeIDXml
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.OtherListEmployeIDXml : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.OtherListEmployeIDXml = value;
            }
        }

        public Int16 GeneralOtherJobTypeID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.GeneralOtherJobTypeID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.GeneralOtherJobTypeID : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.GeneralOtherJobTypeID = value;
            }
        }

        public string Relatedwith
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.Relatedwith : string.Empty;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.Relatedwith = value;
            }
        }
        public bool IsInvitation
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.IsInvitation : false;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.IsInvitation = value;
            }
        }
        public bool UpdateStatus
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null) ? CRMSaleJobUserJobScheduleSheetDTO.UpdateStatus : false;
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.UpdateStatus = value;
            }
        }
        public Int16 CRMSaleEnquiryAccountMasterID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountMasterID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountMasterID : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountMasterID = value;
            }
        }
        public Int16 CRMSaleEnquiryAccountContactPersonID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountContactPersonID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountContactPersonID : new Int16();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CRMSaleEnquiryAccountContactPersonID = value;
            }
        }
        
        public Int64 CRMJobUserJobScheduleParentID
        {
            get
            {
                return (CRMSaleJobUserJobScheduleSheetDTO != null && CRMSaleJobUserJobScheduleSheetDTO.CRMJobUserJobScheduleParentID > 0) ? CRMSaleJobUserJobScheduleSheetDTO.CRMJobUserJobScheduleParentID : new Int64();
            }
            set
            {
                CRMSaleJobUserJobScheduleSheetDTO.CRMJobUserJobScheduleParentID = value;
            }
        }

    }
}
