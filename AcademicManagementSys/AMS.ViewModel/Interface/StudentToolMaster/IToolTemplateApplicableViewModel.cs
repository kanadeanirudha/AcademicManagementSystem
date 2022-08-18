using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IToolTemplateApplicableViewModel
    {

        ToolTemplateApplicable ToolTemplateApplicableDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int TemplateID
        {
            get;
            set;
        }
        int BranchDetailID
        {
            get;
            set;
        }
        int StandardNumber
        {
            get;
            set;
        }
        String FromDate
        {
            get;
            set;
        }
        String ToDate
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
  
}
