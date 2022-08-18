using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public interface IFeeLateFeesMasterViewModel 
    {
        FeeLateFeesMaster FeeLateFeesMasterDTO { get; set; }
        //-----------------------Properties of FeeLateFeesMaster  table----------------------------------
        int ID
        {
            get;
            set;
        }
        string LateFeeDescription
        {
            get;
            set;
        }
        string LateFeeType
        {
            get;
            set;
        }
        string SlabFixedFlag
        {
            get;
            set;
        }
        decimal LateFeeAmount
        {
            get;
            set;
        }
        int PeriodTypeID
        {
            get;
            set;
        }
        string PeriodType
        {
            get;
            set;
        }
        string PeriodTypeForSlab
        {
            get;
            set;
        }
        int FeeSubTypeID
        {
            get;
            set;
        }
        string FeeSubType
        {
            get;
            set;
        }
        bool IsIncremental
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

        //-------------------------Properties of FeeLateFeeSlabDetails  table---------------------------
        int LateFeesMasterID
        {
            get;
            set;
        }
        string LateFeeSlabFrom
        {
            get;
            set;
        }
        string LateFeeSlabTo
        {
            get;
            set;
        }
        decimal LateFeeValue
        {
            get;
            set;
        }
    }
}
