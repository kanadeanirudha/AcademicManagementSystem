using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;
namespace AMS.ViewModel
{
    public class OnlineExaminationQuestionPaperSetMasterViewModel : IOnlineExaminationQuestionPaperSetMasterViewModel
    {
        public OnlineExaminationQuestionPaperSetMasterViewModel()
        {
            OnlineExaminationQuestionPaperSetMasterDTO = new OnlineExaminationQuestionPaperSetMaster();
            ApplicableQuestionList = new List<OnlineExaminationQuestionPaperSetMaster>();
        }
        public List<OnlineExaminationQuestionPaperSetMaster> ApplicableQuestionList { get; set; }
        public OnlineExaminationQuestionPaperSetMaster OnlineExaminationQuestionPaperSetMasterDTO
        {
            get;
            set;
        }
        //----------------------------------Properties of OnlineExaminationQuestionPaper table--------------------------------
        public int ID
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.ID > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.ID : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.ID = value;
            }
        }
        public string PaperSet
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.PaperSet : string.Empty;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.PaperSet = value;
            }
        }
        public int OnlineExamExaminationMasterID
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamExaminationMasterID > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamExaminationMasterID : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamExaminationMasterID = value;
            }
        }

        //----------------------------------Properties of OnlineExaminationQuestionPaperDetails table--------------------------------
        public int OnlineExaminationQuestionPaperDetailsID
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.OnlineExaminationQuestionPaperDetailsID > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.OnlineExaminationQuestionPaperDetailsID : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.OnlineExaminationQuestionPaperDetailsID = value;
            }
        }
        public int OnlineExamExaminationQuestionPaperID
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamExaminationQuestionPaperID > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamExaminationQuestionPaperID : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamExaminationQuestionPaperID = value;
            }
        }
        public int OnlineExamQuestionBankDetailsID
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamQuestionBankDetailsID > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamQuestionBankDetailsID : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamQuestionBankDetailsID = value;
            }
        }
        public Int16 OriginalOrder
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.OriginalOrder > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.OriginalOrder : new Int16();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.OriginalOrder = value;
            }
        }
        public string XMLString
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.XMLString : string.Empty;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.XMLString = value;
            }
        }        
        public string errorMessage
        {
            get;
            set;
        }
        public string PaperSetCode
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.PaperSetCode : string.Empty;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.PaperSetCode = value;
            }
        }
        [Display(Name="Exam :")]
        public string ExaminationName
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.ExaminationName : string.Empty;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.ExaminationName = value;
            }
        }        
        public string SubjectName
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.SubjectName : string.Empty;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.SubjectName = value;
            }
        }        
        public int TotalQuestionSubjectWise
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.TotalQuestionSubjectWise > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.TotalQuestionSubjectWise : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.TotalQuestionSubjectWise = value;
            }
        }
		public int TotalQuestion
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.TotalQuestion > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.TotalQuestion : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.TotalQuestion = value;
            }
        }
		public int OnlineExamQuestionBankMasterID
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamQuestionBankMasterID > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamQuestionBankMasterID : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.OnlineExamQuestionBankMasterID = value;
            }
        }
		public bool IsQuestionInImage
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.IsQuestionInImage : false;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.IsQuestionInImage = value;
            }
        }        
		public string QuestionLableText
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.QuestionLableText : string.Empty;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.QuestionLableText = value;
            }
        }        
        public string ImageName
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.ImageName : string.Empty;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.ImageName = value;
            }
        }
        public bool SubjectWiseStatus
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseStatus : false;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseStatus = value;
            }
        }        
        public int SubjectWiseCount
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseCount > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseCount : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseCount = value;
            }
        }
        public int SubjectWiseTotalQuestion
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseTotalQuestion > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseTotalQuestion : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.SubjectWiseTotalQuestion = value;
            }
        }
        public int TotalRecords
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null && OnlineExaminationQuestionPaperSetMasterDTO.TotalRecords > 0) ? OnlineExaminationQuestionPaperSetMasterDTO.TotalRecords : new int();
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.TotalRecords = value;
            }
        }
        public bool IsViewOnly
        {
            get
            {
                return (OnlineExaminationQuestionPaperSetMasterDTO != null) ? OnlineExaminationQuestionPaperSetMasterDTO.IsViewOnly : false;
            }
            set
            {
                OnlineExaminationQuestionPaperSetMasterDTO.IsViewOnly = value;
            }
        }        
    }
}
