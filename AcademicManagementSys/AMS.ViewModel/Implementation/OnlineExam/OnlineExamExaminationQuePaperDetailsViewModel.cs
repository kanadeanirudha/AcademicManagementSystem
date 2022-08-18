
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OnlineExamExaminationQuePaperDetailsViewModel : IOnlineExamExaminationQuePaperDetailsViewModel
    {

        public OnlineExamExaminationQuePaperDetailsViewModel()
        {
            OnlineExamExaminationQuePaperDetailsDTO = new OnlineExamExaminationQuePaperDetails();

        }

        public OnlineExamExaminationQuePaperDetails OnlineExamExaminationQuePaperDetailsDTO
        {
            get;
            set;
        }

        public Byte ID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.ID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.ID : new byte();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.ID = value;
            }
        }
        public Int32 OnlineExamExaminationQuestionPaperID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuestionPaperID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuestionPaperID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuestionPaperID = value;
            }
        }
        public Int32 OnlineExamSubjectGroupScheduleID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.OnlineExamSubjectGroupScheduleID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.OnlineExamSubjectGroupScheduleID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OnlineExamSubjectGroupScheduleID = value;
            }
        }
        public Int32 MarksForQuestion
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.MarksForQuestion > 0) ? OnlineExamExaminationQuePaperDetailsDTO.MarksForQuestion : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.MarksForQuestion = value;
            }
        }
        public Int32 OnlineExamQuestionBankMasterID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankMasterID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankMasterID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankMasterID = value;
            }
        }
        public string PaperSet
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.PaperSet : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.PaperSet = value;
            }
        }
        public string ExaminationName
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.ExaminationName : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.ExaminationName = value;
            }
        }
        public int SubjectGroupID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.SubjectGroupID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.SubjectGroupID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.SubjectGroupID = value;
            }
        }
        public int SubjectID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.SubjectID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.SubjectID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.SubjectID = value;
            }
        }
        public string SubjectDescription
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.SubjectDescription : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.SubjectDescription = value;
            }
        }
        public int OnlineExamQuestionBankDetailsID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankDetailsID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankDetailsID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankDetailsID = value;
            }
        }
        public string QuestionLableText
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.QuestionLableText : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.QuestionLableText = value;
            }
        }
        public string ImageType
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.ImageType : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.ImageType = value;
            }
        }

        public string OptionImage
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.OptionImage : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OptionImage = value;
            }
        }
        public string OptionText
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.OptionText : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OptionText = value;
            }
        }
        public string ImageName
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.ImageName : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.ImageName = value;
            }
        }
        public bool IsQuestionInImage
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.IsQuestionInImage : false;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.IsQuestionInImage = value;
            }
        }
        public string OptionImageList
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.OptionImageList : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OptionImageList = value;
            }
        }
        public string OptionTextList
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.OptionTextList : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OptionTextList = value;
            }
        }
        public string OptionIDsList
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.OptionIDsList : String.Empty;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OptionIDsList = value;
            }
        }
        public int OnlineExamExaminationQuePaperDetailsID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuePaperDetailsID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuePaperDetailsID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuePaperDetailsID = value;
            }
        }
        public int OnlineExamStudentApplicableID
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.OnlineExamStudentApplicableID > 0) ? OnlineExamExaminationQuePaperDetailsDTO.OnlineExamStudentApplicableID : new Int32();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.OnlineExamStudentApplicableID = value;
            }
        }
        public bool IsFinal
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.IsFinal : false;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.IsFinal = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.IsDeleted : false;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.IsDeleted = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null && OnlineExamExaminationQuePaperDetailsDTO.CreatedBy > 0) ? OnlineExamExaminationQuePaperDetailsDTO.CreatedBy : new int();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.CreatedDate = value;
            }
        }

         public int ModifiedBy
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.DeletedBy : new int();
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (OnlineExamExaminationQuePaperDetailsDTO != null) ? OnlineExamExaminationQuePaperDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OnlineExamExaminationQuePaperDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

