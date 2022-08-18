
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryCounterApplicableDetailsViewModel
    {
        InventoryCounterApplicableDetails InventoryCounterApplicableDetailsDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
         int InvCounterMasterID
        {
            get;
            set;
        }
        int InvMachineMasterID
        {
            get;
            set;
        }
        Int16 AccBalsheetMstID
        {
            get;
            set;
        }
        string MachineCode
        {
            get;
            set;
        }
        string MachineName
        {
            get;
            set;
        }
       string CounterName
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

