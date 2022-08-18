using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExaminationHallTicketViewModel
    {
        OnlineExaminationHallTicket OnlineExaminationHallTicketDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        int StudentRegistrationID
        {
            get;
            set;
        }
        string RegistrationNumber
        {
            get;
            set;
        }
        int RollNumber
        {
            get;
            set;
        }
        string StudentFullName
        {
            get;
            set;
        }
        string Gender
        {
            get;
            set;
        }
     
        string ExamDate
        {
            get;
            set;
        }
        string ExamTime
        {
            get;
            set;
        }
        string Venue
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
