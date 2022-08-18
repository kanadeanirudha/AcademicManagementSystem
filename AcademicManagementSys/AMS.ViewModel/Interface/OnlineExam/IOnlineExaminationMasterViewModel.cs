using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IOnlineExaminationMasterViewModel
    {
        OnlineExaminationMaster OnlineExaminationMasterDTO { get; set; }
        //----------------------------------Properties of OnlineExamExaminationMaster table--------------------------------
        int ID
        {
            get;
            set;
        }
        string ExaminationName
        {
            get;
            set;
        }
        string Purpose
        {
            get;
            set;
        }
        int AcadSessionId
        {
            get;
            set;
        }
        Int16 TotalTime
        {
            get;
            set;
        }
        Int16 TotalQuestion
        {
            get;
            set;
        }
        decimal TotalMarks
        {
            get;
            set;
        }
        decimal MarksInEachQuestion
        {
            get;
            set;
        }
        Boolean IsNegativeMarkingApplicable
        {
            get;
            set;
        }
        decimal NegativeMarksInEachQuestion
        {
            get;
            set;
        }
        Int16 TotalPaperSet
        {
            get;
            set;
        }

        //----------------------------------Properties of OnlineExamExaminationSubjectApplicable  table--------------------------------
        int OnlineExaminationSubjectApplicableID
        {
            get;
            set;
        }
        Int16 TotalQuestionQueTypeWise
        {
            get;
            set;
        }
        int SubjectID
        {
            get;
            set;
        }
        string QuestionType
        {
            get;
            set;
        }
        int QuestionTypeID
        {
            get;
            set;
        }
        string SubjectName
        {
            get;
            set;
        }
    }
}
