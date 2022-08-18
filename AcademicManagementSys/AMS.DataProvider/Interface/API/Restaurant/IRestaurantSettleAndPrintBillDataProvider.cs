using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IRestaurantSettleAndPrintBillDataProvider
    {
        IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantPrintBill(RestaurantSettleAndPrintBillSearchRequest searchRequest);
        IBaseEntityResponse<RestaurantSettleAndPrintBill> RestaurantSettleBillPost(RestaurantSettleAndPrintBill item);
        IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantBillList(RestaurantSettleAndPrintBillSearchRequest searchRequest);
    }
}

