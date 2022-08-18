using AMS.Base.DTO;

namespace AMS.DTO
{
    public class POSCounterSearchRequest : Request
    {
        public int StorageLocationID
        {
            get;
            set;
        }
        public string LastSyncDate
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string DeviceToken
        {
            get;
            set;
        }
    }
}
