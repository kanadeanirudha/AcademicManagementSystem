using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface INotificationTypeMasterAndNotificationTransactionBR
    {
        //NotificationTypeMaster
        IValidateBusinessRuleResponse InsertNotificationTypeMasterValidate(NotificationTypeMasterAndNotificationTransaction item);

        IValidateBusinessRuleResponse UpdateNotificationTypeMasterValidate(NotificationTypeMasterAndNotificationTransaction item);

        IValidateBusinessRuleResponse DeleteNotificationTypeMasterValidate(NotificationTypeMasterAndNotificationTransaction item);

        //NotificationTransaction
        IValidateBusinessRuleResponse InsertNotificationTransactionValidate(NotificationTypeMasterAndNotificationTransaction item);

        IValidateBusinessRuleResponse UpdateNotificationTransactionValidate(NotificationTypeMasterAndNotificationTransaction item);

        IValidateBusinessRuleResponse DeleteNotificationTransactionValidate(NotificationTypeMasterAndNotificationTransaction item);
    }
}
