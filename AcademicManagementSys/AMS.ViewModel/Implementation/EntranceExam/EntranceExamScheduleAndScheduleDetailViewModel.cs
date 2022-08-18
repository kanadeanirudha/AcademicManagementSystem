using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EntranceExamScheduleAndScheduleDetailViewModel : IEntranceExamScheduleAndScheduleDetailViewModel
    {
        public EntranceExamScheduleAndScheduleDetailViewModel()
        {
            EntranceExamScheduleAndScheduleDetailDTO = new EntranceExamScheduleAndScheduleDetail();
            AllotedStudentListForCentreList = new List<EntranceExamScheduleAndScheduleDetail>();
        }

        public EntranceExamScheduleAndScheduleDetail EntranceExamScheduleAndScheduleDetailDTO { get; set; }

        public List<EntranceExamScheduleAndScheduleDetail> AllotedStudentListForCentreList
        {
            get;
            set;
        }

        //-----------------------------------EntranceExamSchedule Table Property-------------------------------//

        public int EntranceExamScheduleID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.EntranceExamScheduleID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.EntranceExamScheduleID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.EntranceExamScheduleID = value;
            }
        }

        [Display(Name = "Schedule Name :")]
        [Required(ErrorMessage = "Schedule name should not blank.")]
        public string ScheduleName
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ScheduleName != "") ? EntranceExamScheduleAndScheduleDetailDTO.ScheduleName : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ScheduleName = value;
            }
        }

        [Display(Name = "Schedule Date :")]
        [Required(ErrorMessage = "Schedule date should not blank.")]
        public string ScheduleDate
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ScheduleDate != "") ? EntranceExamScheduleAndScheduleDetailDTO.ScheduleDate : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ScheduleDate = value;
            }
        }

        [Display(Name = "Schedule Time Start :")]
        [Required(ErrorMessage = "Schedule time start should not blank.")]
        public string ScheduleTimeStart
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ScheduleTimeStart != "" )? EntranceExamScheduleAndScheduleDetailDTO.ScheduleTimeStart : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ScheduleTimeStart = value;
            }
        }

        [Display(Name = "Schedule End Time :")]
        [Required(ErrorMessage = "Schedule end time should not blank.")]
        public string ScheduleEndTime
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ScheduleEndTime != "")? EntranceExamScheduleAndScheduleDetailDTO.ScheduleEndTime : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ScheduleEndTime = value;
            }
        }

        [Display(Name="Paper set :")]
        [Required(ErrorMessage = "Paper set should not blank.")]
        public int OnlineExamExaminationQuestionPaperID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationQuestionPaperID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationQuestionPaperID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationQuestionPaperID = value;
            }
        }

        public int OnlineExamExaminationMasterID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationMasterID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.OnlineExamExaminationMasterID = value;
            }
        }

        public int EntranceExamInfrastructureDetailID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.EntranceExamInfrastructureDetailID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.EntranceExamInfrastructureDetailID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.EntranceExamInfrastructureDetailID = value;
            }
        }

        public int EntranceExamCenteApllicableToExamID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.EntranceExamCenteApllicableToExamID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.EntranceExamCenteApllicableToExamID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.EntranceExamCenteApllicableToExamID = value;
            }
        }

        public int TotalStudentApllicable
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.TotalStudentApllicable > 0) ? EntranceExamScheduleAndScheduleDetailDTO.TotalStudentApllicable : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.TotalStudentApllicable = value;
            }
        }



        //-----------------------------------EntranceExamScheduleDetail Table Property-------------------------------//
        public int EntranceExamScheduleDetailID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.EntranceExamScheduleDetailID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.EntranceExamScheduleDetailID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.EntranceExamScheduleDetailID = value;
            }
        }

        

        public int StudentRegistrationID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.StudentRegistrationID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.StudentRegistrationID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.StudentRegistrationID = value;
            }
        }

        

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return EntranceExamScheduleAndScheduleDetailDTO.IsDeleted != null ? EntranceExamScheduleAndScheduleDetailDTO.IsDeleted : false;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO.CreatedBy != null && EntranceExamScheduleAndScheduleDetailDTO.CreatedBy > 0) ? EntranceExamScheduleAndScheduleDetailDTO.CreatedBy : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO.CreatedDate != null) ? EntranceExamScheduleAndScheduleDetailDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return EntranceExamScheduleAndScheduleDetailDTO.ModifiedBy != null ? EntranceExamScheduleAndScheduleDetailDTO.ModifiedBy : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO.ModifiedDate != null && EntranceExamScheduleAndScheduleDetailDTO.ModifiedDate.HasValue) ? EntranceExamScheduleAndScheduleDetailDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.DeletedBy > 0) ? EntranceExamScheduleAndScheduleDetailDTO.DeletedBy : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO.DeletedDate != null && EntranceExamScheduleAndScheduleDetailDTO.DeletedDate.HasValue) ? EntranceExamScheduleAndScheduleDetailDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.DeletedDate = value;
            }
        }


        //---------------------------Exam Property-------------------------------//
        public string ErrorMessage
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ErrorMessage != "") ? EntranceExamScheduleAndScheduleDetailDTO.ErrorMessage : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ErrorMessage = value;
            }
        }

        public int ExaminationID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ExaminationID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.ExaminationID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ExaminationID = value;
            }
        }

        public string ExaminationName
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ExaminationName != "") ? EntranceExamScheduleAndScheduleDetailDTO.ExaminationName : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ExaminationName = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.CentreName != "") ? EntranceExamScheduleAndScheduleDetailDTO.CentreName : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.CentreName = value;
            }
        }

        public string RoomName
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.RoomName != "") ? EntranceExamScheduleAndScheduleDetailDTO.RoomName : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.RoomName = value;
            }
        }

        public int RoomCapacity
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.RoomCapacity > 0) ? EntranceExamScheduleAndScheduleDetailDTO.RoomCapacity : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.RoomCapacity = value;
            }
        }

        public string ExtraDescription
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.ExtraDescription != "") ? EntranceExamScheduleAndScheduleDetailDTO.ExtraDescription : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.ExtraDescription = value;
            }
        }

        public int StudentCount 
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.StudentCount > 0) ? EntranceExamScheduleAndScheduleDetailDTO.StudentCount : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.StudentCount = value;
            }
        }

        public int OnlineExamApplicableExamToCourseID 
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.OnlineExamApplicableExamToCourseID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.OnlineExamApplicableExamToCourseID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.OnlineExamApplicableExamToCourseID = value;
            }
        }

        public int EntranceExamAvailbleCentreID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.EntranceExamAvailbleCentreID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.EntranceExamAvailbleCentreID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.EntranceExamAvailbleCentreID = value;
            }
        }


        public string StudentName
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.StudentName != "") ? EntranceExamScheduleAndScheduleDetailDTO.StudentName : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.StudentName = value;
            }
        }
        public string AcademicYear
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.AcademicYear != "") ? EntranceExamScheduleAndScheduleDetailDTO.AcademicYear : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.AcademicYear = value;
            }
        }
        public int AcademicYearID
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.AcademicYearID > 0) ? EntranceExamScheduleAndScheduleDetailDTO.AcademicYearID : new int();
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.AcademicYearID = value;
            }
        }

        public string PaperSet
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.PaperSet != "") ? EntranceExamScheduleAndScheduleDetailDTO.PaperSet : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.PaperSet = value;
            }
        }

        public bool AllotedFlag
        {
            get
            {
                return EntranceExamScheduleAndScheduleDetailDTO != null ? EntranceExamScheduleAndScheduleDetailDTO.AllotedFlag :false;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.AllotedFlag = value;
            }
        }

        public string SelectedUnAllotedStudentXml
        {
            get
            {
                return (EntranceExamScheduleAndScheduleDetailDTO != null && EntranceExamScheduleAndScheduleDetailDTO.SelectedUnAllotedStudentXml != "") ? EntranceExamScheduleAndScheduleDetailDTO.SelectedUnAllotedStudentXml : string.Empty;
            }
            set
            {
                EntranceExamScheduleAndScheduleDetailDTO.SelectedUnAllotedStudentXml = value;
            }
        }
        
    }
}
