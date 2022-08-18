
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamStudentQuePaperCheckDetailsViewModel : IOnlineExamStudentQuePaperCheckDetailsViewModel
    {

        public OnlineExamStudentQuePaperCheckDetailsViewModel()
        {
            OnlineExamStudentQuePaperCheckDetailsDTO = new OnlineExamStudentQuePaperCheckDetails();

        }

        public OnlineExamStudentQuePaperCheckDetails OnlineExamStudentQuePaperCheckDetailsDTO
        {
            get;
            set;
        }

        public Byte ID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.ID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.ID : new byte();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.ID = value;
            }
        }
        public Int32 OnlineExamQuestionPaperCheckerID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionPaperCheckerID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionPaperCheckerID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionPaperCheckerID = value;
            }
        }
        public Int32 OnlineExamIndQuestionPaperID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndQuestionPaperID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndQuestionPaperID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndQuestionPaperID = value;
            }
        }
        public Int32 IsAttachmentCompalsary
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.IsAttachmentCompalsary > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.IsAttachmentCompalsary : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.IsAttachmentCompalsary = value;
            }
        }
        public Int32 OnlineExamSubjectGroupScheduleID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamSubjectGroupScheduleID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamSubjectGroupScheduleID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamSubjectGroupScheduleID = value;
            }
        }

       
        public Int32 OnlineExamExaminationCourseApplicableID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamExaminationCourseApplicableID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamExaminationCourseApplicableID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamExaminationCourseApplicableID = value;
            }
        }
        public Int32 MarksForQuestion
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.MarksForQuestion > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.MarksForQuestion : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.MarksForQuestion = value;
            }
        }
         [Display(Name = "Marks Obtain")]
        public decimal MarkObtained
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.MarkObtained > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.MarkObtained : new decimal();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.MarkObtained = value;
            }
        }
        public Int32 OnlineExamQuestionBankMasterID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionBankMasterID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionBankMasterID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionBankMasterID = value;
            }
        }
       
        public string ExaminationName
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.ExaminationName : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.ExaminationName = value;
            }
        }

        public string DescriptiveAnswer
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.DescriptiveAnswer : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.DescriptiveAnswer = value;
            }
        }
        public string AttachedDocument
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.AttachedDocument : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.AttachedDocument = value;
            }
        }
        public int SubjectGroupID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.SubjectGroupID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.SubjectGroupID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.SubjectGroupID = value;
            }
        }
        public int SubjectID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.SubjectID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.SubjectID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.SubjectID = value;
            }
        }
        public string SubjectDescription
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.SubjectDescription : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.SubjectDescription = value;
            }
        }
        public int OnlineExamQuestionBankDetailsID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionBankDetailsID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionBankDetailsID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionBankDetailsID = value;
            }
        }
        public string QuestionLableText
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.QuestionLableText : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.QuestionLableText = value;
            }
        }
        public string ImageType
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.ImageType : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.ImageType = value;
            }
        }

        public string OptionImage
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.OptionImage : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OptionImage = value;
            }
        }
        public string OptionText
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.OptionText : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OptionText = value;
            }
        }
        public string ImageName
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.ImageName : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.ImageName = value;
            }
        }
        public bool IsQuestionInImage
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.IsQuestionInImage : false;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.IsQuestionInImage = value;
            }
        }
        public string OptionImageList
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.OptionImageList : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OptionImageList = value;
            }
        }
        public string OptionTextList
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.OptionTextList : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OptionTextList = value;
            }
        }
        public string OptionIDsList
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.OptionIDsList : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OptionIDsList = value;
            }
        }
        public int OnlineExamStudentQuePaperCheckDetailsID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamStudentQuePaperCheckDetailsID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamStudentQuePaperCheckDetailsID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamStudentQuePaperCheckDetailsID = value;
            }
        }
        public int OnlineExamStudentApplicableID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamStudentApplicableID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamStudentApplicableID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamStudentApplicableID = value;
            }
        }
        public bool IsAllChecked
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.IsAllChecked : false;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.IsAllChecked = value;
            }
        }
        public string StudentName
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.StudentName : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.StudentName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.FirstName : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.FirstName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.MiddleName : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.MiddleName = value;
            }
        }
        public string LastName
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.LastName : String.Empty;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.LastName = value;
            }
        }
        public int OnlineExamIndStudentExamInfoID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndStudentExamInfoID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndStudentExamInfoID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndStudentExamInfoID = value;
            }
        }
        public int StudentID
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.StudentID > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.StudentID : new Int32();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.StudentID = value;
            }
        }
        public bool IsExaminationOver
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.IsExaminationOver : false;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.IsExaminationOver = value;
            }
        }
        public bool IsChecked
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.IsChecked : false;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.IsChecked = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.IsDeleted = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null && OnlineExamStudentQuePaperCheckDetailsDTO.CreatedBy > 0) ? OnlineExamStudentQuePaperCheckDetailsDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.CreatedDate = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamStudentQuePaperCheckDetailsDTO != null) ? OnlineExamStudentQuePaperCheckDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamStudentQuePaperCheckDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

