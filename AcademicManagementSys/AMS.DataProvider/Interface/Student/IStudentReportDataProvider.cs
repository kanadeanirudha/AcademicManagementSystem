using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IStudentReportDataProvider
    {

        IBaseEntityCollectionResponse<StudentReport> GetBySearchForOrignalBranchwise(StudentReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentList(StudentReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentReport> GetBySearchForAddress(StudentReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentReport> GetBySearchForRollListwise(StudentReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentReport> GetBySearchForCategorywise(StudentReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentIdentityCard(StudentReportSearchRequest searchRequest); 
        IBaseEntityCollectionResponse<StudentReport> GetStudentSearchListForIdentityCard(StudentReportSearchRequest searchRequest);

    }
}
