using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IToolQualificationMasterSubjectViewModel
    {
        ToolQualificationMasterSubject ToolQualificationMasterSubjectDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int QualificationMstID
        {
            get;
            set;
        }
        string SubjectName
        {
            get;
            set;
        }
        int MarkOutOf
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
    public interface IToolQualificationMasterSubjectBaseViewModel
    {


    }
}
