
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExamExaminationQuePaperDetailsViewModel
    {
        OnlineExamExaminationQuePaperDetails OnlineExamExaminationQuePaperDetailsDTO
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
