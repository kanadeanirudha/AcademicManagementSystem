using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IFeeRefundMasterViewModel
    {
        FeeRefundMaster FeeRefundMasterDTO { get; set; }
        int ID
        {
            get;
            set;
        }
        Int16 AccSessionID
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string CentreName
        {
            get;
            set;
        }
        int AcademicYearID
        {
            get;
            set;
        }
        string PersonType
        {
            get;
            set;
        }
        int PersonID
        {
            get;
            set;
        }
        bool IsRefundByCashOrBank
        {
            get;
            set;
        }
        string Remark
        {
            get;
            set;
        }
        decimal RefundAmount
        {
            get;
            set;
        }
        string RefundDate
        {
            get;
            set;
        }
        string ChequeNumber
        {
            get;
            set;
        }
        string ChequeDate
        {
            get;
            set;
        }
        bool IsRefundGiven
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
        string errorMessage { get; set; }
        string SelectedXml { get; set; }
    }
}
