using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class NotificationTypeMasterAndNotificationTransactionServiceAccess : INotificationTypeMasterAndNotificationTransactionServiceAccess
    {
        INotificationTypeMasterAndNotificationTransactionBA _NotificationTypeMasterAndNotificationTransactionBA = null;

        public NotificationTypeMasterAndNotificationTransactionServiceAccess()
        {
            _NotificationTypeMasterAndNotificationTransactionBA = new NotificationTypeMasterAndNotificationTransactionBA();
        }

        //NotificationTypeMaster
        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> InsertNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.InsertNotificationTypeMaster(item);
        }

        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> UpdateNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.UpdateNotificationTypeMaster(item);
        }

        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> DeleteNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.DeleteNotificationTypeMaster(item);
        }

        public IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> GetBySearchNotificationTypeMaster(NotificationTypeMasterAndNotificationTransactionSearchRequest searchRequest)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.GetBySearchNotificationTypeMaster(searchRequest);
        }

        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> SelectByNotificationTypeMasterID(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.SelectByNotificationTypeMasterID(item);
        }


        //NotificationTransaction
        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> InsertNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.InsertNotificationTransaction(item);
        }

        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> UpdateNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.UpdateNotificationTransaction(item);
        }

        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> DeleteNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.DeleteNotificationTransaction(item);
        }

        public IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> GetBySearchNotificationTransaction(NotificationTypeMasterAndNotificationTransactionSearchRequest searchRequest)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.GetBySearchNotificationTransaction(searchRequest);
        }

        public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> SelectByNotificationTransactionID(NotificationTypeMasterAndNotificationTransaction item)
        {
            return _NotificationTypeMasterAndNotificationTransactionBA.SelectByNotificationTransactionID(item);
        }

    }
}
