using AMS.Base.DTO;

namespace AMS.DTO
{
  public  class RestaurantTableOrderSearchRequest : Request
    {
      public string CentreCode { get; set; }
      public string TableNumber { get; set; }
    }
}
