﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IStudentReportCardBA
    {
        IBaseEntityCollectionResponse<StudentReportCard> GetStudentReportCardData(StudentReportCardSearchRequest searchRequest);
    }
}
