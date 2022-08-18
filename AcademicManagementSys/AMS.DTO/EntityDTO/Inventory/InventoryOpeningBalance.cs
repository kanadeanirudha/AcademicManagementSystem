using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryOpeningBalance : BaseDTO
    {
        public int ID 
        {
            get;
            set;
        }
        public int StockMasterID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string ItemName { get; set; }
        public string TransactionDate
        {
            get;
            set;
        }

        public decimal OpeningAmount
        {
            get;
            set;
        }

        public Int16 BalanceSheetID
        {
            get;
            set;
        }

        public int ItemID 
        {
            get;
            set;

        }
      
        public string CategoryDescription
        {
            get;
            set;
        }
        public string CategoryCode
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
        public string SelectedXml { get; set; }
        public string SessionName { get; set; }
        public int SessionID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public int AccSessionMasterID
        {
            get;
            set;
        }
        public string LocationName { get; set; }
        public bool StatusFlag
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {


            get;
            set;

        }
    }

}
