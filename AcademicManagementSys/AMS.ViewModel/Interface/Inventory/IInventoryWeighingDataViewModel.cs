﻿using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryWeighingDataViewModel
    {
        InventoryWeighingData InventoryWeighingDataDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string MachineCode
        {
            get;
            set;
        }
        decimal Weight
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
        string errorMessage { get; set; }

    }
}
