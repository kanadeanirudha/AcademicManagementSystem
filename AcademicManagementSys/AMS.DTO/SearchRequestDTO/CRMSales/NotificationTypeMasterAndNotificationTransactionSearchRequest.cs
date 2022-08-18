using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class NotificationTypeMasterAndNotificationTransactionSearchRequest : Request
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

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~Common Property~~~~~~~~~~~~~~~~~~~~~~~
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

    }
}
 