﻿using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralItemMarchandiseBaseCategoryViewModel
    {
        GeneralItemMarchandiseBaseCategory GeneralItemMarchandiseBaseCategoryDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string MarchandiseBaseCategoryName
        {
            get;
            set;
        }

        string MarchandiseBaseCategoryCode
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
