
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudentReportCardServiceAccess : IStudentReportCardServiceAccess
    {
        IStudentReportCardBA _StudentReportCardBA = null;
        public StudentReportCardServiceAccess()
        {
            _StudentReportCardBA = new StudentReportCardBA();
        }

        public IBaseEntityCollectionResponse<StudentReportCard> GetStudentReportCardData(StudentReportCardSearchRequest searchRequest)
        {
            return _StudentReportCardBA.GetStudentReportCardData(searchRequest);
        }
    }
}
