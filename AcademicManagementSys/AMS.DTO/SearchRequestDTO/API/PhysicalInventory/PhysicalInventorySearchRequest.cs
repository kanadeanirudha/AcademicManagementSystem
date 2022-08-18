using AMS.Base.DTO;

namespace AMS.DTO
{
    public class PhysicalInventorySearchRequest : Request
    {
        public int GeneralUnitsID { get; set; }
        public string ItemBarCode { get; set; }
        


    }
}
