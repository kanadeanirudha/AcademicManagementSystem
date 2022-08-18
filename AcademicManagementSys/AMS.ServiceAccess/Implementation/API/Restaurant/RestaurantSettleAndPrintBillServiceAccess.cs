using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class RestaurantSettleAndPrintBillServiceAccess : IRestaurantSettleAndPrintBillServiceAccess
    {
        IRestaurantSettleAndPrintBillBA _RestaurantSettleAndPrintBillBA = null;

        public RestaurantSettleAndPrintBillServiceAccess() 
        {
            _RestaurantSettleAndPrintBillBA = new RestaurantSettleAndPrintBillBA();
        }

        public IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantPrintBill(RestaurantSettleAndPrintBillSearchRequest searchRequest)
        {
            return _RestaurantSettleAndPrintBillBA.GetRestaurantPrintBill(searchRequest);
        }
        public IBaseEntityResponse<RestaurantSettleAndPrintBill> RestaurantSettleBillPost(RestaurantSettleAndPrintBill item)
        {
            return _RestaurantSettleAndPrintBillBA.RestaurantSettleBillPost(item);
        }
        public IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantBillList(RestaurantSettleAndPrintBillSearchRequest searchRequest)
        {
            return _RestaurantSettleAndPrintBillBA.GetRestaurantBillList(searchRequest);
        }
    }

}
