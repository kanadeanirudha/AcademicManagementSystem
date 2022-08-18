using AMS.DTO;
using System;
using System.Collections.Generic;
namespace AMS.ViewModel
{
    public interface IOnlineExaminationQuestionPaperSetMasterViewModel
    {
        OnlineExaminationQuestionPaperSetMaster OnlineExaminationQuestionPaperSetMasterDTO { get; set; }
        //----------------------------------Properties of OnlineExaminationQuestionPaper table--------------------------------
        int ID
        {
            get;
            set;
        }
        string PaperSet
        {
            get;
            set;
        }
        int OnlineExamExaminationMasterID
        {
            get;
            set;
        }

        //----------------------------------Properties of OnlineExaminationQuestionPaperDetails table--------------------------------
        int OnlineExaminationQuestionPaperDetailsID
        {
            get;
            set;
        }
        int OnlineExamExaminationQuestionPaperID
        {
            get;
            set;
        }
        int OnlineExamQuestionBankDetailsID
        {
            get;
            set;
        }
        Int16 OriginalOrder
        {
            get;
            set;
        }
        string XMLString
        {
            get;
            set;
        }
        string errorMessage
        {
            get;
            set;
        }
        string SubjectName
        {
            get;
            set;
        }
        int TotalQuestionSubjectWise
        {
            get;
            set;
        }
        int TotalQuestion
        {
            get;
            set;
        }
        int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
        bool IsQuestionInImage
        {
            get;
            set;
        }
        string QuestionLableText
        {
            get;
            set;
        }
        string ImageName
        {
            get;
            set;
        }
        List<OnlineExaminationQuestionPaperSetMaster> ApplicableQuestionList { get; set; }
        bool IsViewOnly{get;set;}        

    }
}
