using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public class NotificationTypeMasterAndNotificationTransactionBA : INotificationTypeMasterAndNotificationTransactionBA
    {
        INotificationTypeMasterAndNotificationTransactionDataProvider notificationTypeMasterAndNotificationTransactionDataProvider;
        INotificationTypeMasterAndNotificationTransactionBR notificationTypeMasterAndNotificationTransactionBR;

         private ILogger _logException;
         public NotificationTypeMasterAndNotificationTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            notificationTypeMasterAndNotificationTransactionBR = new NotificationTypeMasterAndNotificationTransactionBR();
            notificationTypeMasterAndNotificationTransactionDataProvider = new NotificationTypeMasterAndNotificationTransactionDataProvider();
        }

         //NotificationTypeMaster
         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> InsertNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 IValidateBusinessRuleResponse brResponse = notificationTypeMasterAndNotificationTransactionBR.InsertNotificationTypeMasterValidate(item);
                 if (brResponse.Passed)
                 {
                     entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.InsertNotificationTypeMaster(item);
                 }
                 else
                 {
                     entityResponse.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     entityResponse.Entity = null; ;
                 }
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }

         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> UpdateNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 IValidateBusinessRuleResponse brResponse = notificationTypeMasterAndNotificationTransactionBR.UpdateNotificationTypeMasterValidate(item);
                 if (brResponse.Passed)
                 {
                     entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.UpdateNotificationTypeMaster(item);
                 }
                 else
                 {
                     entityResponse.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     entityResponse.Entity = null; ;
                 }
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }

         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> DeleteNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 IValidateBusinessRuleResponse brResponse = notificationTypeMasterAndNotificationTransactionBR.DeleteNotificationTypeMasterValidate(item);
                 if (brResponse.Passed)
                 {
                     entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.DeleteNotificationTypeMaster(item);
                 }
                 else
                 {
                     entityResponse.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     entityResponse.Entity = null; ;
                 }
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }

         public IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> GetBySearchNotificationTypeMaster(NotificationTypeMasterAndNotificationTransactionSearchRequest searchRequest)
         {
             IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> NotificationTypeMasterCollection = new BaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 if (notificationTypeMasterAndNotificationTransactionDataProvider != null)
                     NotificationTypeMasterCollection = notificationTypeMasterAndNotificationTransactionDataProvider.GetBySearchNotificationTypeMaster(searchRequest);
                 else
                 {
                     NotificationTypeMasterCollection.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     NotificationTypeMasterCollection.CollectionResponse = null;
                 }
             }
             catch (Exception ex)
             {
                 NotificationTypeMasterCollection.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 NotificationTypeMasterCollection.CollectionResponse = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return NotificationTypeMasterCollection;
         }

         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> SelectByNotificationTypeMasterID(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.SelectByNotificationTypeMasterID(item);
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }


         //NotificationTransaction
         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> InsertNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 IValidateBusinessRuleResponse brResponse = notificationTypeMasterAndNotificationTransactionBR.InsertNotificationTransactionValidate(item);
                 if (brResponse.Passed)
                 {
                     entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.InsertNotificationTransaction(item);
                 }
                 else
                 {
                     entityResponse.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     entityResponse.Entity = null; ;
                 }
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }

         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> UpdateNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 IValidateBusinessRuleResponse brResponse = notificationTypeMasterAndNotificationTransactionBR.UpdateNotificationTransactionValidate(item);
                 if (brResponse.Passed)
                 {
                     entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.UpdateNotificationTransaction(item);
                 }
                 else
                 {
                     entityResponse.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     entityResponse.Entity = null; ;
                 }
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }

         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> DeleteNotificationTransaction(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 IValidateBusinessRuleResponse brResponse = notificationTypeMasterAndNotificationTransactionBR.DeleteNotificationTransactionValidate(item);
                 if (brResponse.Passed)
                 {
                     entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.DeleteNotificationTransaction(item);
                 }
                 else
                 {
                     entityResponse.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     entityResponse.Entity = null; ;
                 }
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }

         public IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> GetBySearchNotificationTransaction(NotificationTypeMasterAndNotificationTransactionSearchRequest searchRequest)
         {
             IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> NotificationTransactionCollection = new BaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 if (notificationTypeMasterAndNotificationTransactionDataProvider != null)
                     NotificationTransactionCollection = notificationTypeMasterAndNotificationTransactionDataProvider.GetBySearchNotificationTransaction(searchRequest);
                 else
                 {
                     NotificationTransactionCollection.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     NotificationTransactionCollection.CollectionResponse = null;
                 }
             }
             catch (Exception ex)
             {
                 NotificationTransactionCollection.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 NotificationTransactionCollection.CollectionResponse = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return NotificationTransactionCollection;
         }

         public IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> SelectByNotificationTransactionID(NotificationTypeMasterAndNotificationTransaction item)
         {
             IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> entityResponse = new BaseEntityResponse<NotificationTypeMasterAndNotificationTransaction>();
             try
             {
                 entityResponse = notificationTypeMasterAndNotificationTransactionDataProvider.SelectByNotificationTransactionID(item);
             }
             catch (Exception ex)
             {
                 entityResponse.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 entityResponse.Entity = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return entityResponse;
         }

    }
}
