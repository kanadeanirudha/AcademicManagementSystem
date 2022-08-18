using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishItemLicenseAllocationSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public int LicenseTypeID
        {
            get;
            set;
        }
        public int FishFishermenMasterID
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public bool IsLastRecord
        {
            get;
            set;
        }
        public string PaymentMode
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
        //--------------------Extra Field-----
        public string LocationName { get; set; }
        public decimal Amount { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

    }
}
