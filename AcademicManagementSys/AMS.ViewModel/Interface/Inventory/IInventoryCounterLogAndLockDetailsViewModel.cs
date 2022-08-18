using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class IInventoryCounterLogAndLockDetailsViewModel : BaseDTO
    {
        int CounterLogID
        {
            get;
            set;
        }
        decimal OpeningCash
        {
            get;
            set;
        }
        decimal ClosingCash
        {
            get;
            set;
        }

        int UserID
        {
            get;
            set;
        }

        DateTime LoginDateTime
        {
            get;
            set;
        }
        DateTime LogOutDateTime
        {
            get;
            set;
        }
        int LocationID
        {
            get;
            set;
        }

        int CounterLockID
        {
            get;
            set;
        }

        int InVCounterApplicableDetailsID
        {
            get;
            set;
        }
        int LoginUserCount
        {
            get;
            set;
        }

        string TokenCode
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
