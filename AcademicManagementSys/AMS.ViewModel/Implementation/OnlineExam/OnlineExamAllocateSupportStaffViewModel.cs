using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamAllocateSupportStaffViewModel : IOnlineExamAllocateSupportStaffViewModel
    {

        public OnlineExamAllocateSupportStaffViewModel()
        {
            OnlineExamAllocateSupportStaffDTO = new OnlineExamAllocateSupportStaff();
            SessionNameList = new List<GeneralSessionMaster>();
            EmployeenameList = new List<EmpEmployeeMaster>();

        }
        public List<GeneralSessionMaster> SessionNameList { get; set; }
        public IEnumerable<SelectListItem> SessionNameListItems { get { return new SelectList(SessionNameList, "SessionID", "SessionName"); } }

        public List<EmpEmployeeMaster> EmployeenameList { get; set; }
        public IEnumerable<SelectListItem> EmployeenameListItem { get { return new SelectList(EmployeenameListItem, "EmployeeID", "Employeename"); } }

        public OnlineExamAllocateSupportStaff OnlineExamAllocateSupportStaffDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null && OnlineExamAllocateSupportStaffDTO.ID > 0) ? OnlineExamAllocateSupportStaffDTO.ID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.ID = value;
            }
        }

        public int OnlineExamAllocateSupportStaffID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null && OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateSupportStaffID > 0) ? OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateSupportStaffID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateSupportStaffID = value;
            }
        }

        public int SessionID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null && OnlineExamAllocateSupportStaffDTO.SessionID > 0) ? OnlineExamAllocateSupportStaffDTO.SessionID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.SessionID = value;
            }
        }
        public string SelectedCentreCode
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.SelectedCentreCode = value;
            }
        }
        public string SelectedExam
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.SelectedExam : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.SelectedExam = value;
            }
        }
        [Required(ErrorMessage = "Employee Name should not be blank.")]
        [Display(Name = "Employee")]
        public int EmployeeID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.EmployeeID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.EmployeeID= value;
            }
        }
        [Required(ErrorMessage = "Employee Name should not be blank.")]
        [Display(Name = "Employee Name")]
        public string EmployeeFullName
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.EmployeeFullName: string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.EmployeeFullName = value;
            }
        }

        [Required(ErrorMessage = "RoleMasterID should not be blank.")]
        [Display(Name = "RoleMasterID")]
        public int RoleMasterID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.RoleMasterID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.RoleMasterID = value;
            }
        }
        [Required(ErrorMessage = "OnlineExamExaminationMasterID should not be blank.")]
        [Display(Name = "OnlineExamExaminationMasterID ")]
        public int OnlineExamExaminationMasterID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.OnlineExamExaminationMasterID = value;
            }
        }
        public int OnlineExamAllocateJobSupportStaffID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateJobSupportStaffID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.OnlineExamAllocateJobSupportStaffID = value;
            }
        }
        [Required(ErrorMessage = "AllotedJobName should not be blank.")]
        [Display(Name = "Job Name ")]
        public string AllotedJobName
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.AllotedJobName : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.AllotedJobName = value;
            }
        }
        [Required(ErrorMessage = "AllotedJobName should not be blank.")]
        [Display(Name = "Job Code ")]
        public string AllotedJobCode
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.AllotedJobCode : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.AllotedJobCode = value;
            }
        }
        public string JobAllotedForCentreCode
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.JobAllotedForCentreCode : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.JobAllotedForCentreCode = value;
            }
        }
       
        [Required(ErrorMessage = "CentreName should not be blank.")]
        [Display(Name = "CentreName ")]
        public string CentreName
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.CentreName : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.CentreName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.CentreCode : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.CentreCode = value;
            }
        }

        [Required(ErrorMessage = "JobStartDate should not be blank.")]
        [Display(Name = "Job Start Date ")]
        public string JobStartDate
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.JobStartDate : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.JobStartDate = value;
            }
        }
        [Required(ErrorMessage = "JobEndDate should not be blank.")]
        [Display(Name = "Job End Date ")]
        public string JobEndDate
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.JobEndDate : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.JobEndDate = value;
            }
        }
        //[Required(ErrorMessage = "SubjectGroupId should not be blank.")]  
        [Display(Name = "Subject ")]
        public int SubjectGroupId
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.SubjectGroupId : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.SubjectGroupId = value;
            }
        }
        [Required(ErrorMessage = "Session should not be blank.")]
        [Display(Name = "Session ")]
        public string Session
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.Session :string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.Session = value;
            }
        }
        
        
        public int AcademicSessionID
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.AcademicSessionID : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.AcademicSessionID = value;
            }
        }
        [Required(ErrorMessage = "IsNotificationNeedToSentCompulsory should not be blank.")]
        [Display(Name = "Is Notification Need To Sent Compulsory ")]
        public bool IsNotificationNeedToSentCompulsory
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.IsNotificationNeedToSentCompulsory : new bool();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.IsNotificationNeedToSentCompulsory = value;
            }
        }
        [Required(ErrorMessage = "Examination Name should not be blank.")]
        [Display(Name = "Examination Name ")]
        public string ExaminationName
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.ExaminationName = value;
            }
        }
        //public string Employeename
        //{
        //    get
        //    {
        //        return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.Employeename : string.Empty;
        //    }
        //    set
        //    {
        //        OnlineExamAllocateSupportStaffDTO.Employeename = value;
        //    }
        //}

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null && OnlineExamAllocateSupportStaffDTO.CreatedBy > 0) ? OnlineExamAllocateSupportStaffDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamAllocateSupportStaffDTO != null) ? OnlineExamAllocateSupportStaffDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamAllocateSupportStaffDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

