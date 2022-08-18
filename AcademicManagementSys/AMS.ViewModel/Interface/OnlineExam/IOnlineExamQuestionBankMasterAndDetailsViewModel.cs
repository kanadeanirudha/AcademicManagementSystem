using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
   public interface IOnlineExamQuestionBankMasterAndDetailsViewModel
    {
        OnlineExamQuestionBankMasterAndDetails OnlineExamQuestionBankMasterAndDetailsDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        Int16 GenQuestionTypeID
        {
            get;
            set;
        }
        int SubjectID
        {
            get;
            set;
        }
        string QuestionLableText
        {
            get;
            set;
        }
        string ImageType
        {
            get;
            set;
        }
        string ImageName
        {
            get;
            set;
        }
        bool IsQuestionInImage
        {
            get;
            set;
        }
        int LastAppearedInExamID
        {
            get;
            set;
        }
        string AppearDate
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }

        int OnlineExamQuestionBankDetailsID
        {
            get;
            set;
        }
        int OnlineExamQuestionBankMasterID
        {
            get;
            set;
        }
        string OptionText
        {
            get;
            set;
        }
        string OptionImage
        {
            get;
            set;
        }
        bool IsAnswer
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
