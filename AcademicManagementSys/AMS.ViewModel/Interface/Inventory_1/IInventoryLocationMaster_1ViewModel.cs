using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryLocationMaster_1ViewModel
    {
        InventoryLocationMaster_1 InventoryLocationMaster_1DTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        
        int IssueFromLocationID
        {
            get;
            set;
        }
        int AccBalanceSheetID
        {
            get;
            set;
        }

        string LocationName
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

