using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryItemCategoryMasterViewModel
    {
        InventoryItemCategoryMaster InventoryItemCategoryMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        string CategoryDescription
        {
            get;
            set;
        }
        string CategoryCode
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
        string errorMessage { get; set; }
    }
}

