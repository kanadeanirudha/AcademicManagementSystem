using AMS.Base.DTO;

namespace AMS.DTO
{
    public class RestaurantTableMasterSearchRequest : Request
    {
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
    }
}
