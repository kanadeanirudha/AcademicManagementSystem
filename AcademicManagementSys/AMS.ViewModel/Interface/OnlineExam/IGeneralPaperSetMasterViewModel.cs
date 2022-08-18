
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralPaperSetMasterViewModel
    {
        GeneralPaperSetMaster GeneralPaperSetMasterDTO
        {
            get;
            set;
        }

        Byte ID
        {
            get;
            set;
        }
        string PaperSetCode
        {
            get;
            set;
        }

        //string MovementCode
        //{
        //    get;
        //    set;
        //}

        //bool IsActive
        //{
        //    get;
        //    set;
        //}
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
        string errorMessage { get; set; }
    }
}
