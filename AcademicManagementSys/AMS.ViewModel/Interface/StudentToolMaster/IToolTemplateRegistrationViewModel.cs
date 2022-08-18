

using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IToolTemplateRegistrationViewModel
    {

        ToolTemplateRegistration ToolTemplateRegistrationDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string Title
        {
            get;
            set;
        }


        int ParentID
        {
            get;
            set;
        }

        int NumberOfColumn
        {
            get;
            set;
        }

        int SequenceNo
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
    public interface IToolTemplateRegistrationBaseViewModel
    {


    }
}
