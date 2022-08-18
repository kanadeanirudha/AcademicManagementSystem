using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryCounterLogAndLockDetails : BaseDTO
    {
        public int CounterLogID
        {
            get;
            set;
        }
        public decimal OpeningCash
        {
            get;
            set;
        }
        public decimal ClosingCash
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public DateTime LoginDateTime
        {
            get;
            set;
        }
        public DateTime LogOutDateTime
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }

        public int CounterLockID
        {
            get;
            set;
        }
        public int CounterID
        {
            get;
            set;
        }
        public int InvCounterApplicableDetailsID
        {
            get;
            set;
        }

      
        public int LoginUserCount
        {
            get;
            set;
        }

        public string TokenCode
        {
            get;
            set;
        }
        public int BalanceSheetID
        {
            get;
            set;
        }
        
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
