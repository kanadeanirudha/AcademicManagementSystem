using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudentReportServiceAccess : IStudentReportServiceAccess
    {
        IStudentReportBA _StudentReportBA = null;
        public StudentReportServiceAccess()
        {
            _StudentReportBA = new StudentReportBA();
        }

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForOrignalBranchwise(StudentReportSearchRequest searchRequest)
        {
            return _StudentReportBA.GetBySearchForOrignalBranchwise(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentList(StudentReportSearchRequest searchRequest)
        {
            return _StudentReportBA.GetBySearchForStudentList(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForAddress(StudentReportSearchRequest searchRequest)
        {
            return _StudentReportBA.GetBySearchForAddress(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForRollListwise(StudentReportSearchRequest searchRequest)
        {
            return _StudentReportBA.GetBySearchForRollListwise(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForCategorywise(StudentReportSearchRequest searchRequest)
        {
            return _StudentReportBA.GetBySearchForCategorywise(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentIdentityCard(StudentReportSearchRequest searchRequest)
        {
            return _StudentReportBA.GetBySearchForStudentIdentityCard(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentReport> GetStudentSearchListForIdentityCard(StudentReportSearchRequest searchRequest)
        {
            return _StudentReportBA.GetStudentSearchListForIdentityCard(searchRequest);
        }
    }
}
