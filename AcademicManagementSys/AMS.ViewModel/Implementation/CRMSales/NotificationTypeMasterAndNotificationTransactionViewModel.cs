using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AMS.ViewModel
{
    public class NotificationTypeMasterAndNotificationTransactionViewModel : INotificationTypeMasterAndNotificationTransactionViewModel
    {
        public NotificationTypeMasterAndNotificationTransactionViewModel()
        {
            NotificationTypeMasterAndNotificationTransactionDTO = new NotificationTypeMasterAndNotificationTransaction();
            ListEmpEmployeeMaster = new List<EmpEmployeeMaster>();
        }
        //NotificationTypeMaster
        public NotificationTypeMasterAndNotificationTransaction NotificationTypeMasterAndNotificationTransactionDTO { get; set; }
        public List<EmpEmployeeMaster> ListEmpEmployeeMaster { get; set; }


        public IEnumerable<SelectListItem> ListEmpEmployeeMasterItems
        {
            get
            {
                return new SelectList(ListEmpEmployeeMaster, "ID", "EmailID");
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~NotificationTypeMaster~~~~~~~~~~~~~~~~~~~~
        public Int16 NotificationTypeMasterID
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.NotificationTypeMasterID : new Int16();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.NotificationTypeMasterID = value;
            }
        }

        public string NotificationType
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.NotificationType : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.NotificationType = value;
            }
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~NotificationTransaction ~~~~~~~~~~~~~~~~~

        public int NotificationTransactionID
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.NotificationTransactionID : new int();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.NotificationTransactionID = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.TransactionDate : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.TransactionDate = value;
            }
        }

        public Int16 AutoExpiryInDays 
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.AutoExpiryInDays : new Int16();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.AutoExpiryInDays = value;
            }
        }

        public int FromUserID
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.FromUserID : new int();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.FromUserID = value;
            }
        }

        [Display(Name="To")]
        [Required(ErrorMessage = "To user should not be blank")]
        public int ToUserID
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.ToUserID : new int();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.ToUserID = value;
            }
        }

        [Display(Name="Subject")]
        [Required(ErrorMessage = "Subject should not be blank")]
        public string SubjectDescription
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.SubjectDescription : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.SubjectDescription = value;
            }
        }

        [Display(Name ="Description")]
        [Required(ErrorMessage = "Description should not be blank")]
        public string BodyDescription
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.BodyDescription : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.BodyDescription = value;
            }
        }
        public string FromMailID
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.FromMailID : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.FromMailID = value;
            }
        }

        public string ToMailID
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.ToMailID : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.ToMailID = value;
            }
        }
        public string Status
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.Status : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.Status = value;
            }
        }
        public string FromContactNumber
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.FromContactNumber : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.FromContactNumber = value;
            }
        }
        public string ToContactNumber
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.ToContactNumber : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.ToContactNumber = value;
            }
        }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Coomon Property ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.IsDeleted : false;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null && NotificationTypeMasterAndNotificationTransactionDTO.CreatedBy > 0) ? NotificationTypeMasterAndNotificationTransactionDTO.CreatedBy : new int();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null && NotificationTypeMasterAndNotificationTransactionDTO.ModifiedBy.HasValue) ? NotificationTypeMasterAndNotificationTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null && NotificationTypeMasterAndNotificationTransactionDTO.ModifiedDate.HasValue) ? NotificationTypeMasterAndNotificationTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.DeletedBy : new int();
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.DeletedDate = value;
            }
        }

        public string EmployeeFullName
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.EmployeeFullName : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.EmployeeFullName = value;
            }
        }
        public string FromEmployeeFullName
        {
            get
            {
                return (NotificationTypeMasterAndNotificationTransactionDTO != null) ? NotificationTypeMasterAndNotificationTransactionDTO.FromEmployeeFullName : string.Empty;
            }
            set
            {
                NotificationTypeMasterAndNotificationTransactionDTO.FromEmployeeFullName = value;
            }
        }
        public string errorMessage { get; set; }

    }
}
