
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamStudentApplicableViewModel : IOnlineExamStudentApplicableViewModel
    {

        public OnlineExamStudentApplicableViewModel()
        {
            OnlineExamStudentApplicableDTO = new OnlineExamStudentApplicable();

        }

        public OnlineExamStudentApplicable OnlineExamStudentApplicableDTO
        {
            get;
            set;
        }

        public Byte ID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.ID > 0) ? OnlineExamStudentApplicableDTO.ID : new byte();
            }
            set
            {
                OnlineExamStudentApplicableDTO.ID = value;
            }
        }
        public string SelectedCentreCode
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.SelectedCentreCode : String.Empty;
            }
            set
            {
                OnlineExamStudentApplicableDTO.SelectedCentreCode = value;
            }
        }
        public int OnlineExaminationMasterID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.OnlineExaminationMasterID > 0) ? OnlineExamStudentApplicableDTO.OnlineExaminationMasterID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.OnlineExaminationMasterID = value;
            }
        }
        public int CourseYearID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.CourseYearID > 0) ? OnlineExamStudentApplicableDTO.CourseYearID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.CourseYearID = value;
            }
        }
        public int SubjectID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.SubjectID > 0) ? OnlineExamStudentApplicableDTO.SubjectID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.SubjectID = value;
            }
        }
        public int SectionDetailID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.SectionDetailID > 0) ? OnlineExamStudentApplicableDTO.SectionDetailID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.SectionDetailID = value;
            }
        }
        public int StudentID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.StudentID > 0) ? OnlineExamStudentApplicableDTO.StudentID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.StudentID = value;
            }
        }
        public string StudentName
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.StudentName : String.Empty;
            }
            set
            {
                OnlineExamStudentApplicableDTO.StudentName = value;
            }
        }
        public string XMLString
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.XMLString : String.Empty;
            }
            set
            {
                OnlineExamStudentApplicableDTO.XMLString = value;
            }
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.OnlineExamSubjectGroupScheduleID > 0) ? OnlineExamStudentApplicableDTO.OnlineExamSubjectGroupScheduleID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.OnlineExamSubjectGroupScheduleID = value;
            }
        }
        public int OnlineExamIndStudentExamInfoID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.OnlineExamIndStudentExamInfoID > 0) ? OnlineExamStudentApplicableDTO.OnlineExamIndStudentExamInfoID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.OnlineExamIndStudentExamInfoID = value;
            }
        }
        public int CenterwiseSessionID
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.CenterwiseSessionID > 0) ? OnlineExamStudentApplicableDTO.CenterwiseSessionID : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.CenterwiseSessionID = value;
            }
        }
        
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamStudentApplicableDTO.IsDeleted = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null && OnlineExamStudentApplicableDTO.CreatedBy > 0) ? OnlineExamStudentApplicableDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamStudentApplicableDTO.CreatedDate = value;
            }
        }

         public int ModifiedBy
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamStudentApplicableDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamStudentApplicableDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamStudentApplicableDTO != null) ? OnlineExamStudentApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamStudentApplicableDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

