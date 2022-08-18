
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
    public class OnlineExamViewModel : IOnlineExamViewModel
    {

        public OnlineExamViewModel()
        {
            OnlineExamDTO = new OnlineExam();

        }

        public OnlineExam OnlineExamDTO
        {
            get;
            set;
        }

        public Byte ID
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.ID > 0) ? OnlineExamDTO.ID : new byte();
            }
            set
            {
                OnlineExamDTO.ID = value;
            }
        }

        public string ExaminationName
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExamDTO.ExaminationName = value;
            }
        }
        public Int32 OnlineExamIndStudentExamInfoID
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.OnlineExamIndStudentExamInfoID > 0) ? OnlineExamDTO.OnlineExamIndStudentExamInfoID : new Int32();
            }
            set
            {
                OnlineExamDTO.OnlineExamIndStudentExamInfoID = value;
            }
        }
        public Int32 OnlineExamExaminationCourseApplicableID
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.OnlineExamExaminationCourseApplicableID > 0) ? OnlineExamDTO.OnlineExamExaminationCourseApplicableID : new Int32();
            }
            set
            {
                OnlineExamDTO.OnlineExamExaminationCourseApplicableID = value;
            }
        }
        public Int32 ExaminationID
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.ExaminationID > 0) ? OnlineExamDTO.ExaminationID : new Int32();
            }
            set
            {
                OnlineExamDTO.ExaminationID = value;
            }
        }
        public string ExaminationStartTime
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ExaminationStartTime : string.Empty;
            }
            set
            {
                OnlineExamDTO.ExaminationStartTime = value;
            }
        }
        public string ExaminationEndTime
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ExaminationEndTime : string.Empty;
            }
            set
            {
                OnlineExamDTO.ExaminationEndTime = value;
            }

        }
        [Display(Name = "Examination Start Date")]
        public string ExaminationDate
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ExaminationDate : string.Empty;
            }
            set
            {
                OnlineExamDTO.ExaminationDate = value;
            }
        }
        [Display(Name = "Examination End Date")]
        public string ExaminationEndDate
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ExaminationEndDate : string.Empty;
            }
            set
            {
                OnlineExamDTO.ExaminationEndDate = value;
            }
        }
        public string SubjectName
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.SubjectName : string.Empty;
            }
            set
            {
                OnlineExamDTO.SubjectName = value;
            }
        }
        public Int16 TotalQuestions
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.TotalQuestions > 0) ? OnlineExamDTO.TotalQuestions : new Int16();
            }
            set
            {
                OnlineExamDTO.TotalQuestions = value;
            }
        }
        public Int16 ExamDuration
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.ExamDuration > 0) ? OnlineExamDTO.ExamDuration : new Int16();
            }
            set
            {
                OnlineExamDTO.ExamDuration = value;
            }
        }
        public string OnlineExamTimeDuration
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.OnlineExamTimeDuration : String.Empty;
            }
            set
            {
                OnlineExamDTO.OnlineExamTimeDuration = value;
            }
        }
        public Int16 QuestionOrder
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.QuestionOrder > 0) ? OnlineExamDTO.QuestionOrder : new Int16();
            }
            set
            {
                OnlineExamDTO.QuestionOrder = value;
            }
        }

        public bool IsQuestionInImage
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsQuestionInImage : false;
            }
            set
            {
                OnlineExamDTO.IsQuestionInImage = value;
            }
        }
        public string QuestionLableText
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.QuestionLableText : string.Empty;
            }
            set
            {
                OnlineExamDTO.QuestionLableText = value;
            }
        }
        public string ImageName
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ImageName : string.Empty;
            }
            set
            {
                OnlineExamDTO.ImageName = value;
            }
        }
        public bool IsExaminationOver
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsExaminationOver : false;
            }
            set
            {
                OnlineExamDTO.IsExaminationOver = value;
            }
        }
        public string OptionIDsList
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.OptionIDsList : string.Empty;
            }
            set
            {
                OnlineExamDTO.OptionIDsList = value;
            }
        }
        public string OptionImage
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.OptionImage : string.Empty;
            }
            set
            {
                OnlineExamDTO.OptionImage = value;
            }
        }
        public string OptionText
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.OptionText : string.Empty;
            }
            set
            {
                OnlineExamDTO.OptionText = value;
            }
        }
        public string CurrentStatusList
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.CurrentStatusList : string.Empty;
            }
            set
            {
                OnlineExamDTO.CurrentStatusList = value;
            }
        }
        public Int32 AnswerOptionID
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.AnswerOptionID > 0) ? OnlineExamDTO.AnswerOptionID : new Int32();
            }
            set
            {
                OnlineExamDTO.AnswerOptionID = value;
            }
        }
        public Int16 CurrentStatus
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.CurrentStatus > 0) ? OnlineExamDTO.CurrentStatus : new Int16();
            }
            set
            {
                OnlineExamDTO.CurrentStatus = value;
            }
        }
        public string QuestionOrderList
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.QuestionOrderList : string.Empty;
            }
            set
            {
                OnlineExamDTO.QuestionOrderList = value;
            }
        }
        public string DescriptiveAnswer
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.DescriptiveAnswer : string.Empty;
            }
            set
            {
                OnlineExamDTO.DescriptiveAnswer = value;
            }
        }
        public string AttachedDocument
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.AttachedDocument : string.Empty;
            }
            set
            {
                OnlineExamDTO.AttachedDocument = value;
            }
        }
        public Int16 IsAttachmentCompalsary
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.IsAttachmentCompalsary > 0) ? OnlineExamDTO.IsAttachmentCompalsary : new Int16();
            }
            set
            {
                OnlineExamDTO.IsAttachmentCompalsary = value;
            }
        }
        public Int16 DescriptiveStartQuestionOrder
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.DescriptiveStartQuestionOrder > 0) ? OnlineExamDTO.DescriptiveStartQuestionOrder : new Int16();
            }
            set
            {
                OnlineExamDTO.DescriptiveStartQuestionOrder = value;
            }
        }
        public Int16 ObjectiveStartQuestionOrder
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.ObjectiveStartQuestionOrder > 0) ? OnlineExamDTO.ObjectiveStartQuestionOrder : new Int16();
            }
            set
            {
                OnlineExamDTO.ObjectiveStartQuestionOrder = value;
            }
        }
        public bool IsQuestionDescriptive
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsQuestionDescriptive : false;
            }
            set
            {
                OnlineExamDTO.IsQuestionDescriptive = value;
            }
        }
        public bool IsDescriptiveQuestionInExam
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsDescriptiveQuestionInExam : false;
            }
            set
            {
                OnlineExamDTO.IsDescriptiveQuestionInExam = value;
            }
        }
        public bool IsObjectiveQuestionInExam
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsObjectiveQuestionInExam : false;
            }
            set
            {
                OnlineExamDTO.IsObjectiveQuestionInExam = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamDTO.IsDeleted = value;
            }
        }
        public bool IsExamStart
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsExamStart : false;
            }
            set
            {
                OnlineExamDTO.IsExamStart = value;
            }
        }
        public string ResultAnnounceDate
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ResultAnnounceDate : string.Empty;
            }
            set
            {
                OnlineExamDTO.ResultAnnounceDate = value;
            }
        }
        public bool IsResultAnnounce
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.IsResultAnnounce : false;
            }
            set
            {
                OnlineExamDTO.IsResultAnnounce = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (OnlineExamDTO != null && OnlineExamDTO.CreatedBy > 0) ? OnlineExamDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamDTO.CreatedDate = value;
            }
        }

         public int ModifiedBy
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamDTO != null) ? OnlineExamDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }


        public HttpPostedFileBase AttachedDocumentFile { get; set; }



    }
}

