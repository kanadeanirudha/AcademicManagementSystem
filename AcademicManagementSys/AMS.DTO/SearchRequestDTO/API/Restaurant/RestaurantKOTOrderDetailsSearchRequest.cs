using AMS.Base.DTO;

namespace AMS.DTO
{
    public class RestaurantKOTOrderDetailsSearchRequest : Request
    {
        public int GeneralUnitsID { get; set; }
        public short IsRelatedWithCafe { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public bool StatusFlag { get; set; }
    }
}
