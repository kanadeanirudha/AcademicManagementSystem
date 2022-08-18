using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IEmployeeOtherCollegeSpecialLectureDetailsServiceAccess
    {
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> InsertEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> UpdateEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> DeleteEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> GetBySearch(EmployeeOtherCollegeSpecialLectureDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> SelectByID(EmployeeOtherCollegeSpecialLectureDetails item);
    }
}
