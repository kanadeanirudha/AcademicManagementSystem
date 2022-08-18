using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public interface IRestaurantSettleAndPrintBillServiceAccess
    {
        IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantPrintBill(RestaurantSettleAndPrintBillSearchRequest searchRequest);
        IBaseEntityResponse<RestaurantSettleAndPrintBill> RestaurantSettleBillPost(RestaurantSettleAndPrintBill item);
        IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantBillList(RestaurantSettleAndPrintBillSearchRequest searchRequest);
    }

}