using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishReservoirMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string ReservoirName
        {
            get;
            set;
        }
        public string ReservoirCode
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public int LocationId
        {
            get;
            set;
        }
        public decimal Latitude
        {
            get;
            set;
        }
        public decimal Logitude
        {
            get;
            set;
        }
        public decimal Area
        {
            get;
            set;
        }
        public decimal Capacity
        {
            get;
            set;
        }
        public decimal MinProductCapacity
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public Nullable<int> CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> DeletedDate
        {
            get;
            set;
        }

        public int BalancesheetID
        {
            get;
            set;
        }

        public string BalancesheetName
        {
            get;
            set;
        }



        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
