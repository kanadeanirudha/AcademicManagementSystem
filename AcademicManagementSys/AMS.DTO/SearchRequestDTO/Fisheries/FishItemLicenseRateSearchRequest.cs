using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishItemLicenseRateSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int LicenseTypeID
        {
            get;
            set;
        }
        public decimal Rate
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





        //---------------------Extra Feild------------------------//
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string SearchWord { get; set; }
    }
}
