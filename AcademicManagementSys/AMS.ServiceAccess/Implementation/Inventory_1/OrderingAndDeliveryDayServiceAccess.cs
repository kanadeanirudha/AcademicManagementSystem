using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OrderingAndDeliveryDayServiceAccess : IOrderingAndDeliveryDayServiceAccess
    {
        IOrderingAndDeliveryDayBA _OrderingAndDeliveryDayBA = null;
        public OrderingAndDeliveryDayServiceAccess()
        {
            _OrderingAndDeliveryDayBA = new OrderingAndDeliveryDayBA();
        }
        public IBaseEntityResponse<OrderingAndDeliveryDay> InsertOrderingAndDeliveryDay(OrderingAndDeliveryDay item)
        {
            return _OrderingAndDeliveryDayBA.InsertOrderingAndDeliveryDay(item);
        }
        public IBaseEntityResponse<OrderingAndDeliveryDay> UpdateOrderingAndDeliveryDay(OrderingAndDeliveryDay item)
        {
            return _OrderingAndDeliveryDayBA.UpdateOrderingAndDeliveryDay(item);
        }
        public IBaseEntityResponse<OrderingAndDeliveryDay> DeleteOrderingAndDeliveryDay(OrderingAndDeliveryDay item)
        {
            return _OrderingAndDeliveryDayBA.DeleteOrderingAndDeliveryDay(item);
        }
        public IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetBySearch(OrderingAndDeliveryDaySearchRequest searchRequest)
        {
            return _OrderingAndDeliveryDayBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetOrderingAndDeliveryDaySearchList(OrderingAndDeliveryDaySearchRequest searchRequest)
        {
            return _OrderingAndDeliveryDayBA.GetOrderingAndDeliveryDaySearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetDropDownListForOrderingAndDeliveryDay(OrderingAndDeliveryDaySearchRequest searchRequest)
        {
            return _OrderingAndDeliveryDayBA.GetDropDownListForOrderingAndDeliveryDay(searchRequest);
        }
        public IBaseEntityResponse<OrderingAndDeliveryDay> SelectByID(OrderingAndDeliveryDay item)
        {
            return _OrderingAndDeliveryDayBA.SelectByID(item);
        }
    }
}
