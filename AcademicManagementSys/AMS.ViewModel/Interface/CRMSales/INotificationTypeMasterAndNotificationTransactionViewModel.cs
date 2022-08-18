using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface INotificationTypeMasterAndNotificationTransactionViewModel
    {
        NotificationTypeMasterAndNotificationTransaction NotificationTypeMasterAndNotificationTransactionDTO { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~NotificationTypeMaster~~~~~~~~~~~~~~~~~~~~        
        Int16 NotificationTypeMasterID { get; set; }
        string NotificationType { get; set; }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~NotificationTransaction ~~~~~~~~~~~~~~~~~
        int NotificationTransactionID { get; set; }
        string TransactionDate { get; set; }
        Int16 AutoExpiryInDays { get; set; }
        int FromUserID { get; set; }
        int ToUserID { get; set; }
        string SubjectDescription { get; set; }
        string BodyDescription { get; set; }
        string FromMailID { get; set; }
        string ToMailID { get; set; }
        string Status { get; set; }
        string FromContactNumber { get; set; }
        string ToContactNumber { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Property ~~~~~~~~~~~~~~~~~~~~~~~~
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
