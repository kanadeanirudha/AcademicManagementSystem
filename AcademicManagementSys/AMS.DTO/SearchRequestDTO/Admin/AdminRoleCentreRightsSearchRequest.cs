using AMS.Base.DTO;

namespace AMS.DTO
{
    public class AdminRoleCentreRightsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
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
