using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface INotificationTypeMasterAndNotificationTransactionServiceAccess
    {
        //NotificationTypeMaster
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> InsertNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item);
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> UpdateNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item);
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> DeleteNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item);
        IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> GetBySearchNotificationTypeMaster(NotificationTypeMasterAndNotificationTransactionSearchRequest searchRequest);
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> SelectByNotificationTypeMasterID(NotificationTypeMasterAndNotificationTransaction item);

        //NotificationTransaction
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> InsertNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item);
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> UpdateNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item);
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> DeleteNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item);
        IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> GetBySearchNotificationTransaction(NotificationTypeMasterAndNotificationTransactionSearchRequest searchRequest);
        IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> SelectByNotificationTransactionID(NotificationTypeMasterAndNotificationTransaction item);
    }
}
