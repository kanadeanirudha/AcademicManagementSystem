
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamStudentApplicableViewModel
    {
        OnlineExamStudentApplicable OnlineExamStudentApplicableDTO
        {
            get;
            set;
        }

        Byte ID
        {
            get;
            set;
        }
        
    }
}
