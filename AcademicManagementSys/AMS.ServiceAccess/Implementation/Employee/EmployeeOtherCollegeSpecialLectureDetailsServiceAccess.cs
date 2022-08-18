using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeOtherCollegeSpecialLectureDetailsServiceAccess : IEmployeeOtherCollegeSpecialLectureDetailsServiceAccess
    {
        IEmployeeOtherCollegeSpecialLectureDetailsBA _employeeOtherCollegeSpecialLectureDetailsBA = null;
        public EmployeeOtherCollegeSpecialLectureDetailsServiceAccess()
        {
            _employeeOtherCollegeSpecialLectureDetailsBA = new EmployeeOtherCollegeSpecialLectureDetailsBA();
        }
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> InsertEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            return _employeeOtherCollegeSpecialLectureDetailsBA.InsertEmployeeOtherCollegeSpecialLectureDetails(item);
        }
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> UpdateEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            return _employeeOtherCollegeSpecialLectureDetailsBA.UpdateEmployeeOtherCollegeSpecialLectureDetails(item);
        }
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> DeleteEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            return _employeeOtherCollegeSpecialLectureDetailsBA.DeleteEmployeeOtherCollegeSpecialLectureDetails(item);
        }
        public IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> GetBySearch(EmployeeOtherCollegeSpecialLectureDetailsSearchRequest searchRequest)
        {
            return _employeeOtherCollegeSpecialLectureDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> SelectByID(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            return _employeeOtherCollegeSpecialLectureDetailsBA.SelectByID(item);
        }
    }
}
