

using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamExaminationMasterViewModel
    {
        OnlineExamExaminationMaster OnlineExamExaminationMasterDTO
        {
            get;
            set;
        }

        Int32 ID
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
        Int32 AcadSessionId
        {
            get;
            set;
        }
        string ExaminationFor
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
        String SessionName
        {
            get;
            set;
        }

        string errorMessage { get; set; }
        //List<GeneralSessionMaster> GetSessionNameList 
        //{ 
        //     get; 
        //     set; 
        //}
    }

}
