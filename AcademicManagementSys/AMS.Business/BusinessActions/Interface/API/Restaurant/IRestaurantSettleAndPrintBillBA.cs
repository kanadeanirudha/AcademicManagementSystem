using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessAction
{
    public interface IRestaurantSettleAndPrintBillBA
    {
        IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantPrintBill(RestaurantSettleAndPrintBillSearchRequest searchRequest);
        IBaseEntityResponse<RestaurantSettleAndPrintBill> RestaurantSettleBillPost(RestaurantSettleAndPrintBill item);
        IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantBillList(RestaurantSettleAndPrintBillSearchRequest searchRequest);
    }
}
