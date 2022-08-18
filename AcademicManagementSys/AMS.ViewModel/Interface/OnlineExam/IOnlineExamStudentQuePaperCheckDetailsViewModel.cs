
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamStudentQuePaperCheckDetailsViewModel
    {
        OnlineExamStudentQuePaperCheckDetails OnlineExamStudentQuePaperCheckDetailsDTO
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
