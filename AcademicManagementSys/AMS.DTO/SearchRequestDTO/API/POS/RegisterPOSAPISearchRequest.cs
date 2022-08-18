using AMS.Base.DTO;

namespace AMS.DTO
{
    public class RegisterPOSAPISearchRequest : Request
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
    }
}
