using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineEntranceExamQuestionBankMasterViewModel
    {
        OnlineEntranceExamQuestionBankMaster OnlineEntranceExamQuestionBankMasterDTO { get; set; }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamQuestionBankMaster ~~~~~~~~~~~~~~~~~~~~~~~~~~
        int OnlineExamQuestionBankMasterID { get; set; }
        int SubjectID { get; set; }
        int SubjectGroupID { get; set; }
        int CourseYearDetailID { get; set; }
        int DepartmentID { get; set; }
        int OldOnlineExamQuestionBankMasterID { get; set; }
        Int16 IsAcademic { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OnlineQuestionBankDetails ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        int OnlineQuestionBankDetailsID { get; set; }
        string QuestionLableText { get; set; }
        string ImageType { get; set; }
        string ImageName { get; set; }
        bool IsQuestionInImage { get; set; }
        int LastAppearedInExamID { get; set; }
        string AppearDate { get; set; }
        int GeneralQuestionLevelMasterID { get; set; }
        int SyllabusGroupID { get; set; }
        int SyllabusTopicGroupID { get; set; }
        int SyllabusGroupDetID { get; set; }
        int GenQuestionTypeID { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamQuestionBankAnsDetails ~~~~~~~~~~~~~~~~~~~
        int OnlineExamQuestionBankAnsDetailsID { get; set; }
        string OptionText { get; set; }
        string OptionImage { get; set; }
        bool IsAnswer { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Feilds~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
        bool IsDeleted { get; set; }
        string errorMessage { get; set; }        
        
    }
}
