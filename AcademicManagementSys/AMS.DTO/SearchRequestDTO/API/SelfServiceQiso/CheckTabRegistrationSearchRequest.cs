using AMS.Base.DTO;

namespace AMS.DTO
{
    public class CheckTabRegistrationSearchRequest : Request
    {
       
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
