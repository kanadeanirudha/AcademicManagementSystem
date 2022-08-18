using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class RestaurantTableMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        
        public string TableName
        {
            get;
            set;
        }
        public string TableCode
        {
            get;
            set;
        }
        public short Shape
        {
            get;
            set;
        }
        public Int16 MaxCapicity
        {
            get;
            set;
        }
        public Int16 MinCapacity
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string Name { get; set; }
        public string TableNumber { get; set; }
        public int RestaurantAllocatedTablesID { get; set; }
        public string AllocatedFrom { get; set; }
        public string AllocatedUpto { get; set; }
        public string MatrixRowPosition { get; set; }
        public string MatrixColPosition { get; set; }
        public bool IsTablePartiallyAllocated { get; set; }
        public bool IsTableAvailableForBooking { get; set; }
        public string CenterCode { get; set; }
        public bool IsEngagedFlag { get; set; }

        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ErrorMessage { get; set; }
    }

    }