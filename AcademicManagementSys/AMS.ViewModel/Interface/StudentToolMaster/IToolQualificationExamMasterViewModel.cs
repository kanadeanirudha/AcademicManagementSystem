﻿using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IToolQualificationExamMasterViewModel
    {
        ToolQualificationExamMaster ToolQualificationExamMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string QualificationName
        {
            get;
            set;
        }
        string EducationType
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

        int? ModifiedBy
        {
            get;
            set;
        }

        DateTime? ModifiedDate
        {
            get;
            set;
        }

        int? DeletedBy
        {
            get;
            set;
        }

        DateTime? DeletedDate
        {
            get;
            set;
        }
    }
    public interface IToolQualificationExamMasterBaseViewModel
    {


    }
}
