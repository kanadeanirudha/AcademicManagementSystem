using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOrderingAndDeliveryDayServiceAccess
    {
        IBaseEntityResponse<OrderingAndDeliveryDay> InsertOrderingAndDeliveryDay(OrderingAndDeliveryDay item);
        IBaseEntityResponse<OrderingAndDeliveryDay> UpdateOrderingAndDeliveryDay(OrderingAndDeliveryDay item);
        IBaseEntityResponse<OrderingAndDeliveryDay> DeleteOrderingAndDeliveryDay(OrderingAndDeliveryDay item);
        IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetBySearch(OrderingAndDeliveryDaySearchRequest searchRequest);
        IBaseEntityResponse<OrderingAndDeliveryDay> SelectByID(OrderingAndDeliveryDay item);
        IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetOrderingAndDeliveryDaySearchList(OrderingAndDeliveryDaySearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetDropDownListForOrderingAndDeliveryDay(OrderingAndDeliveryDaySearchRequest searchRequest);
    }
}
