﻿
using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using AMS.DTO;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IStudentReportCardServiceAccess
    {
        IBaseEntityCollectionResponse<StudentReportCard> GetStudentReportCardData(StudentReportCardSearchRequest searchRequest);
    }
}
