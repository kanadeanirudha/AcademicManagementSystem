
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamViewModel
    {
        OnlineExam OnlineExamDTO
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
