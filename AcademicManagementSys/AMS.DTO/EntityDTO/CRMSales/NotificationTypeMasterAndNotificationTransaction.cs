using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class NotificationTypeMasterAndNotificationTransaction : BaseDTO
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~NotificationTypeMaster~~~~~~~~~~~~~~~~~~~~
        public Int16 NotificationTypeMasterID { get; set; }
        public string NotificationType { get; set; }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~NotificationTransaction ~~~~~~~~~~~~~~~~~
        public int NotificationTransactionID { get; set; }
        public string TransactionDate { get; set; }
        public Int16 AutoExpiryInDays { get; set; }
        public int FromUserID { get; set; }
        public int ToUserID { get; set; }
        public string SubjectDescription { get; set; }
        public string BodyDescription { get; set; }
        public string FromMailID { get; set; }
        public string ToMailID { get; set; }
        public string Status { get; set; }
        public string FromContactNumber { get; set; }
        public string ToContactNumber { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Property ~~~~~~~~~~~~~~~~~~~~~~~~
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }

        public string EmployeeFullName { get; set; }
        public string FromEmployeeFullName { get; set; }  
    }
}
 